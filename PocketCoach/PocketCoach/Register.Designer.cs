namespace PocketCoach
{
    partial class Register
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
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtDescription = new RichTextBox();
            label4 = new Label();
            txtTags = new TextBox();
            label5 = new Label();
            txtPrice = new TextBox();
            label6 = new Label();
            txtSlots = new TextBox();
            bttnRegisterAsPT = new Button();
            bttnRegisterAsAthlete = new Button();
            bttnRegister = new Button();
            label7 = new Label();
            image1 = new PictureBox();
            bttnUploadPhoto = new Button();
            ((System.ComponentModel.ISupportInitialize)image1).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(182, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 40);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 1;
            label1.Text = "name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 69);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "password";
            label2.Click += label2_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(182, 66);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 95);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(182, 95);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(100, 96);
            txtDescription.TabIndex = 6;
            txtDescription.Text = "";
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(138, 212);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 8;
            label4.Text = "tags";
            // 
            // txtTags
            // 
            txtTags.Location = new Point(182, 209);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(100, 23);
            txtTags.TabIndex = 7;
            txtTags.TextChanged += txtTags_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(138, 367);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 10;
            label5.Text = "price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(182, 364);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(36, 23);
            txtPrice.TabIndex = 9;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(138, 396);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 12;
            label6.Text = "slots";
            // 
            // txtSlots
            // 
            txtSlots.Location = new Point(182, 393);
            txtSlots.Name = "txtSlots";
            txtSlots.Size = new Size(36, 23);
            txtSlots.TabIndex = 11;
            txtSlots.TextChanged += txtSlots_TextChanged;
            // 
            // bttnRegisterAsPT
            // 
            bttnRegisterAsPT.Location = new Point(314, 95);
            bttnRegisterAsPT.Name = "bttnRegisterAsPT";
            bttnRegisterAsPT.Size = new Size(100, 33);
            bttnRegisterAsPT.TabIndex = 13;
            bttnRegisterAsPT.Text = "Register as PT";
            bttnRegisterAsPT.UseVisualStyleBackColor = true;
            bttnRegisterAsPT.Click += bttnRegisterAsPT_Click;
            // 
            // bttnRegisterAsAthlete
            // 
            bttnRegisterAsAthlete.Location = new Point(314, 95);
            bttnRegisterAsAthlete.Name = "bttnRegisterAsAthlete";
            bttnRegisterAsAthlete.Size = new Size(100, 41);
            bttnRegisterAsAthlete.TabIndex = 14;
            bttnRegisterAsAthlete.Text = "Register as Athlete";
            bttnRegisterAsAthlete.UseVisualStyleBackColor = true;
            bttnRegisterAsAthlete.Visible = false;
            bttnRegisterAsAthlete.Click += bttnRegisterAsAthlete_Click;
            // 
            // bttnRegister
            // 
            bttnRegister.Location = new Point(151, 429);
            bttnRegister.Name = "bttnRegister";
            bttnRegister.Size = new Size(131, 64);
            bttnRegister.TabIndex = 15;
            bttnRegister.Text = "Register";
            bttnRegister.UseVisualStyleBackColor = true;
            bttnRegister.Click += bttnRegister_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(222, 365);
            label7.Name = "label7";
            label7.Size = new Size(19, 21);
            label7.TabIndex = 16;
            label7.Text = "€";
            // 
            // image1
            // 
            image1.Location = new Point(166, 238);
            image1.Name = "image1";
            image1.Size = new Size(116, 74);
            image1.SizeMode = PictureBoxSizeMode.StretchImage;
            image1.TabIndex = 17;
            image1.TabStop = false;
            image1.Click += image1_Click;
            // 
            // bttnUploadPhoto
            // 
            bttnUploadPhoto.Location = new Point(166, 318);
            bttnUploadPhoto.Name = "bttnUploadPhoto";
            bttnUploadPhoto.Size = new Size(116, 23);
            bttnUploadPhoto.TabIndex = 18;
            bttnUploadPhoto.Text = "Upload a photo";
            bttnUploadPhoto.UseVisualStyleBackColor = true;
            bttnUploadPhoto.Click += bttnUploadPhoto_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 555);
            Controls.Add(bttnUploadPhoto);
            Controls.Add(image1);
            Controls.Add(label7);
            Controls.Add(bttnRegister);
            Controls.Add(bttnRegisterAsPT);
            Controls.Add(label6);
            Controls.Add(txtSlots);
            Controls.Add(label5);
            Controls.Add(txtPrice);
            Controls.Add(label4);
            Controls.Add(txtTags);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(bttnRegisterAsAthlete);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ((System.ComponentModel.ISupportInitialize)image1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private RichTextBox txtDescription;
        private Label label4;
        private TextBox txtTags;
        private Label label5;
        private TextBox txtPrice;
        private Label label6;
        private TextBox txtSlots;
        private Button bttnRegisterAsPT;
        private Button bttnRegisterAsAthlete;
        private Button bttnRegister;
        private Label label7;
        private PictureBox image1;
        private Button bttnUploadPhoto;
    }
}