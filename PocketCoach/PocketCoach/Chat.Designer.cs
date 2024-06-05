namespace PocketCoach
{
    partial class Chat
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
            txtReceiverName = new TextBox();
            txtInMSG = new RichTextBox();
            txtMSG = new TextBox();
            bttnSend = new Button();
            bttnBackToMenu = new Button();
            SuspendLayout();
            // 
            // txtReceiverName
            // 
            txtReceiverName.BackColor = Color.FromArgb(128, 255, 255);
            txtReceiverName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReceiverName.Location = new Point(104, 29);
            txtReceiverName.Margin = new Padding(3, 4, 3, 4);
            txtReceiverName.Multiline = true;
            txtReceiverName.Name = "txtReceiverName";
            txtReceiverName.ReadOnly = true;
            txtReceiverName.Size = new Size(659, 50);
            txtReceiverName.TabIndex = 0;
            txtReceiverName.TextAlign = HorizontalAlignment.Center;
            txtReceiverName.TextChanged += txtReceiverName_TextChanged;
            // 
            // txtInMSG
            // 
            txtInMSG.Location = new Point(104, 115);
            txtInMSG.Margin = new Padding(3, 4, 3, 4);
            txtInMSG.Name = "txtInMSG";
            txtInMSG.ReadOnly = true;
            txtInMSG.Size = new Size(659, 392);
            txtInMSG.TabIndex = 1;
            txtInMSG.Text = "";
            txtInMSG.TextChanged += txtInMSG_TextChanged;
            // 
            // txtMSG
            // 
            txtMSG.Location = new Point(104, 532);
            txtMSG.Margin = new Padding(3, 4, 3, 4);
            txtMSG.Multiline = true;
            txtMSG.Name = "txtMSG";
            txtMSG.Size = new Size(659, 51);
            txtMSG.TabIndex = 2;
            txtMSG.TextChanged += txtMSG_TextChanged;
            // 
            // bttnSend
            // 
            bttnSend.Location = new Point(678, 532);
            bttnSend.Margin = new Padding(3, 4, 3, 4);
            bttnSend.Name = "bttnSend";
            bttnSend.Size = new Size(86, 52);
            bttnSend.TabIndex = 3;
            bttnSend.Text = "Send";
            bttnSend.UseVisualStyleBackColor = true;
            bttnSend.Click += bttnSend_Click;
            // 
            // bttnBackToMenu
            // 
            bttnBackToMenu.Location = new Point(4, 394);
            bttnBackToMenu.Name = "bttnBackToMenu";
            bttnBackToMenu.Size = new Size(94, 68);
            bttnBackToMenu.TabIndex = 4;
            bttnBackToMenu.Text = "Go back to menu";
            bttnBackToMenu.UseVisualStyleBackColor = true;
            bttnBackToMenu.Click += bttnBackToMenu_Click;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(bttnBackToMenu);
            Controls.Add(bttnSend);
            Controls.Add(txtMSG);
            Controls.Add(txtInMSG);
            Controls.Add(txtReceiverName);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Chat";
            Text = "Chat";
            Load += Chat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtReceiverName;
        private RichTextBox txtInMSG;
        private TextBox txtMSG;
        private Button bttnSend;
        private Button bttnBackToMenu;
    }
}