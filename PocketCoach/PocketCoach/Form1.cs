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
    public partial class Form1 : Form
    {

        private SqlConnection cn;
        private int currentProgress;
        //private bool adding;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            loadRepsProgressToolStripMenuItem_Click(sender, e);
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void loadRepsProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM reps_progress", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                RepsProgress progress = new RepsProgress();
                progress.EntryNum = int.Parse(reader["entry_num"].ToString());
                int numEx;
                if (int.TryParse(reader["num_ex"].ToString(), out numEx))
                {
                    progress.NumEx = numEx;
                }
                else
                {
                    // Conversion failed, handle the error or use a default value
                }

                progress.SetNum = int.Parse(reader["set_num"].ToString());
                progress.RepsMade = int.Parse(reader["reps_made"].ToString());
                progress.WeightUsed = int.Parse(reader["weight_used"].ToString());
                listBox1.Items.Add(progress);

                /*
                C.CustomerID = reader["CustomerID"].ToString();
                C.CompanyName = reader["CompanyName"].ToString();
                C.ContactName = reader["ContactName"].ToString();
                C.Address1 = reader["Address"].ToString();
                C.City = reader["City"].ToString();
                C.State = reader["Region"].ToString();
                C.ZIP = reader["PostalCode"].ToString();
                C.Country = reader["Country"].ToString();
                C.Phone = reader["Phone"].ToString();
                C.Fax = reader["Fax"].ToString();
                listBox1.Items.Add(C);
                */


            }

            cn.Close();


            currentProgress = 0;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentProgress = listBox1.SelectedIndex;
                ShowRepsProgress();
            }
        }

        public void ShowRepsProgress()
        {
            if (listBox1.Items.Count == 0 | currentProgress < 0)
                return;
            RepsProgress progress = new RepsProgress();
            progress = (RepsProgress)listBox1.Items[currentProgress];
            entry_num.Text = progress.EntryNum.ToString();
            num_ex.Text = progress.NumEx.ToString();
            set_num.Text = progress.SetNum.ToString();
            num_reps.Text = progress.RepsMade.ToString();
            weight_used.Text = progress.WeightUsed.ToString();

            if (!verifySGBDConnection())
                return;

            try
            {
                //MessageBox.Show("num_ex: " + num_ex.Text);
                SqlCommand cmd = new SqlCommand("SELECT path FROM exercise WHERE num_ex=@num_ex", cn);
                cmd.Parameters.AddWithValue("@num_ex", num_ex.Text);
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

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            /*
            txtID.Text = contact.CustomerID;
            txtCompany.Text = contact.CompanyName;
            txtContact.Text = contact.ContactName;
            txtAddress1.Text = contact.Address1;
            txtCity.Text = contact.City;
            txtState.Text = contact.State;
            txtZIP.Text = contact.ZIP;
            txtCountry.Text = contact.Country;
            txtTel.Text = contact.Phone;
            txtFax.Text = contact.Fax;
            */
            cn.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Form2 form2 = new Form2();

            // Show Form2 and hide the current form
            form2.Show();
            this.Hide(); // Optional: Hide the current form
        }

        /*
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM exercise_progress", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                ExerciseProgress progress = new ExerciseProgress();
                int entryNum;
                if (int.TryParse(reader["EntryNum"].ToString(), out entryNum))
                {
                    progress.EntryNum = entryNum;
                }
                else
                {
                    // Conversion failed, handle the error or use a default value
                }
                
                progress.AthleteNum = int.Parse(reader["AthleteNum"].ToString());
                progress.Date = reader["Date"].ToString();
                listBox1.Items.Add(progress);


                /*
                C.CustomerID = reader["CustomerID"].ToString();
                C.CompanyName = reader["CompanyName"].ToString();
                C.ContactName = reader["ContactName"].ToString();
                C.Address1 = reader["Address"].ToString();
                C.City = reader["City"].ToString();
                C.State = reader["Region"].ToString();
                C.ZIP = reader["PostalCode"].ToString();
                C.Country = reader["Country"].ToString();
                C.Phone = reader["Phone"].ToString();
                C.Fax = reader["Fax"].ToString();
                listBox1.Items.Add(C);
                
            }

            cn.Close();


            //currentContact = 0;
            //ShowContact();
        }
        */

    }
}
