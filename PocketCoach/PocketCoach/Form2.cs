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
    public partial class Form2 : Form
    {

        private SqlConnection cn;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            loadExerciseToolStripMenuItem_Click(sender, e);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= LAPTOP-5HIDEPJS\\SQLEXPRESS;integrated security=true;initial catalog=PocketCoach;");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

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

            SqlCommand cmd = new SqlCommand("SELECT * FROM exercise", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Exercise exercise = new Exercise();
                int numEx;
                if (int.TryParse(reader["num_ex"].ToString(), out numEx))
                {
                    exercise.NumEx = numEx;
                }
                else
                {
                    // Conversion failed, handle the error or use a default value
                }

                exercise.Path = reader["path"].ToString();
                exercise.Name = reader["name"].ToString();
                exercise.Description = reader["description"].ToString();
                exercise.MuscleTargets = reader["muscletargets"].ToString();
                exercise.ReleaseDate = reader["releasedate"].ToString();
                exercise.Premium = int.Parse(reader["premium"].ToString());
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
    }
}
