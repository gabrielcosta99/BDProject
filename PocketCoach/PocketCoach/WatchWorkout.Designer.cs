namespace PocketCoach
{
    partial class WatchWorkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchWorkout));
            bttnNextExercise = new Button();
            label1 = new Label();
            txtSetNum = new TextBox();
            label2 = new Label();
            txtRepsMade = new TextBox();
            bttnPlay = new Button();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            txtWeightUsed = new TextBox();
            label5 = new Label();
            listBox1 = new ListBox();
            bttnCancel = new Button();
            bttnConfirm = new Button();
            bttnPrevExercise = new Button();
            bttnFinishWorkout = new Button();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // bttnNextExercise
            // 
            bttnNextExercise.Location = new Point(427, 272);
            bttnNextExercise.Name = "bttnNextExercise";
            bttnNextExercise.Size = new Size(113, 23);
            bttnNextExercise.TabIndex = 0;
            bttnNextExercise.Text = "Next Exercise";
            bttnNextExercise.UseVisualStyleBackColor = true;
            bttnNextExercise.Click += bttnNextExercise_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 105);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "set number";
            label1.Click += label1_Click;
            // 
            // txtSetNum
            // 
            txtSetNum.Location = new Point(393, 102);
            txtSetNum.Name = "txtSetNum";
            txtSetNum.Size = new Size(100, 23);
            txtSetNum.TabIndex = 3;
            txtSetNum.TextChanged += txtSetNum_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(292, 143);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 6;
            label2.Text = "number of reps";
            label2.Click += label2_Click;
            // 
            // txtRepsMade
            // 
            txtRepsMade.Location = new Point(393, 141);
            txtRepsMade.Name = "txtRepsMade";
            txtRepsMade.Size = new Size(100, 23);
            txtRepsMade.TabIndex = 5;
            txtRepsMade.TextChanged += txtRepsMade_TextChanged;
            // 
            // bttnPlay
            // 
            bttnPlay.Location = new Point(581, 244);
            bttnPlay.Margin = new Padding(3, 2, 3, 2);
            bttnPlay.Name = "bttnPlay";
            bttnPlay.Size = new Size(82, 22);
            bttnPlay.TabIndex = 20;
            bttnPlay.Text = "Play";
            bttnPlay.UseVisualStyleBackColor = true;
            bttnPlay.Click += bttnPlay_Click;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(567, 50);
            axWindowsMediaPlayer1.Margin = new Padding(3, 2, 3, 2);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(229, 190);
            axWindowsMediaPlayer1.TabIndex = 19;
            axWindowsMediaPlayer1.Enter += axWindowsMediaPlayer1_Enter;
            // 
            // txtWeightUsed
            // 
            txtWeightUsed.Location = new Point(393, 184);
            txtWeightUsed.Name = "txtWeightUsed";
            txtWeightUsed.Size = new Size(100, 23);
            txtWeightUsed.TabIndex = 18;
            txtWeightUsed.TextChanged += txtWeightUsed_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(307, 187);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 17;
            label5.Text = "weight used";
            label5.Click += label5_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(21, 28);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(198, 394);
            listBox1.TabIndex = 16;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // bttnCancel
            // 
            bttnCancel.Location = new Point(418, 217);
            bttnCancel.Name = "bttnCancel";
            bttnCancel.Size = new Size(75, 23);
            bttnCancel.TabIndex = 22;
            bttnCancel.Text = "Cancel";
            bttnCancel.UseVisualStyleBackColor = true;
            bttnCancel.Click += bttnCancel_Click_1;
            // 
            // bttnConfirm
            // 
            bttnConfirm.Location = new Point(328, 217);
            bttnConfirm.Name = "bttnConfirm";
            bttnConfirm.Size = new Size(75, 23);
            bttnConfirm.TabIndex = 21;
            bttnConfirm.Text = "Confirm";
            bttnConfirm.UseVisualStyleBackColor = true;
            bttnConfirm.Click += bttnConfirm_Click_1;
            // 
            // bttnPrevExercise
            // 
            bttnPrevExercise.Location = new Point(291, 272);
            bttnPrevExercise.Name = "bttnPrevExercise";
            bttnPrevExercise.Size = new Size(112, 23);
            bttnPrevExercise.TabIndex = 25;
            bttnPrevExercise.Text = "Previous Exercise";
            bttnPrevExercise.UseVisualStyleBackColor = true;
            bttnPrevExercise.Click += bttnPrevExercise_Click;
            // 
            // bttnFinishWorkout
            // 
            bttnFinishWorkout.Location = new Point(384, 379);
            bttnFinishWorkout.Name = "bttnFinishWorkout";
            bttnFinishWorkout.Size = new Size(99, 23);
            bttnFinishWorkout.TabIndex = 26;
            bttnFinishWorkout.Text = "Finish Workout";
            bttnFinishWorkout.UseVisualStyleBackColor = true;
            bttnFinishWorkout.Click += bttnFinishWorkout_Click;
            // 
            // WatchWorkout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bttnFinishWorkout);
            Controls.Add(bttnPrevExercise);
            Controls.Add(bttnCancel);
            Controls.Add(bttnConfirm);
            Controls.Add(bttnPlay);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(txtWeightUsed);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(txtRepsMade);
            Controls.Add(label1);
            Controls.Add(txtSetNum);
            Controls.Add(bttnNextExercise);
            Name = "WatchWorkout";
            Text = "WatchWorkout";
            Load += WatchWorkout_Load;
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bttnNextExercise;
        private Label label1;
        private TextBox txtSetNum;
        private Label label2;
        private TextBox txtRepsMade;
        private Button bttnPlay;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private TextBox txtWeightUsed;
        private Label label5;
        private ListBox listBox1;
        private Button bttnCancel;
        private Button bttnConfirm;
        private Button bttnPrevExercise;
        private Button bttnFinishWorkout;
    }
}