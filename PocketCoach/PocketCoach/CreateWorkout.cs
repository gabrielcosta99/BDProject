using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PocketCoach
{
    public partial class CreateWorkout : Form
    {

        private SqlConnection cn;
        private bool isPremium = false;
        private Dictionary<int, int> exerciseCounts;

        public CreateWorkout()
        {
            InitializeComponent();
            exerciseCounts = new Dictionary<int, int>();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();
            loadExerciseToolStripMenuItem_Click(sender, e);

        }

        /*
        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= LAPTOP-5HIDEPJS\\SQLEXPRESS;integrated security=true;initial catalog=PocketCoach;");
            return new SqlConnection("data source= tcp:mednat.ieeta.pt\\SQLSERVER,8101;initial catalog=p7g6;uid=p7g6;password=BDgahe2003;");
        }
        */

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadExerciseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM exercise where PT_num=@PT_num", cn);
            cmd.Parameters.AddWithValue("@PT_num", UserLogin.PTNum);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Exercise exercise = new Exercise();
                exercise.NumEx = int.Parse(reader["num_ex"].ToString());
                exercise.Path = reader["path"].ToString();
                exercise.Name = reader["name"].ToString();
                exercise.Description = reader["description"].ToString();
                exercise.MuscleTargets = reader["muscletargets"].ToString();
                exercise.ReleaseDate = reader["releasedate"].ToString();
                //exercise.Premium = int.Parse(reader["premium"].ToString());
                exercise.PTNum = int.Parse(reader["PT_num"].ToString());
                exercise.Thumbnail = reader["thumbnail"].ToString();
                listBox1.Items.Add(exercise);

            }

            cn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  // Button "add"
        {

            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)  //Button "remove"
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
        private void ClearFields()
        {
            txtTags.Text = "";
            txtTitle.Text = "";
        }
        private void bttnUpload_Click(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM workout WHERE num_workout=(SELECT MAX(num_workout) FROM workout);";
            cmd.Connection = cn;
            SqlDataReader reader = cmd.ExecuteReader();
            int num_workout = 1;
            if (reader.Read())
            {
                num_workout = int.Parse(reader["num_workout"].ToString()) + 1;
            }
            reader.Close();
            cn.Close();

            cn.Open();
            if (!verifySGBDConnection())
                return;
            //Workout workout = new Workout();
            cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO workout(num_workout, title, tags,premium,PT_num) " + "VALUES (@num_workout, @title, @tags,@premium,@PT_num)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_workout", num_workout);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@tags", txtTags.Text);
            cmd.Parameters.AddWithValue("@premium", isPremium);
            cmd.Parameters.AddWithValue("@PT_num", UserLogin.PTNum);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update workout in database. \n ERROR MESSAGE: \n" + ex.Message);
            }


            for (int i = 0; i < listBox2.Items.Count; i++)
            {

                Exercise exercise = (Exercise)listBox2.Items[i];
                if (exerciseCounts.ContainsKey(exercise.NumEx))
                {
                    exerciseCounts[exercise.NumEx]++;
                }
                else
                {
                    exerciseCounts[exercise.NumEx] = 1;
                }
                cmd.CommandText = "INSERT INTO workout_exercise " + "VALUES (@num_workout, @num_exercise,@set_num)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@num_workout", num_workout);
                cmd.Parameters.AddWithValue("@num_exercise", exercise.NumEx);
                cmd.Parameters.AddWithValue("@set_num", exerciseCounts[exercise.NumEx]);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }
            }

            // Does this message always show even when it is not successful?
            MessageBox.Show("Workout uploaded successfully!");
            listBox2.Items.Clear();
            ClearFields();

            cn.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void chkIsPremium_CheckedChanged(object sender, EventArgs e)
        {
            isPremium = !isPremium;
        }

        private void bttnLogOut_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form menu = new PersonalTrainerMenu();
            menu.Show();
            this.Close();
        }
    }
}
