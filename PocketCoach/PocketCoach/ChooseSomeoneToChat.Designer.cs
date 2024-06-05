namespace PocketCoach
{
    partial class ChooseSomeoneToChat
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
            bttnChat = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(89, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 244);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // bttnChat
            // 
            bttnChat.Location = new Point(110, 303);
            bttnChat.Name = "bttnChat";
            bttnChat.Size = new Size(94, 29);
            bttnChat.TabIndex = 1;
            bttnChat.Text = "Chat";
            bttnChat.UseVisualStyleBackColor = true;
            bttnChat.Click += bttnChat_Click;
            // 
            // ChooseSomeoneToChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 419);
            Controls.Add(bttnChat);
            Controls.Add(listBox1);
            Name = "ChooseSomeoneToChat";
            Text = "ChooseSomeoneToChat";
            Load += ChooseSomeoneToChat_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button bttnChat;
    }
}