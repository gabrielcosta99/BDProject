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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNumEx = new TextBox();
            txtWeightUsed = new TextBox();
            txtEntryNum = new TextBox();
            txtRepsMade = new TextBox();
            txtSetNum = new TextBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            bindingSource1 = new BindingSource(components);
            bttnConfirm = new Button();
            bttnPlay = new Button();
            bttnCancel = new Button();
            button3 = new Button();
            bttnAdd = new Button();
            bttnEdit = new Button();
            bttnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 120);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "set number";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 157);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 4;
            label2.Text = "number of reps";
            label2.Click += label2_Click_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(30, 34);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(198, 394);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(329, 60);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 8;
            label3.Text = "entry num";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(314, 88);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 9;
            label4.Text = "exercise num";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(316, 194);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 10;
            label5.Text = "weight used";
            label5.Click += label5_Click;
            // 
            // txtNumEx
            // 
            txtNumEx.Location = new Point(402, 88);
            txtNumEx.Name = "txtNumEx";
            txtNumEx.Size = new Size(100, 23);
            txtNumEx.TabIndex = 12;
            txtNumEx.TextChanged += textBox2_TextChanged_1;
            // 
            // txtWeightUsed
            // 
            txtWeightUsed.Location = new Point(402, 192);
            txtWeightUsed.Name = "txtWeightUsed";
            txtWeightUsed.Size = new Size(100, 23);
            txtWeightUsed.TabIndex = 11;
            txtWeightUsed.TextChanged += textBox1_TextChanged_2;
            // 
            // txtEntryNum
            // 
            txtEntryNum.Location = new Point(402, 58);
            txtEntryNum.Name = "txtEntryNum";
            txtEntryNum.Size = new Size(100, 23);
            txtEntryNum.TabIndex = 13;
            txtEntryNum.TextChanged += textBox3_TextChanged;
            // 
            // txtRepsMade
            // 
            txtRepsMade.Location = new Point(402, 155);
            txtRepsMade.Name = "txtRepsMade";
            txtRepsMade.Size = new Size(100, 23);
            txtRepsMade.TabIndex = 3;
            txtRepsMade.TextChanged += textBox2_TextChanged;
            // 
            // txtSetNum
            // 
            txtSetNum.Location = new Point(402, 117);
            txtSetNum.Name = "txtSetNum";
            txtSetNum.Size = new Size(100, 23);
            txtSetNum.TabIndex = 1;
            txtSetNum.TextChanged += textBox1_TextChanged;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(559, 56);
            axWindowsMediaPlayer1.Margin = new Padding(3, 2, 3, 2);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(229, 190);
            axWindowsMediaPlayer1.TabIndex = 14;
            axWindowsMediaPlayer1.Enter += axWindowsMediaPlayer1_Enter;
            // 
            // bttnConfirm
            // 
            bttnConfirm.Location = new Point(312, 230);
            bttnConfirm.Name = "bttnConfirm";
            bttnConfirm.Size = new Size(75, 23);
            bttnConfirm.TabIndex = 5;
            bttnConfirm.Text = "Confirm";
            bttnConfirm.UseVisualStyleBackColor = true;
            bttnConfirm.Click += bttnConfirm_Click;
            // 
            // bttnPlay
            // 
            bttnPlay.Location = new Point(570, 250);
            bttnPlay.Margin = new Padding(3, 2, 3, 2);
            bttnPlay.Name = "bttnPlay";
            bttnPlay.Size = new Size(82, 22);
            bttnPlay.TabIndex = 15;
            bttnPlay.Text = "Play";
            bttnPlay.UseVisualStyleBackColor = true;
            bttnPlay.Click += bttnPlay_Click;
            // 
            // bttnCancel
            // 
            bttnCancel.Location = new Point(402, 230);
            bttnCancel.Name = "bttnCancel";
            bttnCancel.Size = new Size(75, 23);
            bttnCancel.TabIndex = 6;
            bttnCancel.Text = "Cancel";
            bttnCancel.UseVisualStyleBackColor = true;
            bttnCancel.Click += bttnCancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(346, 335);
            button3.Name = "button3";
            button3.Size = new Size(98, 23);
            button3.TabIndex = 16;
            button3.Text = "Form2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // bttnAdd
            // 
            bttnAdd.Location = new Point(346, 230);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(75, 23);
            bttnAdd.TabIndex = 17;
            bttnAdd.Text = "Add";
            bttnAdd.UseVisualStyleBackColor = true;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // bttnEdit
            // 
            bttnEdit.Location = new Point(265, 230);
            bttnEdit.Name = "bttnEdit";
            bttnEdit.Size = new Size(75, 23);
            bttnEdit.TabIndex = 18;
            bttnEdit.Text = "Edit";
            bttnEdit.UseVisualStyleBackColor = true;
            bttnEdit.Click += bttnEdit_Click;
            // 
            // bttnDelete
            // 
            bttnDelete.Location = new Point(427, 230);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(75, 23);
            bttnDelete.TabIndex = 19;
            bttnDelete.Text = "Delete";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bttnDelete);
            Controls.Add(bttnEdit);
            Controls.Add(bttnAdd);
            Controls.Add(button3);
            Controls.Add(bttnPlay);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(txtEntryNum);
            Controls.Add(txtWeightUsed);
            Controls.Add(txtNumEx);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(bttnCancel);
            Controls.Add(bttnConfirm);
            Controls.Add(label2);
            Controls.Add(txtRepsMade);
            Controls.Add(label1);
            Controls.Add(txtSetNum);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSetNum;
        private Label label1;
        private TextBox txtRepsMade;
        private Label label2;
        private Button bttnConfirm;
        private Button bttnCancel;
        private ListBox listBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNumEx;
        private TextBox txtWeightUsed;
        private TextBox txtEntryNum;

        private string videopath;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button bttnPlay;
        private BindingSource bindingSource1;
        private Button button3;
        private Button bttnAdd;
        private Button bttnEdit;
        private Button bttnDelete;
    }
}
