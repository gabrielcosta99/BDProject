namespace PocketCoach
{
    partial class AthleteMenu
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
            bttnSubscriptions = new Button();
            bttnWorkouts = new Button();
            bttnLogout = new Button();
            bttnMyProgress = new Button();
            bttnChat = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // bttnSubscriptions
            // 
            bttnSubscriptions.Location = new Point(93, 57);
            bttnSubscriptions.Margin = new Padding(3, 4, 3, 4);
            bttnSubscriptions.Name = "bttnSubscriptions";
            bttnSubscriptions.Size = new Size(209, 81);
            bttnSubscriptions.TabIndex = 0;
            bttnSubscriptions.Text = "Subscriptions";
            bttnSubscriptions.UseVisualStyleBackColor = true;
            bttnSubscriptions.Click += bttnSubscriptions_Click;
            // 
            // bttnWorkouts
            // 
            bttnWorkouts.Location = new Point(93, 183);
            bttnWorkouts.Margin = new Padding(3, 4, 3, 4);
            bttnWorkouts.Name = "bttnWorkouts";
            bttnWorkouts.Size = new Size(209, 87);
            bttnWorkouts.TabIndex = 1;
            bttnWorkouts.Text = "Workouts";
            bttnWorkouts.UseVisualStyleBackColor = true;
            bttnWorkouts.Click += bttnWorkouts_Click;
            // 
            // bttnLogout
            // 
            bttnLogout.Location = new Point(245, 536);
            bttnLogout.Margin = new Padding(3, 4, 3, 4);
            bttnLogout.Name = "bttnLogout";
            bttnLogout.Size = new Size(149, 76);
            bttnLogout.TabIndex = 2;
            bttnLogout.Text = "Logout";
            bttnLogout.UseVisualStyleBackColor = true;
            bttnLogout.Click += bttnLogout_Click;
            // 
            // bttnMyProgress
            // 
            bttnMyProgress.Location = new Point(93, 299);
            bttnMyProgress.Margin = new Padding(3, 4, 3, 4);
            bttnMyProgress.Name = "bttnMyProgress";
            bttnMyProgress.Size = new Size(209, 89);
            bttnMyProgress.TabIndex = 3;
            bttnMyProgress.Text = "My progress";
            bttnMyProgress.UseVisualStyleBackColor = true;
            bttnMyProgress.Click += bttnMyProgress_Click;
            // 
            // bttnChat
            // 
            bttnChat.Location = new Point(96, 423);
            bttnChat.Margin = new Padding(3, 4, 3, 4);
            bttnChat.Name = "bttnChat";
            bttnChat.Size = new Size(206, 76);
            bttnChat.TabIndex = 4;
            bttnChat.Text = "Chat";
            bttnChat.UseVisualStyleBackColor = true;
            bttnChat.Click += bttnChat_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 583);
            button1.Name = "button1";
            button1.Size = new Size(123, 29);
            button1.TabIndex = 5;
            button1.Text = "Delete Account";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AthleteMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 727);
            Controls.Add(button1);
            Controls.Add(bttnChat);
            Controls.Add(bttnMyProgress);
            Controls.Add(bttnLogout);
            Controls.Add(bttnWorkouts);
            Controls.Add(bttnSubscriptions);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AthleteMenu";
            Text = "AthleteMenu";
            Load += AthleteMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSubscriptions;
        private Button bttnWorkouts;
        private Button bttnLogout;
        private Button bttnMyProgress;
        private Button bttnChat;
        private Button button1;
    }
}