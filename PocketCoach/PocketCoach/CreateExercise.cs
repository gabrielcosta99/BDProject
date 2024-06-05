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
    public partial class CreateExercise : Form
    {
        private SqlConnection cn;
        string videoPath;
        string filename;
        Boolean isTime = false;

        public CreateExercise()
        {
            InitializeComponent();
        }

        private void CreateExercise_Load(object sender, EventArgs e)
        {
            cn = UserLogin.getSGBDConnection();
            textBox4.ReadOnly = true;
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = UserLogin.getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp4",
                Filter = "MP4 files (*.mp4)|*.mp4",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoPath = @"../../../../../videos/" + openFileDialog1.SafeFileName;
                filename = openFileDialog1.FileName;
                textBox4.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM exercise WHERE num_ex=(SELECT MAX(num_ex) FROM exercise);";
                cmd.Connection = cn;
                SqlDataReader reader = cmd.ExecuteReader();
                int num_exercise = 1;

                if (reader.Read())
                {
                    num_exercise = int.Parse(reader["num_ex"].ToString()) + 1;
                }
                reader.Close();
                cn.Close();

                cn.Open();
                if (!verifySGBDConnection())
                    return;

                string date = DateTime.Now.ToString("yyyy-MM-dd");

                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO exercise(num_ex,path,name,description,muscletargets,releasedate,PT_num,thumbnail,is_time) " + "VALUES (@num_ex,@path,@name,@description,@muscletargets,@releasedate,@PT_num,@thumbnail,@is_time)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@num_ex", num_exercise);
                cmd.Parameters.AddWithValue("@path", videoPath);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@description", textBox2.Text);
                cmd.Parameters.AddWithValue("@muscletargets", textBox3.Text);
                cmd.Parameters.AddWithValue("@releasedate", date);
                cmd.Parameters.AddWithValue("@PT_num", UserLogin.PTNum);
                cmd.Parameters.AddWithValue("@thumbnail", "");
                cmd.Parameters.AddWithValue("@is_time", isTime ? 1 : 0);
                cmd.Connection = cn;
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create exercise in database. \n ERROR MESSAGE: \n" + ex.Message);
                }

                System.IO.File.Copy(filename, videoPath);
                MessageBox.Show("Exercise created successfully");

                cn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked)
            {
                isTime = true;
            }
            else
            {
                isTime = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form menu = new PersonalTrainerMenu();
            menu.Show();
            this.Close();
        }
    }
}
