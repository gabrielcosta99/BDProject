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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PocketCoach
{
    public partial class Workouts : Form
    {
        private SqlConnection cn;
        private int currentWorkout;
        public static int num_workout;

        public Workouts()
        {
            InitializeComponent();
        }

        private void Workouts_Load(object sender, EventArgs e)
        {
            SqlConnection cn = UserLogin.getSGBDConnection();
            loadExerciseToolStripMenuItem_Click(sender, e);
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void loadExerciseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand("SELECT w.num_workout, w.title,w.tags,w.premium,w.PT_num FROM athlete join subscription on athlete.num_athlete=subscription.num_athlete join workout as w on subscription.num_PT=w.PT_num WHERE athlete.num_athlete=@num_athlete;", cn);
            cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);

            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {

                Workout workout = new Workout();
                workout.NumWorkout = int.Parse(reader["num_workout"].ToString());
                workout.Title = reader["title"].ToString();
                workout.Tags = reader["tags"].ToString();
                workout.Premium = int.Parse(reader["premium"].ToString());
                workout.PTNum = int.Parse(reader["PT_num"].ToString());
                listBox1.Items.Add(workout);


            }
            currentWorkout = 0;
            cn.Close();
        }

        private void ShowWorkout()
        {
            if (currentWorkout < 0)
                return;

            if (!verifySGBDConnection())
                return;

            Workout workout = new Workout();
            workout = (Workout)listBox1.Items[currentWorkout];

            SqlCommand cmd = new SqlCommand("SELECT num_ex FROM workout_exercise WHERE num_workout=@num_workout", cn);
            cmd.Parameters.AddWithValue("@num_workout", workout.NumWorkout);
            SqlDataReader reader = cmd.ExecuteReader();
            List<int> exercises = new List<int>();
            while (reader.Read())
            {
                exercises.Add(int.Parse(reader["num_ex"].ToString()));
            }
            reader.Close();
            cn.Close();

            cn.Open();
            for (int i = 0; i < exercises.Count; i++)
            {
                try
                {
                    cmd = new SqlCommand("SELECT name FROM exercise WHERE num_ex=@num_ex", cn);
                    cmd.Parameters.AddWithValue("@num_ex", exercises[i]);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        listBox2.Items.Add(reader["name"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


            cn.Close();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox2.Items.Clear();
                currentWorkout = listBox1.SelectedIndex;
                ShowWorkout();
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bttnCheckItOut_Click(object sender, EventArgs e)
        {
            Workout workout = new Workout();
            workout = (Workout)listBox1.Items[currentWorkout];
            num_workout = workout.NumWorkout;

            WatchWorkout watchWorkout = new WatchWorkout();
            watchWorkout.Show();
            this.Hide();
        }

        private void bttnLogOut_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }
    }
}
