namespace PocketCoach
{
    partial class UserLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBox1 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            bttnSelect = new Button();
            label4 = new Label();
            bttnRegister = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(121, 158);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(120, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Is Personal Trainer";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 74);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Username";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 118);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(141, 71);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 4;
            txtUsername.TextChanged += txtAthleteNum_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(141, 115);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += txtPTNum_TextChanged;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(141, 201);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(75, 23);
            bttnSelect.TabIndex = 6;
            bttnSelect.Text = "Login";
            bttnSelect.UseVisualStyleBackColor = true;
            bttnSelect.Click += bttnSelect_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(131, 286);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 7;
            label4.Text = "Not regitered yet?";
            // 
            // bttnRegister
            // 
            bttnRegister.Location = new Point(141, 304);
            bttnRegister.Name = "bttnRegister";
            bttnRegister.Size = new Size(75, 23);
            bttnRegister.TabIndex = 8;
            bttnRegister.Text = "Register";
            bttnRegister.UseVisualStyleBackColor = true;
            bttnRegister.Click += bttnRegister_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 339);
            Controls.Add(bttnRegister);
            Controls.Add(label4);
            Controls.Add(bttnSelect);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Name = "UserLogin";
            Text = "Select user";
            Load += UserLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox textBox3;
        private Button bttnSelect;
        private Label label4;
        private Button bttnRegister;
    }
}