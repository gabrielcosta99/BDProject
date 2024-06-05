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
    public partial class PersonalTrainerMenu : Form
    {
        private SqlConnection cn;

        public PersonalTrainerMenu()
        {
            InitializeComponent();
        }

        private void PersonalTrainerMenu_Load(object sender, EventArgs e)
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

        private void bttnCreateWorkout_Click(object sender, EventArgs e)
        {
            Form workoutCreate = new CreateWorkout();
            workoutCreate.Show();
            this.Hide();
        }

        private void bttnChat_Click(object sender, EventArgs e)
        {
            Form chat = new ChooseSomeoneToChat();
            chat.Show();
            this.Hide();

        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form exerciseCreate = new CreateExercise();
            exerciseCreate.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete your account?", "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM personal_trainer WHERE num_PT=@num_PT;";
                cmd.Parameters.AddWithValue("@num_PT", UserLogin.PTNum);
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
