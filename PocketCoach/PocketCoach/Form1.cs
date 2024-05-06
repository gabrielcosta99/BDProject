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
        private bool adding;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = DBLogin.getSGBDConnection();
            loadRepsProgressToolStripMenuItem_Click(sender, e);
            ShowButtons();
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
                cn = DBLogin.getSGBDConnection();

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
                progress.NumEx = int.Parse(reader["num_ex"].ToString());
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
            txtEntryNum.Text = progress.EntryNum.ToString();
            txtNumEx.Text = progress.NumEx.ToString();
            txtSetNum.Text = progress.SetNum.ToString();
            txtRepsMade.Text = progress.RepsMade.ToString();
            txtWeightUsed.Text = progress.WeightUsed.ToString();

            if (!verifySGBDConnection())
                return;

            try
            {
                //MessageBox.Show("num_ex: " + num_ex.Text);
                SqlCommand cmd = new SqlCommand("SELECT path FROM exercise WHERE num_ex=@num_ex", cn);
                cmd.Parameters.AddWithValue("@num_ex", txtNumEx.Text);
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



        public void LockControls()
        {
            txtEntryNum.ReadOnly = true;
            txtNumEx.ReadOnly = true;
            txtSetNum.ReadOnly = true;
            txtRepsMade.ReadOnly = true;
            txtWeightUsed.ReadOnly = true;
        }

        public void UnlockControls()
        {
            txtEntryNum.ReadOnly = false;
            txtNumEx.ReadOnly = false;
            txtSetNum.ReadOnly = false;
            txtRepsMade.ReadOnly = false;
            txtWeightUsed.ReadOnly = false;
        }

        public void HideButtons()
        {
            UnlockControls();
            bttnAdd.Visible = false;
            bttnDelete.Visible = false;
            bttnEdit.Visible = false;
            bttnConfirm.Visible = true;
            bttnCancel.Visible = true;
        }
        
        public void ShowButtons()
        {
            LockControls();
            bttnAdd.Visible = true;
            bttnDelete.Visible = true;
            bttnEdit.Visible = true;
            bttnConfirm.Visible = false;
            bttnCancel.Visible = false;
        }

        public void ClearFields()
        {
            txtEntryNum.Text = "";
            txtNumEx.Text = "";
            txtSetNum.Text = "";
            txtRepsMade.Text = "";
            txtWeightUsed.Text = "";
        }

        private void SubmitRepsProgress(RepsProgress progress)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO reps_progress " + "VALUES (@entry_num, @num_ex, @set_num, @reps_made, " + "@weight_used) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@reps_made", progress.RepsMade);
            cmd.Parameters.AddWithValue("@weight_used", progress.WeightUsed);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void UpdateRepsProgress(RepsProgress progress)
        {
            int rows = 0;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE reps_progress " + "SET num_ex = @num_ex, " + "    set_num = @set_num, " + "    reps_made = @reps_made, " + "    weight_used = @weight_used " + "WHERE entry_num = @entry_num";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num_ex", progress.NumEx);
            cmd.Parameters.AddWithValue("@set_num", progress.SetNum);
            cmd.Parameters.AddWithValue("@reps_made", progress.RepsMade);
            cmd.Parameters.AddWithValue("@weight_used", progress.WeightUsed);
            cmd.Parameters.AddWithValue("@entry_num", progress.EntryNum);

            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database.\n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Update OK");
                else
                    MessageBox.Show("Update NOT OK");

                cn.Close();
            }
        }
        private bool SaveRepsProgress()
        {
            RepsProgress progress = new RepsProgress();
            try
            {
                progress.EntryNum = int.Parse(txtEntryNum.Text);
                progress.NumEx = int.Parse(txtNumEx.Text);
                progress.SetNum = int.Parse(txtSetNum.Text);
                progress.RepsMade = int.Parse(txtRepsMade.Text);
                progress.WeightUsed = int.Parse(txtWeightUsed.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            if (adding)
            {
                SubmitRepsProgress(progress);
                listBox1.Items.Add(progress);
            }
            else
            {
                UpdateRepsProgress(progress);
                listBox1.Items[currentProgress] = progress;
            }
            return true;
        }



        private void bttnConfirm_Click(object sender, EventArgs e)  // Confirm button
        {
            try
            {
                SaveRepsProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBox1.Enabled = true;
            int idx = listBox1.FindString(txtEntryNum.Text);
            listBox1.SelectedIndex = idx;
            ShowButtons();
        }

        private void bttnPlay_Click(object sender, EventArgs e)  // Play button
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

        private void bttnCancel_Click(object sender, EventArgs e)  // Cancel button
        {
            listBox1.Enabled = true;
            if (listBox1.Items.Count > 0)
            {
                currentProgress = listBox1.SelectedIndex;
                if (currentProgress < 0)
                    currentProgress = 0;
                ShowRepsProgress();
            }
            else
            {
                ClearFields();
                LockControls();
            }
            ShowButtons();
        }



        private void button3_Click(object sender, EventArgs e)  // form2 button
        {
            // Create an instance of Form2
            Form2 form2 = new Form2();

            //this.Hide();
            // Show Form2
            form2.Show();
            
            
        }

        private void bttnAdd_Click(object sender, EventArgs e)  //add button
        {
            adding = true;
            ClearFields();
            HideButtons();
            listBox1.Enabled = false;
        }

        private void bttnEdit_Click(object sender, EventArgs e)  // edit button
        {
            currentProgress = listBox1.SelectedIndex;
            if (currentProgress < 0)
            {
                MessageBox.Show("Please select a contact to edit");
                return;
            }
            adding = false;
            HideButtons();
            listBox1.Enabled = false;
        }


        private void RemoveRepsProgress(int EntryNum)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM reps_progress WHERE entry_num=@entry_num", cn);
            cmd.Parameters.AddWithValue("@entry_num", EntryNum);
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        private void bttnDelete_Click(object sender, EventArgs e)  // delete button
        {
            

            if (listBox1.SelectedIndex > -1)
            {
                try
                {
                    RemoveRepsProgress(((RepsProgress)listBox1.SelectedItem).EntryNum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (currentProgress == listBox1.Items.Count)
                    currentProgress = listBox1.Items.Count - 1;
                if (currentProgress == -1)
                {
                    ClearFields();
                    MessageBox.Show("There are no more contacts");
                }
                else
                {
                    ShowRepsProgress();
                }
            }
            
        }


    }
}
