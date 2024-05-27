using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCoach
{
    public partial class WatchWorkout : Form
    {
        private SqlConnection cn;
        private int currentExercise;
        //private bool adding;
        //private string videopath;
        private int workout_prog_entry_num = 1;
        private int reps_prog_entry_num = 1;
        private int time_prog_entry_num = 1;

        public WatchWorkout()
        {
            InitializeComponent();
            time_label.Visible = false;
            txtTime.Visible = false;
        }

        private void WatchWorkout_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            workout_prog_entry_num = GetMaxEntryNum("workout_progress") + 1;

            reps_prog_entry_num = GetMaxEntryNum("reps_progress") + 1;
            time_prog_entry_num = GetMaxEntryNum("time_progress") + 1;
            loadWorkoutInfo(sender, e);
            loadWorkoutExercisesToolStripMenuItem_Click(sender, e);
        }
        private int GetMaxEntryNum(string tableName)
        {
            if (!verifySGBDConnection())
                return 0;

            int maxEntryNum = 0;
            SqlCommand cmd = new SqlCommand($"SELECT MAX(entry_num) AS max_entry_num FROM {tableName}", cn);
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                try
                {
                    maxEntryNum = int.Parse(reader["max_entry_num"].ToString());
                }
                catch
                {
                    maxEntryNum = 0;
                }
            }
            reader.Close();
            cn.Close();

            return maxEntryNum;
        }
        private void InsertWorkoutProgress()
        {
            if (!verifySGBDConnection())
                return;

            using (SqlCommand cmd = new SqlCommand("INSERT INTO workout_progress VALUES (@entry_num, @athlete_num, @date, @num_workout)", cn))
            {
                cmd.Parameters.AddWithValue("@entry_num", workout_prog_entry_num);
                cmd.Parameters.AddWithValue("@athlete_num", UserLogin.athlete_num);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@num_workout", Workouts.num_workout);
                cmd.ExecuteNonQuery();
            }
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }




        private void loadWorkoutInfo(object sender, EventArgs e)
        {
            txtTitle.ReadOnly = true;
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM workout WHERE num_workout=@num_workout", cn);
            cmd.Parameters.AddWithValue("@num_workout", Workouts.num_workout);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtTitle.Text = reader["title"].ToString();
            }
            reader.Close();
        }
        private void loadWorkoutExercisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM workout_exercise  join exercise on workout_exercise.num_ex=exercise.num_ex WHERE num_workout=@num_workout", cn);
            cmd.Parameters.AddWithValue("@num_workout", Workouts.num_workout);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Exercise exercise = new Exercise();
                exercise.Path = reader["path"].ToString();
                exercise.NumEx = int.Parse(reader["num_ex"].ToString());
                exercise.Name = reader["name"].ToString();
                exercise.Description = reader["description"].ToString();
                exercise.MuscleTargets = reader["muscletargets"].ToString();
                exercise.ReleaseDate = reader["releasedate"].ToString();
                exercise.IsTime = int.Parse(reader["is_time"].ToString());


                ExerciseWithProgress exerciseWithProgress = new ExerciseWithProgress();
                exerciseWithProgress.Exercise = exercise;
                if (exercise.IsTime == 0)
                {
                    RepsProgress progress = new RepsProgress();
                    progress.EntryNum = reps_prog_entry_num++;  // increment reps_prog_entry_num for the future entries
                    progress.EntryWorkout = workout_prog_entry_num;
                    progress.NumEx = exercise.NumEx;
                    progress.SetNum = int.Parse(reader["set_num"].ToString());
                    progress.RepsMade = 0;
                    progress.WeightUsed = 0;
                    exerciseWithProgress.Progress = progress;


                }
                else
                {
                    TimeProgress progress = new TimeProgress()
                    {
                        EntryNum = time_prog_entry_num++,         // increment time_prog_entry_num for the future entries
                        EntryWorkout = workout_prog_entry_num,
                        NumEx = exercise.NumEx,
                        SetNum = int.Parse(reader["set_num"].ToString()),
                        Time = 0
                    };
                    exerciseWithProgress.Progress = progress;
                }

                listBox1.Items.Add(exerciseWithProgress);
                // Insert query for each exercise

            }
            reader.Close();

            cn.Close();
            txtSetNum.ReadOnly = true;
            currentExercise = 0;

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentExercise = listBox1.SelectedIndex;
                ShowProgress();
            }
        }

        public void ShowProgress()
        {
            if (listBox1.Items.Count == 0 | currentExercise < 0)
                return;
            ExerciseWithProgress exerciseWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
            Exercise exercise = exerciseWithProgress.Exercise;
            IProgress progress = exerciseWithProgress.Progress;

            txtSetNum.Text = progress.SetNum.ToString();

            if (progress is RepsProgress repsProgress)
            {
                txtRepsMade.Visible = true;
                reps_label.Visible = true;
                txtWeightUsed.Visible = true;
                weight_label.Visible = true;
                txtTime.Visible = false;
                time_label.Visible = false;

                txtRepsMade.Text = repsProgress.RepsMade.ToString();
                txtWeightUsed.Text = repsProgress.WeightUsed.ToString();
            }
            else if (progress is TimeProgress timeProgress)
            {
                txtTime.Visible = true;
                time_label.Visible = true;
                txtRepsMade.Visible = false;
                reps_label.Visible = false;
                txtWeightUsed.Visible = false;
                weight_label.Visible = false;

                txtTime.Text = timeProgress.Time.ToString();

            }


        }





        public void ClearFields()
        {
            txtRepsMade.Text = "0";
            txtWeightUsed.Text = "0";
            txtTime.Text = "0";
        }


        private void SaveProgress()
        {
            try
            {
                ExerciseWithProgress exerciseWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
                Exercise exercise = exerciseWithProgress.Exercise;
                IProgress progress = exerciseWithProgress.Progress;

                progress.SetNum = int.Parse(txtSetNum.Text);

                if (progress is RepsProgress repsProgress)
                {
                    repsProgress.RepsMade = int.Parse(txtRepsMade.Text);
                    repsProgress.WeightUsed = int.Parse(txtWeightUsed.Text);
                }
                else if (progress is TimeProgress timeProgress)
                {
                    timeProgress.Time = int.Parse(txtTime.Text);
                }

                listBox1.Items[currentExercise] = exerciseWithProgress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        private void bttnConfirm_Click_1(object sender, EventArgs e)  // Confirm button
        {

            SaveProgress();
            listBox1.Enabled = true;
        }

        private void bttnPlay_Click(object sender, EventArgs e)  // Play button
        {
            //string currentDirectory = Environment.CurrentDirectory;
            ExerciseWithProgress exerciseWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
            Exercise exercise = exerciseWithProgress.Exercise;
            string f = Path.GetFullPath(exercise.Path);
            try
            {
                axWindowsMediaPlayer1.URL = f;
                //MessageBox.Show("working directory: " + currentDirectory + "\n directory: " + f);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message+ "\n working directory: "+currentDirectory+"\n directory: "+f);
                MessageBox.Show("Error: " + ex.Message + "\n directory: " + f);

            }
        }

        private void bttnPrevExercise_Click(object sender, EventArgs e)
        {
            if (currentExercise > 0)
            {
                currentExercise--;
                listBox1.SelectedIndex = currentExercise;
            }
        }
        public void bttnNextExercise_Click(object sender, EventArgs e)
        {
            if (currentExercise < listBox1.Items.Count - 1)
            {
                currentExercise++;
                listBox1.SelectedIndex = currentExercise;
            }
        }





        private void bttnCancel_Click_1(object sender, EventArgs e)  // Cancel button
        {
            listBox1.Enabled = true;
            if (listBox1.Items.Count > 0)
            {
                currentExercise = listBox1.SelectedIndex;
                if (currentExercise < 0)
                    currentExercise = 0;
                ShowProgress();
            }
            else
            {
                ClearFields();
            }
        }


        private void RemoveRepsProgress(int EntryNum)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM reps_progress WHERE entry_num=@entry_num", cn);
            cmd.Parameters.AddWithValue("@entry_num", EntryNum);
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        private void bttnFinishWorkout_Click(object sender, EventArgs e)
        {
            InsertWorkoutProgress();
            foreach (ExerciseWithProgress exerciseWithProgress in listBox1.Items)
            {

                if (exerciseWithProgress.Progress is RepsProgress repsProgress)
                {
                    SubmitRepsProgress(repsProgress);
                }
                else if (exerciseWithProgress.Progress is TimeProgress timeProgress)
                {
                    SubmitTimeProgress(timeProgress);

                }


            }
            MessageBox.Show("Progress uploaded successfuly!");
        }

        private void UpdateRepsProgress(RepsProgress progress)
        {
            int rows = 0;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE reps_progress SET num_ex = @num_ex, set_num = @set_num, reps_made = @reps_made, weight_used = @weight_used "
                + "WHERE entry_num = @entry_num";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@reps_made", progress.RepsMade);
            cmd.Parameters.AddWithValue("@weight_used", progress.WeightUsed);
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database.\n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                /*
                if (rows == 1)
                    MessageBox.Show("Update OK");
                else
                    MessageBox.Show("Update NOT OK");
                */
                cn.Close();
            }
        }

        private void UpdateTimeProgress(TimeProgress progress)
        {
            int rows = 0;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE time_progress SET num_ex = @num_ex, set_num = @set_num, time = @time WHERE entry_num = @entry_num";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@time", progress.Time);
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database.\n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                /*
                if (rows == 1)
                    MessageBox.Show("Update OK");
                else
                    MessageBox.Show("Update NOT OK");
                */
                cn.Close();
            }
        }

        private void SubmitRepsProgress(RepsProgress progress)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO reps_progress VALUES (@entry_num,@entry_workout, @num_ex, @set_num, @reps_made, @weight_used) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);
            cmd.Parameters.AddWithValue("@entry_workout", progress.EntryWorkout);
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@reps_made", progress.RepsMade);
            cmd.Parameters.AddWithValue("@weight_used", progress.WeightUsed);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update progress in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        private void SubmitTimeProgress(TimeProgress progress)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO time_progress VALUES (@entry_num,@entry_workout, @num_ex, @set_num, @time) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);
            cmd.Parameters.AddWithValue("@entry_workout", progress.EntryWorkout);
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@time", progress.Time);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update progress in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void txtSetNum_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtRepsMade_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtWeightUsed_TextChanged(object sender, EventArgs e)
        {

        }



        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void bttnNextSet_Click(object sender, EventArgs e)
        {

        }


        public void label1_Click(object sender, EventArgs e) // set number
        {

        }
        private void label2_Click(object sender, EventArgs e) // number of reps
        {

        }
        private void label5_Click(object sender, EventArgs e) // weight used
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnLogOut_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
