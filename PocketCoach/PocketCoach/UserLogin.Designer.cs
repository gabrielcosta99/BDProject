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
            txtAthleteNum = new TextBox();
            txtPTNum = new TextBox();
            bttnSelect = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(338, 126);
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
            label1.Location = new Point(69, 94);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Athlete number";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 161);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "PT number";
            label2.Click += label2_Click;
            // 
            // txtAthleteNum
            // 
            txtAthleteNum.Location = new Point(180, 91);
            txtAthleteNum.Name = "txtAthleteNum";
            txtAthleteNum.Size = new Size(100, 23);
            txtAthleteNum.TabIndex = 4;
            txtAthleteNum.TextChanged += txtAthleteNum_TextChanged;
            // 
            // txtPTNum
            // 
            txtPTNum.Location = new Point(177, 160);
            txtPTNum.Name = "txtPTNum";
            txtPTNum.Size = new Size(100, 23);
            txtPTNum.TabIndex = 5;
            txtPTNum.TextChanged += txtPTNum_TextChanged;
            // 
            // bttnSelect
            // 
            bttnSelect.Location = new Point(162, 222);
            bttnSelect.Name = "bttnSelect";
            bttnSelect.Size = new Size(75, 23);
            bttnSelect.TabIndex = 6;
            bttnSelect.Text = "Select";
            bttnSelect.UseVisualStyleBackColor = true;
            bttnSelect.Click += bttnSelect_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 280);
            Controls.Add(bttnSelect);
            Controls.Add(txtPTNum);
            Controls.Add(txtAthleteNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Name = "UserLogin";
            Text = "Select user";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtAthleteNum;
        private TextBox txtPTNum;
        private TextBox textBox3;
        private Button bttnSelect;
    }
}