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
            bttnGoBack = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(61, 84);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(175, 304);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 56);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 1;
            label1.Text = "Available workouts";
            label1.Click += label1_Click;
            // 
            // bttnCheckItOut
            // 
            bttnCheckItOut.Location = new Point(429, 413);
            bttnCheckItOut.Margin = new Padding(3, 4, 3, 4);
            bttnCheckItOut.Name = "bttnCheckItOut";
            bttnCheckItOut.Size = new Size(104, 56);
            bttnCheckItOut.TabIndex = 2;
            bttnCheckItOut.Text = "Check it out!";
            bttnCheckItOut.UseVisualStyleBackColor = true;
            bttnCheckItOut.Click += bttnCheckItOut_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(386, 84);
            listBox2.Margin = new Padding(3, 4, 3, 4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(188, 304);
            listBox2.TabIndex = 3;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 59);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 4;
            label2.Text = "Exercises";
            label2.Click += label2_Click;
            // 
            // bttnGoBack
            // 
            bttnGoBack.Location = new Point(575, 511);
            bttnGoBack.Margin = new Padding(3, 4, 3, 4);
            bttnGoBack.Name = "bttnGoBack";
            bttnGoBack.Size = new Size(88, 47);
            bttnGoBack.TabIndex = 5;
            bttnGoBack.Text = "Go back";
            bttnGoBack.UseVisualStyleBackColor = true;
            bttnGoBack.Click += bttnGoBack_Click;
            // 
            // button1
            // 
            button1.Location = new Point(68, 427);
            button1.Name = "button1";
            button1.Size = new Size(158, 29);
            button1.TabIndex = 6;
            button1.Text = "Subscribe to PTs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(260, 490);
            button2.Name = "button2";
            button2.Size = new Size(100, 29);
            button2.TabIndex = 7;
            button2.Text = "My Progress";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Workouts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 573);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(bttnGoBack);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(bttnCheckItOut);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button bttnGoBack;
        private Button button1;
        private Button button2;
    }
}