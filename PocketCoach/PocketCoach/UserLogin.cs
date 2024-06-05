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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PocketCoach
{
    public partial class UserLogin : Form
    {
        public static SqlConnection cn;
        public static int athlete_num;
        public static bool isPT;
        public static int PTNum;
        public UserLogin()
        {
            InitializeComponent();


        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            isPT = false;
        }


        public static SqlConnection getSGBDConnection()
        {

            SqlConnection cn = getprivSGBDConnection();
            return cn;
        }

        private static SqlConnection getprivSGBDConnection()
        {
            //return new SqlConnection("data source= LAPTOP-5HIDEPJS\\SQLEXPRESS;integrated security=true;initial catalog=PocketCoach;");
            return new SqlConnection("Data Source =tcp:mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog =p7g6; uid = p7g6; password = BDgahe2003");

        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked)
            {
                isPT = true;
            }
            else
            {
                isPT = false;
            }
        }

        private void bttnSelect_Click(object sender, EventArgs e)
        {

            if (isPT)
            {
                PTNum = LoginPT();
                if(PTNum != -1)
                {
                    Form form2 = new PersonalTrainerMenu();
                    form2.Show();
                    this.Hide();
                }
                
            }
            else
            {
                athlete_num = LoginAthlete();
                if(athlete_num != -1 )
                {
                    Form athleteMenu = new AthleteMenu();
                    athleteMenu.Show();
                    this.Hide();
                }
                
            }
        }
        public int LoginPT()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Unable to connect to database");
                return -1;
            }
               
            SqlCommand cmd = new SqlCommand("SELECT num_PT FROM personal_trainer WHERE name=@name and password=@password", cn);
            cmd.Parameters.AddWithValue("@name", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password",txtPassword.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                PTNum = int.Parse(reader["num_PT"].ToString());
            }
            else
            {
                reader.Close();
                MessageBox.Show("Wrong username or password");
                return -1;

            }
            reader.Close();

            cn.Close();
            return PTNum;
        }

        public int LoginAthlete()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Unable to connect to database");
                return -1;
            }
            SqlCommand cmd = new SqlCommand("SELECT num_athlete FROM athlete WHERE name=@name and password=@password", cn);
            cmd.Parameters.AddWithValue("@name", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                athlete_num = int.Parse(reader["num_athlete"].ToString());
            }
            else
            {
                reader.Close();
                MessageBox.Show("Wrong username or password");
                return -1;
                
            }
            reader.Close();

            cn.Close();
            return athlete_num;
        }




        private void txtAthleteNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPTNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)   // Athlete Number
        {

        }

        private void label2_Click(object sender, EventArgs e) // Personal Trainer Number
        {

        }
    }
}
