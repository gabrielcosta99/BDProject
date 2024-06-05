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
using System.Drawing;

namespace PocketCoach
{
    public partial class Register : Form
    {
        private SqlConnection cn;
        private bool registeringPT;
        private string savedImagePath="";


        public Register()
        {
            InitializeComponent();
            txtPrice.KeyPress += TxtPrice_KeyPress;
            txtSlots.KeyPress += TxtSlots_KeyPress;
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtSlots_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            registeringPT = false;
            txtDescription.Visible = false;
            txtTags.Visible = false;
            txtPrice.Visible = false;
            txtSlots.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            bttnRegisterAsPT.Visible = true;
            bttnRegisterAsAthlete.Visible = false;
            bttnUploadPhoto.Visible = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTags_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSlots_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnRegisterAsPT_Click(object sender, EventArgs e)
        {
            registeringPT = true;
            txtDescription.Visible = true;
            txtTags.Visible = true;
            txtPrice.Visible = true;
            txtSlots.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            bttnRegisterAsPT.Visible = false;
            bttnRegisterAsAthlete.Visible = true;
            bttnUploadPhoto.Visible = true;
        }

        private void bttnRegisterAsAthlete_Click(object sender, EventArgs e)
        {
            registeringPT = false;
            txtDescription.Visible = false;
            txtTags.Visible = false;
            txtPrice.Visible = false;
            txtSlots.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;


            bttnRegisterAsPT.Visible = true;
            bttnRegisterAsAthlete.Visible = false;
            bttnUploadPhoto.Visible = false;
        }

        private void bttnRegister_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (registeringPT)
            {
                if (!int.TryParse(txtPrice.Text, out int price))
                {
                    MessageBox.Show("Price must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtSlots.Text, out int slots))
                {
                    MessageBox.Show("Slots must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                int num_PT = GetMaxEntryNum("num_PT", "personal_trainer") + 1;

                if (!verifySGBDConnection())
                {
                    return;
                }
                if (image1.ImageLocation != null)
                {
                    savedImagePath = SaveImageToFolder(image1.ImageLocation);

                }
                //MessageBox.Show("Image uploaded successfully! "+ savedImagePath);
                SqlCommand cmd = new SqlCommand("INSERT INTO personal_trainer VALUES(@num_PT,@name,@password,@description,@tags,@photo,@price,@slots)", cn);
                cmd.Parameters.AddWithValue("@num_PT", num_PT);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@tags", txtTags.Text);
                cmd.Parameters.AddWithValue("@photo", savedImagePath);
                cmd.Parameters.AddWithValue("@price", int.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@slots", int.Parse(txtPrice.Text));



                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration complete successfully!");
            }
            else
            {
                int num_PT = GetMaxEntryNum("num_athlete", "athlete") + 1;
                if (!verifySGBDConnection())
                {
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO athlete VALUES(@num_athlete,@name,@password)", cn);
                cmd.Parameters.AddWithValue("@num_athlete", num_PT);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration complete successfully!");
            }

            Form login = new UserLogin();
            login.Show();
            this.Close();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private int GetMaxEntryNum(string entry, string tableName)
        {
            if (!verifySGBDConnection())
                return 0;

            int maxEntryNum = 0;
            SqlCommand cmd = new SqlCommand($"SELECT MAX({entry}) AS max_entry_num FROM {tableName}", cn);
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                try
                {
                    maxEntryNum = int.Parse(reader["max_entry_num"].ToString());
                }
                catch
                {
                    maxEntryNum = 0;
                }
            }
            reader.Close();
            cn.Close();

            return maxEntryNum;
        }

        private void bttnUploadPhoto_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    Image originalImage = Image.FromFile(imageLocation);
                    Image resizedImage = ResizeImage(originalImage, image1.Width, image1.Height);
                    image1.Image = resizedImage;
                    image1.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Ocurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Image ResizeImage(Image imgToResize, int width, int height)
        {
            return (Image)(new Bitmap(imgToResize, new Size(width, height)));
        }

        private string SaveImageToFolder(string sourceFilePath)
        {
            // Specify the directory where you want to save the images
            string targetDirectory = @"..\..\..\..\..\imgs"; // Change this to your desired folder path
            
            // Generate a unique file name
            string fileName = Path.GetFileName(sourceFilePath);
            //MessageBox.Show("here1 "+fileName);
            string targetFilePath = Path.Combine(targetDirectory, txtName.Text+".jpg");
            //MessageBox.Show("here2");

            // Copy the file to the target directory
            //MessageBox.Show(sourceFilePath+" :::: "+targetFilePath);

            File.Copy(sourceFilePath, targetFilePath, true);

            return targetFilePath;
        }

        private void image1_Click(object sender, EventArgs e)
        {

        }
    }
}
