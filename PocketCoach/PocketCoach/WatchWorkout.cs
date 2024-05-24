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
        private bool adding;
        private string videopath;
        private int workout_prog_entry_num = 1;
        private int reps_prog_entry_num = 1;

        public WatchWorkout()
        {
            InitializeComponent();
        }

        private void WatchWorkout_Load(object sender, EventArgs e)
        {
            cn = DBLogin.getSGBDConnection();

            ShowButtons();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT entry_num FROM workout_progress WHERE entry_num=(SELECT MAX(entry_num) FROM workout_progress);", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                workout_prog_entry_num = int.Parse(reader["entry_num"].ToString()) + 1;
            }
            reader.Close();
            cn.Close();
            WorkoutProgress workoutProgress = new WorkoutProgress();
            workoutProgress.EntryNum = workout_prog_entry_num;
            workoutProgress.AthleteNum = UserLogin.athlete_num;
            workoutProgress.Date = DateTime.Now.ToString("yyyy-MM-dd");
            workoutProgress.NumWorkout = Workouts.num_workout;

            cn.Open();
            cmd = new SqlCommand("Insert into workout_progress VALUES(@entry_num,@athlete_num,@date,@num_workout)", cn);
            cmd.Parameters.AddWithValue("@entry_num", workoutProgress.EntryNum);
            cmd.Parameters.AddWithValue("@athlete_num", workoutProgress.AthleteNum);
            cmd.Parameters.AddWithValue("@date", workoutProgress.Date);
            cmd.Parameters.AddWithValue("@num_workout", workoutProgress.NumWorkout);
            cmd.ExecuteNonQuery();
            cn.Close();





            cn.Open();
            cmd = new SqlCommand("SELECT entry_num FROM reps_progress WHERE entry_num=(SELECT MAX(entry_num) FROM reps_progress);", cn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reps_prog_entry_num = int.Parse(reader["entry_num"].ToString()) + 1;
            }
            reader.Close();
            cn.Close();

            loadWorkoutExercisesToolStripMenuItem_Click(sender, e);
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = DBLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
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
                /*
                insertCmd.Parameters.AddWithValue("@num_workout", 1); // Replace with actual workout number
                insertCmd.Parameters.AddWithValue("@num_ex", exerciseWithProgress.Exercise.NumEx);
                insertCmd.Parameters.AddWithValue("@set_num", exerciseWithProgress.SetNum);
                insertCmd.Parameters.AddWithValue("@reps", 0); // Replace with actual reps if available
                insertCmd.Parameters.AddWithValue("@weight", 0); // Replace with actual weight if available
                insertCmd.ExecuteNonQuery();
                */
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
            /*
            int index = 0;
            foreach (ExerciseWithProgress exerciseWithProgress in listBox1.Items)
            {

                RepsProgress progress = new RepsProgress();
                /*
                insertCmd.Parameters.AddWithValue("@num_workout", 1); // Replace with actual workout number
                insertCmd.Parameters.AddWithValue("@num_ex", exerciseWithProgress.Exercise.NumEx);
                insertCmd.Parameters.AddWithValue("@set_num", exerciseWithProgress.SetNum);
                insertCmd.Parameters.AddWithValue("@reps", 0); // Replace with actual reps if available
                insertCmd.Parameters.AddWithValue("@weight", 0); // Replace with actual weight if available
                insertCmd.ExecuteNonQuery();
                */
                /*
                progress.EntryNum = reps_prog_entry_num;
                progress.EntryWorkout = workout_prog_entry_num;
                progress.NumEx = exerciseWithProgress.Exercise.NumEx;
                progress.SetNum = exerciseWithProgress.Progress.SetNum;
                progress.RepsMade = 0;
                progress.WeightUsed = 0;
                // insert into the database the default values for the progress
                SubmitRepsProgress(progress);



                ExerciseWithProgress exerciseWithProgress1 = (ExerciseWithProgress)listBox1.Items[index];
                exerciseWithProgress.Progress = progress;
                // update listbox with the progress information
                listBox1.Items[index] = exerciseWithProgress1;



                reps_prog_entry_num++;
                index++;

            }
            */
                cn.Close();

            txtSetNum.ReadOnly = true;

            currentExercise = 0;

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
            ExerciseWithProgress exerciseWithProgress = new ExerciseWithProgress();
            exerciseWithProgress = (ExerciseWithProgress)listBox1.Items[currentExercise];
            Exercise exercise = exerciseWithProgress.Exercise;
            RepsProgress progress = exerciseWithProgress.Progress;

            txtSetNum.Text = progress.SetNum.ToString();

            /*
            RepsProgress repsProgress = new RepsProgress();
            repsProgress.EntryNum = entry_num;
            repsProgress.EntryWorkout = Workouts.num_workout;
            repsProgress.NumEx = exercise.NumEx;
            */
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM reps_progress where entry_workout_prog=@entry_workout_prog and num_ex=@num_ex and set_num=@set_num", cn);
            cmd.Parameters.AddWithValue("@entry_workout_prog", workout_prog_entry_num);
            cmd.Parameters.AddWithValue("@num_ex", exercise.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            SqlDataReader reader = cmd.ExecuteReader();
            RepsProgress repsProgress = new RepsProgress();
            while (reader.Read())
            {

                repsProgress.SetNum = int.Parse(reader["set_num"].ToString());          // YOU CAN REMOVE THIS LINE
                repsProgress.RepsMade = int.Parse(reader["reps_made"].ToString());
                repsProgress.WeightUsed = int.Parse(reader["weight_used"].ToString());
                repsProgress.NumEx = int.Parse(reader["num_ex"].ToString());

                txtRepsMade.Text = repsProgress.RepsMade.ToString();
                txtWeightUsed.Text = repsProgress.WeightUsed.ToString();
                //MessageBox.Show("repsProgress: " + repsProgress.ToString());
            }
            /*
            txtSetNum.Text = progress.SetNum.ToString();
            txtRepsMade.Text = progress.RepsMade.ToString();
            txtWeightUsed.Text = progress.WeightUsed.ToString();
            */


            try
            {
                //MessageBox.Show("num_ex: " + num_ex.Text);
                /*hValue("@num_ex", txtNumEx.Text);
                 SqlDataReader reader = cmd.ExecuteReader();

                 if (reader.Read())
                 {
                     videopath = reader["path"].ToString();
                     //MessageBox.Show("path: " + videopath);
                 }
                 else
                 {
                     MessageBox.Show("No data found for num_ex: " + progress.NumEx);
                 }
                */


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            cn.Close();
        }




        public void LockControls()
        {
            /*
            txtSetNum.ReadOnly = true;
            txtRepsMade.ReadOnly = true;
            txtWeightUsed.ReadOnly = true;
            */
        }

        public void UnlockControls()
        {
            /*
            txtSetNum.ReadOnly = false;
            txtRepsMade.ReadOnly = false;
            txtWeightUsed.ReadOnly = false;
            */
        }

        public void HideButtons()
        {
            /*
            UnlockControls();
            bttnAdd.Visible = false;
            bttnEdit.Visible = false;
            bttnConfirm.Visible = true;
            bttnCancel.Visible = true;
            */
        }

        public void ShowButtons()
        {
            /*
            LockControls();
            bttnAdd.Visible = true;
            bttnEdit.Visible = true;
            bttnConfirm.Visible = false;
            bttnCancel.Visible = false;
            */
        }

        public void ClearFields()
        {
            txtSetNum.Text = "";
            txtRepsMade.Text = "";
            txtWeightUsed.Text = "";
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
                if (rows == 1)
                    MessageBox.Show("Update OK");
                else
                    MessageBox.Show("Update NOT OK");

                cn.Close();
            }
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            /*
            if (adding)
            {
                SubmitRepsProgress(progress);
                listBox1.Items.Add(progress);
            }
            else
            {
            */
                UpdateRepsProgress(progress);
                //listBox1.Items[currentExercise] = progress;
            //}
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
            //int idx = listBox1.FindString(txtEntryNum.Text);
            //listBox1.SelectedIndex = idx;
            ShowButtons();
        }

        private void bttnPlay_Click(object sender, EventArgs e)  // Play button
        {
            //string currentDirectory = Environment.CurrentDirectory;
            string f = Path.GetFullPath(videopath);
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
                LockControls();
            }
            ShowButtons();
        }



        private void bttnAdd_Click_1(object sender, EventArgs e)  //add button
        {
            adding = true;
            ClearFields();
            HideButtons();
            listBox1.Enabled = false;
        }

        private void bttnEdit_Click_1(object sender, EventArgs e)  // edit button
        {
            currentExercise = listBox1.SelectedIndex;
            if (currentExercise < 0)
            {
                MessageBox.Show("Please select a contact to edit");
                return;
            }
            adding = false;
            HideButtons();
            listBox1.Enabled = false;
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





        private void bttnPrevExercise_Click(object sender, EventArgs e)
        {

        }
        public void bttnNextExercise_Click(object sender, EventArgs e)
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

    }
}
