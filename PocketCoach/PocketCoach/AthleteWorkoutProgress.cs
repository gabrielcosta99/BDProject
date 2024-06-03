using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCoach
{
    public partial class AthleteWorkoutProgress : Form
    {
        private SqlConnection cn;
        private int currentWorkout;
        private int currentExercise;

        public AthleteWorkoutProgress()
        {
            InitializeComponent();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void AthleteWorkoutProgress_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();
            if (!verifySGBDConnection())
                return;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;

            loadAllWorkoutsWithProgressToolStripMenuItem_Click(sender, e);
        }

        private void loadWorkoutExercises(object sender, EventArgs e,int entry_num)
        {
            if (!verifySGBDConnection())
                return;
            // arguments are workoutProgressID, num_athlete
            SqlCommand cmd = new SqlCommand("EXEC GetWorkoutExerciseProgressForAthlete @num_workout", cn);
            cmd.Parameters.AddWithValue("@num_workout", entry_num);
            //cmd.Parameters.AddWithValue("@num_workout", workoutProgressID);
            //cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);

            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {
                WorkoutExerciseProgressForAthlete we = new WorkoutExerciseProgressForAthlete();
                we.ExerciseProgressID = int.Parse(reader["ExerciseID"].ToString());
                we.ExerciseName = reader["ExerciseName"].ToString();
                we.ExerciseSetNumber = int.Parse(reader["SetNumber"].ToString());
                if (reader["Time"] == DBNull.Value){
                    we.ExerciseTime = 0;
                }else{
                    we.ExerciseTime = int.Parse(reader["Time"].ToString());
                }
                if (reader["RepsMade"] == DBNull.Value){
                    we.ExerciseRepsMade = 0;
                }else{
                    we.ExerciseRepsMade = int.Parse(reader["RepsMade"].ToString());
                }
                if (reader["WeightUsed"] == DBNull.Value){
                    we.ExerciseWeightUsed = 0;
                }else{
                    we.ExerciseWeightUsed = int.Parse(reader["WeightUsed"].ToString());
                }

                listBox2.Items.Add(we);
            }

            reader.Close();
            cn.Close();

            currentExercise = 0;
        }

        private void loadAllWorkoutsWithProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC GetAthleteWorkoutProgressRespData @num_athlete", cn);
            // it return these columns : WorkoutProgressID, WorkoutTitle, WorkoutPremium, WorkoutPTName
            cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                AthleteWorkoutProgressRespData wp = new AthleteWorkoutProgressRespData();
                wp.WorkoutProgressID = int.Parse(reader["WorkoutProgressID"].ToString());
                wp.WorkoutTitle = reader["WorkoutTitle"].ToString();
                wp.WorkoutPremium = int.Parse(reader["WorkoutPremium"].ToString());
                wp.WorkoutPTName = reader["WorkoutPTName"].ToString();

                listBox1.Items.Add(wp);
            }

            reader.Close();
            cn.Close();

            currentWorkout = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentWorkout = listBox1.SelectedIndex;
                textBox1.Text = ((AthleteWorkoutProgressRespData)listBox1.Items[currentWorkout]).WorkoutTitle;
                textBox2.Text = ((AthleteWorkoutProgressRespData)listBox1.Items[currentWorkout]).WorkoutPTName;
                string t = ((AthleteWorkoutProgressRespData)listBox1.Items[currentWorkout]).WorkoutPremium.ToString();
                textBox8.Text = t == "1" ? "Yes" : "No";
                ClearExerciseDetails();
                loadWorkoutExercises(sender, e, ((AthleteWorkoutProgressRespData)listBox1.Items[currentWorkout]).WorkoutProgressID);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentExercise = listBox2.SelectedIndex;
                ShowExerciseDetails();
            }
        }

        private void ShowExerciseDetails()
        {
            if (listBox2.Items.Count == 0 | currentExercise < 0)
                return;

            WorkoutExerciseProgressForAthlete we = (WorkoutExerciseProgressForAthlete)listBox2.Items[currentExercise];
            textBox3.Text = we.ExerciseName;
            textBox4.Text = we.ExerciseSetNumber.ToString();

            if (we.ExerciseTime == 0) {
                textBox5.Text = "";
                label8.Visible = false;
                textBox5.Visible = false;
            } else {
                textBox5.Visible = true;
                label8.Visible = true;
                textBox5.Text = we.ExerciseTime.ToString();
            }
            if (we.ExerciseRepsMade == 0) {
                textBox6.Text = "";
                label9.Visible = false;
                textBox6.Visible = false;
            } else {
                textBox6.Visible = true;
                label9.Visible = true;
                textBox6.Text = we.ExerciseRepsMade.ToString();
            }
            if (we.ExerciseWeightUsed == 0) {
                textBox7.Text = "";
                label10.Visible = false;
                textBox7.Visible = false;
            } else{
                label10.Visible = true;
                textBox7.Visible = true;
                textBox7.Text = we.ExerciseWeightUsed.ToString();
            }

        }

        private void ClearExerciseDetails()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
