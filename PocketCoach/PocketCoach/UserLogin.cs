using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCoach
{
    public partial class UserLogin : Form
    {
        public static int athleteNum;
        public static bool isPT;
        public static int PTNum;
        public UserLogin()
        {
            InitializeComponent();
            txtPTNum.ReadOnly = true;

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                isPT = true;
                txtAthleteNum.Text = "";
                txtAthleteNum.ReadOnly = true;
                txtPTNum.ReadOnly = false;
            }
            else
            {
                isPT = false;
                txtPTNum.Text = "";
                txtAthleteNum.ReadOnly = false;
                txtPTNum.ReadOnly = true;
            }
        }

        private void txtAthleteNum_TextChanged(object sender, EventArgs e)
        {
            if(!isPT)
            {
                athleteNum = int.Parse(txtAthleteNum.Text);
            }
        }

        private void txtPTNum_TextChanged(object sender, EventArgs e)
        {
            if(isPT)
            {
                PTNum = int.Parse(txtPTNum.Text);

            }
        }

        private void bttnSelect_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }





        private void label1_Click(object sender, EventArgs e)   // Athlete Number
        {

        }

        private void label2_Click(object sender, EventArgs e) // Personal Trainer Number
        {

        }
    }
}
