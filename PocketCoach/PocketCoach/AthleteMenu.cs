using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PocketCoach
{
    public partial class AthleteMenu : Form
    {
        private SqlConnection cn;

        public AthleteMenu()
        {
            InitializeComponent();
        }

        private void AthleteMenu_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void bttnSubscriptions_Click(object sender, EventArgs e)
        {
            Form subscriptions = new Subscriptions();
            subscriptions.Show();
            this.Hide();
        }

        private void bttnWorkouts_Click(object sender, EventArgs e)
        {
            Form workouts = new Workouts();
            workouts.Show();
            this.Hide();
        }


        private void bttnMyProgress_Click(object sender, EventArgs e)
        {
            Form progress = new AthleteWorkoutProgress();
            progress.Show();
            this.Hide();
        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void bttnChat_Click(object sender, EventArgs e)
        {
            Form choosePT = new ChooseSomeoneToChat();
            choosePT.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete your account?", "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM athlete WHERE num_athlete=@num_athlete;";
                cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
                
                MessageBox.Show("Account deleted successfully");

                Form userLogin = new UserLogin();
                userLogin.Show();
                this.Hide();
            }
        }
    }
}
