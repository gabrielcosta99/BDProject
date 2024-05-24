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

        public WatchWorkout()
        {
            InitializeComponent();
        }

        private void WatchWorkout_Load(object sender, EventArgs e)
        {
            cn = DBLogin.getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            workout_prog_entry_num = GetMaxEntryNum("workout_progress") + 1;
            InsertWorkoutProgress();

            reps_prog_entry_num = GetMaxEntryNum("reps_progress") + 1;

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
                maxEntryNum = int.Parse(reader["max_entry_num"].ToString());
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
                cn = DBLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
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

                RepsProgress progress = new RepsProgress();
                progress.EntryNum = reps_prog_entry_num;
                progress.EntryWorkout = workout_prog_entry_num;
                progress.NumEx = exercise.NumEx;
                progress.SetNum = int.Parse(reader["set_num"].ToString());
                progress.RepsMade = 0;
                progress.WeightUsed = 0;


                ExerciseWithProgress exerciseWithProgress = new ExerciseWithProgress();
                exerciseWithProgress.Exercise = exercise;
                exerciseWithProgress.Progress = progress;

                listBox1.Items.Add(exerciseWithProgress);
                reps_prog_entry_num++;
                // Insert query for each exercise

            }
            reader.Close();
            foreach (ExerciseWithProgress exerciseWithProgress in listBox1.Items)
            {
                RepsProgress progress = exerciseWithProgress.Progress;
                SubmitRepsProgress(progress);
            }
            cn.Close();




            txtSetNum.ReadOnly = true;
            currentExercise = 0;

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentExercise = listBox1.SelectedIndex;
                ShowRepsProgress();
            }
        }

        public void ShowRepsProgress()
        {
            if (listBox1.Items.Count == 0 | currentExercise < 0)
                return;
            ExerciseWithProgress exerciseWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
            Exercise exercise = exerciseWithProgress.Exercise;
            RepsProgress progress = exerciseWithProgress.Progress;

            txtSetNum.Text = progress.SetNum.ToString();
            txtRepsMade.Text = progress.RepsMade.ToString();
            txtWeightUsed.Text = progress.WeightUsed.ToString();


            /*

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM reps_progress where entry_workout_prog=@entry_workout_prog and num_ex=@num_ex and set_num=@set_num", cn);
            cmd.Parameters.AddWithValue("@entry_workout_prog", workout_prog_entry_num);
            cmd.Parameters.AddWithValue("@num_ex", exercise.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtRepsMade.Text = reader["reps_made"].ToString();
                txtWeightUsed.Text = reader["weight_used"].ToString();
            }
            
            reader.Close();
            cn.Close();
            */
        }





        public void ClearFields()
        {
            txtRepsMade.Text = "0";
            txtWeightUsed.Text = "0";
        }


        private bool SaveRepsProgress()
        {
            RepsProgress progress = new RepsProgress();
            try
            {
                ExerciseWithProgress exWithProgress = new ExerciseWithProgress();
                exWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
                Exercise exercise = exWithProgress.Exercise;
                RepsProgress prog = exWithProgress.Progress;

                progress.EntryNum = prog.EntryNum;
                progress.EntryWorkout = workout_prog_entry_num;
                progress.NumEx = exercise.NumEx;
                progress.SetNum = int.Parse(txtSetNum.Text);
                progress.RepsMade = int.Parse(txtRepsMade.Text);
                progress.WeightUsed = int.Parse(txtWeightUsed.Text);

                exWithProgress.Progress = progress;
                listBox1.Items[currentExercise] = exWithProgress;
                //UpdateRepsProgress(progress);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }


       


        private void bttnConfirm_Click_1(object sender, EventArgs e)  // Confirm button
        {
            try
            {
                SaveRepsProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                ShowRepsProgress();
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


        private void bttnDelete_Click(object sender, EventArgs e)  // delete button
        {


            if (listBox1.SelectedIndex > -1)
            {
                try
                {
                    RemoveRepsProgress(((RepsProgress)listBox1.SelectedItem).EntryNum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (currentExercise == listBox1.Items.Count)
                    currentExercise = listBox1.Items.Count - 1;
                if (currentExercise == -1)
                {
                    ClearFields();
                    MessageBox.Show("There are no more contacts");
                }
                else
                {
                    ShowRepsProgress();
                }
            }

        }
        private void bttnFinishWorkout_Click(object sender, EventArgs e)
        {
            foreach (ExerciseWithProgress exerciseWithProgress in listBox1.Items)
            {
                RepsProgress progress = exerciseWithProgress.Progress;
                UpdateRepsProgress(progress);
            }

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

        
    }
}
