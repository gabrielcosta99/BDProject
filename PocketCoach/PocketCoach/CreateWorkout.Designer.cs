namespace PocketCoach
{
    partial class CreateWorkout
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            listBox2 = new ListBox();
            bttnAdd = new Button();
            bttnRemove = new Button();
            label4 = new Label();
            bttnUpload = new Button();
            label5 = new Label();
            txtTags = new TextBox();
            chkIsPremium = new CheckBox();
            bttnLogOut = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(22, 110);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(123, 244);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(189, 9);
            label1.Name = "label1";
            label1.Size = new Size(198, 32);
            label1.TabIndex = 1;
            label1.Text = "Workout creation";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 113);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "workout title";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 220);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 3;
            label3.Text = "exercises";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(394, 110);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 4;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(394, 220);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 94);
            listBox2.TabIndex = 5;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // bttnAdd
            // 
            bttnAdd.Location = new Point(180, 186);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(77, 37);
            bttnAdd.TabIndex = 6;
            bttnAdd.Text = "Add";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += button1_Click;
            // 
            // bttnRemove
            // 
            bttnRemove.Location = new Point(411, 320);
            bttnRemove.Name = "bttnRemove";
            bttnRemove.Size = new Size(83, 41);
            bttnRemove.TabIndex = 7;
            bttnRemove.Text = "Remove";
            bttnRemove.UseVisualStyleBackColor = true;
            bttnRemove.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 92);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 9;
            label4.Text = "list of exercises";
            // 
            // bttnUpload
            // 
            bttnUpload.Location = new Point(171, 400);
            bttnUpload.Name = "bttnUpload";
            bttnUpload.Size = new Size(164, 71);
            bttnUpload.TabIndex = 10;
            bttnUpload.Text = "Upload Workout";
            bttnUpload.UseVisualStyleBackColor = true;
            bttnUpload.Click += bttnUpload_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(359, 151);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 11;
            label5.Text = "tags";
            // 
            // txtTags
            // 
            txtTags.Location = new Point(394, 148);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(176, 23);
            txtTags.TabIndex = 12;
            txtTags.TextChanged += textBox1_TextChanged;
            // 
            // chkIsPremium
            // 
            chkIsPremium.AutoSize = true;
            chkIsPremium.Location = new Point(420, 186);
            chkIsPremium.Name = "chkIsPremium";
            chkIsPremium.Size = new Size(86, 19);
            chkIsPremium.TabIndex = 13;
            chkIsPremium.Text = "is Premium";
            chkIsPremium.UseVisualStyleBackColor = true;
            chkIsPremium.CheckedChanged += chkIsPremium_CheckedChanged;
            // 
            // bttnLogOut
            // 
            bttnLogOut.Location = new Point(530, 463);
            bttnLogOut.Name = "bttnLogOut";
            bttnLogOut.Size = new Size(87, 38);
            bttnLogOut.TabIndex = 14;
            bttnLogOut.Text = "LogOut";
            bttnLogOut.UseVisualStyleBackColor = true;
            bttnLogOut.Click += bttnLogOut_Click;
            // 
            // CreateWorkout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 513);
            Controls.Add(bttnLogOut);
            Controls.Add(chkIsPremium);
            Controls.Add(txtTags);
            Controls.Add(label5);
            Controls.Add(bttnUpload);
            Controls.Add(label4);
            Controls.Add(bttnRemove);
            Controls.Add(bttnAdd);
            Controls.Add(listBox2);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "CreateWorkout";
            Text = "CreateWorkout";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private ListBox listBox2;
        private Button bttnAdd;
        private Button bttnRemove;
        private Label label4;
        private Button bttnUpload;
        private Label label5;
        private TextBox txtTags;
        private CheckBox chkIsPremium;
        private Button bttnLogOut;
    }
}