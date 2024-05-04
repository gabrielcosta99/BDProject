namespace PocketCoach
{
    partial class DBLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtServerName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            bttnLogin = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 60);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Server";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 107);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "User";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 164);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Password";
            label3.Click += label3_Click;
            // 
            // txtServerName
            // 
            txtServerName.ForeColor = Color.Yellow;
            txtServerName.Location = new Point(136, 57);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(396, 23);
            txtServerName.TabIndex = 3;
            txtServerName.TextChanged += textBox1_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(136, 104);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(396, 23);
            txtUsername.TabIndex = 4;
            txtUsername.TextChanged += textBox2_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.HideSelection = false;
            txtPassword.Location = new Point(136, 161);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(396, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += textBox3_TextChanged;
            // 
            // bttnLogin
            // 
            bttnLogin.Location = new Point(136, 243);
            bttnLogin.Name = "bttnLogin";
            bttnLogin.Size = new Size(169, 68);
            bttnLogin.TabIndex = 6;
            bttnLogin.Text = "Login";
            bttnLogin.UseVisualStyleBackColor = true;
            bttnLogin.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(337, 243);
            button2.Name = "button2";
            button2.Size = new Size(195, 68);
            button2.TabIndex = 7;
            button2.Text = "Hello Table";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DBLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 362);
            Controls.Add(button2);
            Controls.Add(bttnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtServerName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DBLogin";
            Text = "Login to database";
            Load += DBLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtServerName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button bttnLogin;
        private Button button2;
    }
}
