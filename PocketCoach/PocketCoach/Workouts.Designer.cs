namespace PocketCoach
{
    partial class Workouts
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
            bttnCheckItOut = new Button();
            listBox2 = new ListBox();
            label2 = new Label();
            bttnLogOut = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(53, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(154, 229);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 42);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Available workouts";
            label1.Click += label1_Click;
            // 
            // bttnCheckItOut
            // 
            bttnCheckItOut.Location = new Point(359, 310);
            bttnCheckItOut.Name = "bttnCheckItOut";
            bttnCheckItOut.Size = new Size(91, 42);
            bttnCheckItOut.TabIndex = 2;
            bttnCheckItOut.Text = "Check it out!";
            bttnCheckItOut.UseVisualStyleBackColor = true;
            bttnCheckItOut.Click += bttnCheckItOut_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(338, 63);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(165, 229);
            listBox2.TabIndex = 3;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 44);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 4;
            label2.Text = "Exercises";
            label2.Click += label2_Click;
            // 
            // bttnLogOut
            // 
            bttnLogOut.Location = new Point(672, 371);
            bttnLogOut.Name = "bttnLogOut";
            bttnLogOut.Size = new Size(75, 23);
            bttnLogOut.TabIndex = 5;
            bttnLogOut.Text = "Logout";
            bttnLogOut.UseVisualStyleBackColor = true;
            bttnLogOut.Click += bttnLogOut_Click;
            // 
            // Workouts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bttnLogOut);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(bttnCheckItOut);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "Workouts";
            Text = "Workouts";
            Load += Workouts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Button bttnCheckItOut;
        private ListBox listBox2;
        private Label label2;
        private Button bttnLogOut;
    }
}