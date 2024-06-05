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
using static System.Net.Mime.MediaTypeNames;

namespace PocketCoach
{
    public partial class Chat : Form
    {
        private SqlConnection cn;
        private int chat_num;
        public Chat()
        {
            InitializeComponent();
        }

        public void Chat_Load(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            if (!UserLogin.isPT)
            {
                txtReceiverName.Text = "Chatting with: *" + ChooseSomeoneToChat.name + "*";

                SqlCommand cmd = new SqlCommand("SELECT * FROM chat join message on chat.num_chat=message.chat_num WHERE athlete_num=@athlete_num and PT_num=@PT_num", cn);
                cmd.Parameters.AddWithValue("@athlete_num", UserLogin.athlete_num);
                cmd.Parameters.AddWithValue("@PT_num", ChooseSomeoneToChat.numPT);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sent_by_user = int.Parse(reader["sent_by_user"].ToString());
                    string text = reader["text"].ToString();
                    chat_num = int.Parse(reader["chat_num"].ToString());
                    int messagesLength = txtInMSG.TextLength;
                    if (sent_by_user == 1)
                    {
                        txtInMSG.AppendText(text + "\n");
                        txtInMSG.Select(messagesLength, text.Length + 1);

                        // Align the selected text to the right
                        txtInMSG.SelectionAlignment = HorizontalAlignment.Right;
                        txtInMSG.SelectionBackColor = Color.Green; // Change to the desired background color
                        txtInMSG.SelectionColor = Color.White; // Change to the desired text color


                    }
                    else
                    {
                        txtInMSG.AppendText(":>> " + text + "\n");
                        txtInMSG.Select(messagesLength, text.Length + 4);


                        // Align the selected text to the right
                        txtInMSG.SelectionAlignment = HorizontalAlignment.Left;
                        txtInMSG.SelectionBackColor = Color.Gray; // Change to the desired background color
                        txtInMSG.SelectionColor = Color.White; // Change to the desired text color


                    }
                    // Deselect the text
                    txtInMSG.SelectionLength = 0;
                }
                reader.Close();
                cn.Close();
            }
            else
            {
                txtReceiverName.Text = "Chatting with: *" + ChooseSomeoneToChat.name + "*";

                SqlCommand cmd = new SqlCommand("SELECT * FROM chat join message on chat.num_chat=message.chat_num WHERE athlete_num=@athlete_num and PT_num=@PT_num", cn);
                cmd.Parameters.AddWithValue("@athlete_num", ChooseSomeoneToChat.numAthlete);
                cmd.Parameters.AddWithValue("@PT_num", UserLogin.PTNum);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int sent_by_user = int.Parse(reader["sent_by_user"].ToString());
                    string text = reader["text"].ToString();
                    chat_num = int.Parse(reader["chat_num"].ToString());
                    int messagesLength = txtInMSG.TextLength;
                    if (sent_by_user == 1)
                    {
                        txtInMSG.AppendText(":>> "+text + "\n");
                        txtInMSG.Select(messagesLength, text.Length + 4);


                        // Align the selected text to the right
                        txtInMSG.SelectionAlignment = HorizontalAlignment.Left;
                        txtInMSG.SelectionBackColor = Color.Gray; // Change to the desired background color
                        txtInMSG.SelectionColor = Color.White; // Change to the desired text color
                        


                    }
                    else
                    {
                        txtInMSG.AppendText(text + "\n");
                        txtInMSG.Select(messagesLength, text.Length + 1);

                        // Align the selected text to the right
                        txtInMSG.SelectionAlignment = HorizontalAlignment.Right;
                        txtInMSG.SelectionBackColor = Color.Green; // Change to the desired background color
                        txtInMSG.SelectionColor = Color.White; // Change to the desired text color

                    }
                    // Deselect the text
                    txtInMSG.SelectionLength = 0;
                }
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






        private void bttnSend_Click(object sender, EventArgs e)
        {

            int num_msg = GetMaxNumMsg() + 1;
            string text = txtMSG.Text;

            if (!verifySGBDConnection())
                return;
            if (!UserLogin.isPT)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO message VALUES(@num_msg,@chat_num,@sent_by_user,@text)", cn);
                cmd.Parameters.AddWithValue("@num_msg", num_msg);
                cmd.Parameters.AddWithValue("@chat_num", chat_num);      
                cmd.Parameters.AddWithValue("@sent_by_user", 1);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.ExecuteNonQuery();

                int messagesLength = txtInMSG.TextLength;
                txtInMSG.AppendText(text + "\n");
                txtInMSG.Select(messagesLength, text.Length + 1);

                // Align the selected text to the right
                txtInMSG.SelectionAlignment = HorizontalAlignment.Right;
                txtInMSG.SelectionBackColor = Color.Green; // Change to the desired background color
                txtInMSG.SelectionColor = Color.White; // Change to the desired text color
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO message VALUES(@num_msg,@chat_num,@sent_by_user,@text)", cn);
                cmd.Parameters.AddWithValue("@num_msg", num_msg);
                cmd.Parameters.AddWithValue("@chat_num", chat_num);      
                cmd.Parameters.AddWithValue("@sent_by_user", 0);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.ExecuteNonQuery();

                int messagesLength = txtInMSG.TextLength;
                txtInMSG.AppendText(text + "\n");
                txtInMSG.Select(messagesLength, text.Length + 1);

                // Align the selected text to the right
                txtInMSG.SelectionAlignment = HorizontalAlignment.Right;
                txtInMSG.SelectionBackColor = Color.Green; // Change to the desired background color
                txtInMSG.SelectionColor = Color.White; // Change to the desired text color
            }
            

            txtMSG.Text = "";



            cn.Close();



        }

        private int GetMaxNumMsg()
        {
            if (!verifySGBDConnection())
                return 0;

            int maxNumMsg = 0;
            SqlCommand cmd = new SqlCommand("SELECT MAX(num_msg) AS max_msg FROM message", cn);
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                try
                {
                    maxNumMsg = int.Parse(reader["max_msg"].ToString());
                }
                catch
                {
                    maxNumMsg = 0;
                }
            }
            reader.Close();
            cn.Close();

            return maxNumMsg;
        }


        private void txtReceiverName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInMSG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMSG_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnBackToMenu_Click(object sender, EventArgs e)
        {
            if (!UserLogin.isPT)
            {
                Form atMenu = new AthleteMenu();
                atMenu.Show();
                this.Hide();
            }
            else
            {
                Form PTMenu = new PersonalTrainerMenu();
                PTMenu.Show();
                this.Hide();
            }
        }
    }
}
