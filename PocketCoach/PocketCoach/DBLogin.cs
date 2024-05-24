using System.Data;
using System.Data.SqlClient;    // TIVE DE ACRESCENTAR ESTE IMPORT E, PRIMEIRAMENTE, TIVE DE INSTALÁ-LO

namespace PocketCoach
{
    public partial class DBLogin : Form
    {

        public static SqlConnection cn;
        private static string dbServer, dbName,userName, userPass;

        public DBLogin()
        {
            InitializeComponent();
        }

        
        private void DBLogin_Load(object sender, EventArgs e)
        {
            txtServerName.Text = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
            txtServerName.ReadOnly = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)   //server
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   //username
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)   //password
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static SqlConnection getSGBDConnection()
        {
            SqlConnection cn = getprivSGBDConnection(dbServer, dbName, userName, userPass);
            return cn;
        }

        private static SqlConnection getprivSGBDConnection(string  dbServer, string dbName, string userName, string userPass)
        {
            //return new SqlConnection("data source= LAPTOP-5HIDEPJS\\SQLEXPRESS;integrated security=true;initial catalog=PocketCoach;");
            return new SqlConnection("Data Source =" + dbServer + ";" + "Initial Catalog =" + dbName + "; uid = p7g6; password = BDgahe2003");

        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)

                try
                {
                    cn.Open();
                    if (cn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Successful connection to database " + cn.Database + " on the " + cn.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
                }

            return cn.State == ConnectionState.Open;
        }







        private void button1_Click(object sender, EventArgs e)  //  Login button
        {
            dbServer = txtServerName.Text;
            dbName = "p7g6";
            userName = txtUsername.Text;
            userPass = txtPassword.Text;
            cn = getprivSGBDConnection(dbServer, dbName, userName, userPass);
            if( verifySGBDConnection() ) {
                Form userLogin = new UserLogin();
                userLogin.Show();
                this.Hide();
            }
        }

    }
}
