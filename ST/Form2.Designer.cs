namespace ST
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.History = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьИсториюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsgTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.msgListBox = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.sendToAllCheck = new System.Windows.Forms.CheckBox();
            this.sendToLabel = new System.Windows.Forms.Label();
            this.emptyMsgLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usersListBox);
            this.groupBox1.Location = new System.Drawing.Point(445, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователи";
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Location = new System.Drawing.Point(7, 20);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(108, 147);
            this.usersListBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.History,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // History
            // 
            this.History.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.посмотретьИсториюToolStripMenuItem});
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(66, 20);
            this.History.Text = "История";
            // 
            // посмотретьИсториюToolStripMenuItem
            // 
            this.посмотретьИсториюToolStripMenuItem.Name = "посмотретьИсториюToolStripMenuItem";
            this.посмотретьИсториюToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.посмотретьИсториюToolStripMenuItem.Text = "Посмотреть историю";
            this.посмотретьИсториюToolStripMenuItem.Click += new System.EventHandler(this.посмотретьИсториюToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // MsgTextBox
            // 
            this.MsgTextBox.Location = new System.Drawing.Point(28, 268);
            this.MsgTextBox.Multiline = true;
            this.MsgTextBox.Name = "MsgTextBox";
            this.MsgTextBox.Size = new System.Drawing.Size(293, 39);
            this.MsgTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(327, 268);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(98, 39);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // msgListBox
            // 
            this.msgListBox.FormattingEnabled = true;
            this.msgListBox.Location = new System.Drawing.Point(28, 37);
            this.msgListBox.Name = "msgListBox";
            this.msgListBox.Size = new System.Drawing.Size(397, 199);
            this.msgListBox.TabIndex = 7;
            // 
            // connectButton
            // 
            this.connectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.connectButton.Location = new System.Drawing.Point(452, 283);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(144, 24);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(452, 255);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(144, 22);
            this.disconnectButton.TabIndex = 9;
            this.disconnectButton.Text = "Сменить пользователя";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // sendToAllCheck
            // 
            this.sendToAllCheck.AutoSize = true;
            this.sendToAllCheck.Checked = true;
            this.sendToAllCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendToAllCheck.Location = new System.Drawing.Point(452, 220);
            this.sendToAllCheck.Name = "sendToAllCheck";
            this.sendToAllCheck.Size = new System.Drawing.Size(53, 17);
            this.sendToAllCheck.TabIndex = 10;
            this.sendToAllCheck.Text = "Всем";
            this.sendToAllCheck.UseVisualStyleBackColor = true;
            // 
            // sendToLabel
            // 
            this.sendToLabel.AutoSize = true;
            this.sendToLabel.Location = new System.Drawing.Point(28, 249);
            this.sendToLabel.Name = "sendToLabel";
            this.sendToLabel.Size = new System.Drawing.Size(94, 13);
            this.sendToLabel.TabIndex = 11;
            this.sendToLabel.Text = "Сообщение всем";
            // 
            // emptyMsgLabel
            // 
            this.emptyMsgLabel.AutoSize = true;
            this.emptyMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.emptyMsgLabel.Location = new System.Drawing.Point(28, 310);
            this.emptyMsgLabel.Name = "emptyMsgLabel";
            this.emptyMsgLabel.Size = new System.Drawing.Size(97, 13);
            this.emptyMsgLabel.TabIndex = 12;
            this.emptyMsgLabel.Text = "Пустое собщение";
            this.emptyMsgLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(126, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(176, 23);
            this.progressBar1.Step = 25;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 327);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.emptyMsgLabel);
            this.Controls.Add(this.sendToLabel);
            this.Controls.Add(this.sendToAllCheck);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.msgListBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.MsgTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Чат";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem History;
        private System.Windows.Forms.ToolStripMenuItem посмотретьИсториюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TextBox MsgTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox msgListBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.CheckBox sendToAllCheck;
        private System.Windows.Forms.Label sendToLabel;
        private System.Windows.Forms.Label emptyMsgLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}