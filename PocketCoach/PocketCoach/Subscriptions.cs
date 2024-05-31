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
    public partial class Subscriptions : Form
    {
        private SqlConnection cn;
        private int currentPT;

        public Subscriptions()
        {
            InitializeComponent();
        }

        private void Subscriptions_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();
            if (!verifySGBDConnection())
                return;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            loadAllPTsNotSubscribed(sender, e);
            loadSubscriptionsToolStripMenuItem_Click(sender, e);
        }

        private void loadAllPTsNotSubscribed(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM personal_trainer WHERE num_PT NOT IN (SELECT num_PT FROM subscription WHERE num_athlete=@num_athlete)", cn);
            cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

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

                listBox2.Items.Add(pt);
            }

            reader.Close();
            cn.Close();

            currentPT = 0;
        }

        private void loadSubscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM subscription join personal_trainer on subscription.num_PT=personal_trainer.num_PT WHERE num_athlete=@num_athlete", cn);
            cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["name"].ToString());
            }

            reader.Close();
            cn.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentPT = listBox2.SelectedIndex;
                ShowPTDetails();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void ShowPTDetails()
        {
            if (listBox2.Items.Count == 0 | currentPT < 0)
                return;

            PersonalTrainer pt = (PersonalTrainer)listBox2.Items[currentPT];
            textBox1.Text = pt.Name;
            textBox2.Text = pt.Description;
            textBox3.Text = pt.Tags;
            textBox4.Text = pt.Price.ToString();
            textBox5.Text = pt.Slots.ToString();
            pictureBox1.ImageLocation = pt.Photo;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)          // Top3CheapestPTs Button
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Top3CheapestPTs", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

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

                // show PT in the list with title
                listBox2.Items.Add(pt);
            }

            reader.Close();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            loadSubscriptionsToolStripMenuItem_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // subscribe athlete to PT selected
            if (!verifySGBDConnection())
                return;

            PersonalTrainer pt = (PersonalTrainer)listBox2.Items[currentPT];
            SqlCommand cmd = new SqlCommand("INSERT INTO subscription VALUES (@num_athlete, @num_PT)", cn);
            cmd.Parameters.AddWithValue("@num_athlete", UserLogin.athlete_num);
            cmd.Parameters.AddWithValue("@num_PT", pt.NumPT);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Subscribed Successfully!");
                listBox2.Items.Remove(pt);
                listBox1.Items.Add(pt.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sem slots disponíveis para este Personal Trainer.");
            }

            cn.Close();

        }

        private void bttnGoBack_Click(object sender, EventArgs e)
        {
            Form menu = new AthleteMenu();
            menu.Show();
            this.Close();
        }
    }
}
