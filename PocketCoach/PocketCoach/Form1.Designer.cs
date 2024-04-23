using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PocketCoach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            set_num = new TextBox();
            label1 = new Label();
            num_reps = new TextBox();
            label2 = new Label();
            Confirm = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            num_ex = new TextBox();
            weight_used = new TextBox();
            entry_num = new TextBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // set_num
            // 
            set_num.Location = new Point(519, 159);
            set_num.Margin = new Padding(3, 4, 3, 4);
            set_num.Name = "set_num";
            set_num.Size = new Size(114, 27);
            set_num.TabIndex = 1;
            set_num.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(430, 162);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 2;
            label1.Text = "set number";
            label1.Click += label1_Click;
            // 
            // num_reps
            // 
            num_reps.Location = new Point(519, 209);
            num_reps.Margin = new Padding(3, 4, 3, 4);
            num_reps.Name = "num_reps";
            num_reps.Size = new Size(114, 27);
            num_reps.TabIndex = 3;
            num_reps.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(403, 212);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 4;
            label2.Text = "number of reps";
            label2.Click += label2_Click_1;
            // 
            // Confirm
            // 
            Confirm.Location = new Point(435, 309);
            Confirm.Margin = new Padding(3, 4, 3, 4);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(86, 31);
            Confirm.TabIndex = 5;
            Confirm.Text = "Confirmar";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(547, 309);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(34, 45);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(226, 524);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(435, 83);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 8;
            label3.Text = "entry num";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(418, 120);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 9;
            label4.Text = "exercise num";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(421, 262);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 10;
            label5.Text = "weight used";
            // 
            // num_ex
            // 
            num_ex.Location = new Point(519, 120);
            num_ex.Margin = new Padding(3, 4, 3, 4);
            num_ex.Name = "num_ex";
            num_ex.Size = new Size(114, 27);
            num_ex.TabIndex = 12;
            num_ex.TextChanged += textBox2_TextChanged_1;
            // 
            // weight_used
            // 
            weight_used.Location = new Point(519, 259);
            weight_used.Margin = new Padding(3, 4, 3, 4);
            weight_used.Name = "weight_used";
            weight_used.Size = new Size(114, 27);
            weight_used.TabIndex = 11;
            weight_used.TextChanged += textBox1_TextChanged_2;
            // 
            // entry_num
            // 
            entry_num.Location = new Point(519, 80);
            entry_num.Margin = new Padding(3, 4, 3, 4);
            entry_num.Name = "entry_num";
            entry_num.Size = new Size(114, 27);
            entry_num.TabIndex = 13;
            entry_num.TextChanged += textBox3_TextChanged;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(653, 162);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(229, 190);
            axWindowsMediaPlayer1.TabIndex = 14;
            axWindowsMediaPlayer1.Enter += axWindowsMediaPlayer1_Enter;
            // 
            // button1
            // 
            button1.Location = new Point(693, 395);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 15;
            button1.Text = "play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(entry_num);
            Controls.Add(weight_used);
            Controls.Add(num_ex);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(Confirm);
            Controls.Add(label2);
            Controls.Add(num_reps);
            Controls.Add(label1);
            Controls.Add(set_num);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox set_num;
        private Label label1;
        private TextBox num_reps;
        private Label label2;
        private Button Confirm;
        private Button button2;
        private ListBox listBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox num_ex;
        private TextBox weight_used;
        private TextBox entry_num;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button button1;
    }
}
