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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PocketCoach
{
    public partial class ChooseSomeoneToChat : Form
    {
        private SqlConnection cn;
        private int currentPerson;
        public static int numPT;
        public static int numAthlete;
        public static string name;
        public static int chat_num; 

        public ChooseSomeoneToChat()
        {
            InitializeComponent();
        }

        public void ChooseSomeoneToChat_Load(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            if(!UserLogin.isPT)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM subscription join personal_trainer on subscription.num_PT=personal_trainer.num_PT WHERE num_athlete=@num_athlete", cn);
                cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox1.Items.Clear();

                while (reader.Read())
                {
                    PersonalTrainer pt = new PersonalTrainer();
                    pt.NumPT = int.Parse(reader["num_PT"].ToString());
                    pt.Name = reader["name"].ToString();
                    pt.Description = reader["description"].ToString();
                    pt.Tags = reader["tags"].ToString();
                    pt.Photo = reader["photo"].ToString();
                    pt.Price = int.Parse(reader["price"].ToString());
                    pt.Slots = int.Parse(reader["slots"].ToString());
                    listBox1.Items.Add(pt);
                }
                currentPerson = 0;
                reader.Close();
                cn.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM subscription join athlete on subscription.num_athlete=athlete.num_athlete WHERE num_PT=@num_PT", cn);
                cmd.Parameters.AddWithValue("@num_PT", UserLogin.PTNum);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox1.Items.Clear();

                while (reader.Read())
                {
                    Athlete at = new Athlete();
                    at.NumAthlete = int.Parse(reader["num_athlete"].ToString());
                    at.Name = reader["name"].ToString();
                    listBox1.Items.Add(at);
                }
                currentPerson = 0;
                reader.Close();
                cn.Close();
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
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentPerson = listBox1.SelectedIndex;
            }
        }

        public void bttnChat_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            if (!UserLogin.isPT)
            {
                PersonalTrainer pt = (PersonalTrainer)listBox1.Items[currentPerson];
                numPT = pt.NumPT;
                name = pt.Name;


                SqlCommand cmd = new SqlCommand("SELECT * FROM chat WHERE athlete_num=@athlete_num and PT_num=@PT_num", cn);
                cmd.Parameters.AddWithValue("@athlete_num", UserLogin.athlete_num);
                cmd.Parameters.AddWithValue("@PT_num", numPT);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chat_num = int.Parse(reader["num_chat"].ToString());
                }
            }
            else
            {
                Athlete at = (Athlete)listBox1.Items[currentPerson];
                numAthlete = at.NumAthlete;
                name = at.Name;

                SqlCommand cmd = new SqlCommand("SELECT * FROM chat WHERE athlete_num=@athlete_num and PT_num=@PT_num", cn);
                cmd.Parameters.AddWithValue("@athlete_num", numAthlete);
                cmd.Parameters.AddWithValue("@PT_num", UserLogin.PTNum);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chat_num = int.Parse(reader["num_chat"].ToString());
                }
            }
            

            Form chat = new Chat();
            chat.Show();
            this.Hide();


        }
    }
}
