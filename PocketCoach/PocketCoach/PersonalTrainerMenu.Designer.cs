namespace PocketCoach
{
    partial class PersonalTrainerMenu
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
            bttnCreateWorkout = new Button();
            bttnChat = new Button();
            bttnLogout = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // bttnCreateWorkout
            // 
            bttnCreateWorkout.Location = new Point(109, 136);
            bttnCreateWorkout.Name = "bttnCreateWorkout";
            bttnCreateWorkout.Size = new Size(151, 67);
            bttnCreateWorkout.TabIndex = 0;
            bttnCreateWorkout.Text = "Create Workout";
            bttnCreateWorkout.UseVisualStyleBackColor = true;
            bttnCreateWorkout.Click += bttnCreateWorkout_Click;
            // 
            // bttnChat
            // 
            bttnChat.Location = new Point(109, 246);
            bttnChat.Name = "bttnChat";
            bttnChat.Size = new Size(151, 67);
            bttnChat.TabIndex = 1;
            bttnChat.Text = "Chat";
            bttnChat.UseVisualStyleBackColor = true;
            bttnChat.Click += bttnChat_Click;
            // 
            // bttnLogout
            // 
            bttnLogout.Location = new Point(246, 362);
            bttnLogout.Name = "bttnLogout";
            bttnLogout.Size = new Size(114, 41);
            bttnLogout.TabIndex = 2;
            bttnLogout.Text = "Logout";
            bttnLogout.UseVisualStyleBackColor = true;
            bttnLogout.Click += bttnLogout_Click;
            // 
            // button1
            // 
            button1.Location = new Point(109, 37);
            button1.Name = "button1";
            button1.Size = new Size(151, 67);
            button1.TabIndex = 3;
            button1.Text = "Create Exercise";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 374);
            button2.Name = "button2";
            button2.Size = new Size(124, 29);
            button2.TabIndex = 4;
            button2.Text = "Delete Account";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PersonalTrainerMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 502);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(bttnLogout);
            Controls.Add(bttnChat);
            Controls.Add(bttnCreateWorkout);
            Name = "PersonalTrainerMenu";
            Text = "Personal Trainer Menu";
            Load += PersonalTrainerMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button bttnCreateWorkout;
        private Button bttnChat;
        private Button bttnLogout;
        private Button button1;
        private Button button2;
    }
}