﻿namespace PocketCoach
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
            SuspendLayout();
            // 
            // bttnSubscriptions
            // 
            bttnSubscriptions.Location = new Point(81, 43);
            bttnSubscriptions.Name = "bttnSubscriptions";
            bttnSubscriptions.Size = new Size(183, 61);
            bttnSubscriptions.TabIndex = 0;
            bttnSubscriptions.Text = "Subscriptions";
            bttnSubscriptions.UseVisualStyleBackColor = true;
            bttnSubscriptions.Click += bttnSubscriptions_Click;
            // 
            // bttnWorkouts
            // 
            bttnWorkouts.Location = new Point(81, 137);
            bttnWorkouts.Name = "bttnWorkouts";
            bttnWorkouts.Size = new Size(183, 65);
            bttnWorkouts.TabIndex = 1;
            bttnWorkouts.Text = "Workouts";
            bttnWorkouts.UseVisualStyleBackColor = true;
            bttnWorkouts.Click += bttnWorkouts_Click;
            // 
            // bttnLogout
            // 
            bttnLogout.Location = new Point(112, 333);
            bttnLogout.Name = "bttnLogout";
            bttnLogout.Size = new Size(130, 57);
            bttnLogout.TabIndex = 2;
            bttnLogout.Text = "Logout";
            bttnLogout.UseVisualStyleBackColor = true;
            bttnLogout.Click += bttnLogout_Click;
            // 
            // AthleteMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 426);
            Controls.Add(bttnLogout);
            Controls.Add(bttnWorkouts);
            Controls.Add(bttnSubscriptions);
            Name = "AthleteMenu";
            Text = "AthleteMenu";
            Load += AthleteMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSubscriptions;
        private Button bttnWorkouts;
        private Button bttnLogout;
    }
}