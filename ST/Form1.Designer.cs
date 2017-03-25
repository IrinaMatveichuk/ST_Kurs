namespace ST
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Login = new System.Windows.Forms.TabPage();
            this.errorLabel = new System.Windows.Forms.Label();
            this.COM1 = new System.Windows.Forms.TabPage();
            this.speedComboBox1 = new System.Windows.Forms.ComboBox();
            this.comPortNum1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.COM2 = new System.Windows.Forms.TabPage();
            this.speedComboBox2 = new System.Windows.Forms.ComboBox();
            this.comPortNum2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Login.SuspendLayout();
            this.COM1.SuspendLayout();
            this.COM2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваше имя:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(116, 33);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(110, 20);
            this.userName.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Login);
            this.tabControl1.Controls.Add(this.COM1);
            this.tabControl1.Controls.Add(this.COM2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 207);
            this.tabControl1.TabIndex = 7;
            // 
            // Login
            // 
            this.Login.Controls.Add(this.errorLabel);
            this.Login.Controls.Add(this.label1);
            this.Login.Controls.Add(this.userName);
            this.Login.Location = new System.Drawing.Point(4, 22);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3);
            this.Login.Size = new System.Drawing.Size(277, 181);
            this.Login.TabIndex = 0;
            this.Login.Text = "Ник";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(33, 74);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(203, 26);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "! Пользователь не зарегистрирован. Обратитесь к администратору.";
            this.errorLabel.Visible = false;
            // 
            // COM1
            // 
            this.COM1.Controls.Add(this.speedComboBox1);
            this.COM1.Controls.Add(this.comPortNum1);
            this.COM1.Controls.Add(this.label4);
            this.COM1.Controls.Add(this.label3);
            this.COM1.Location = new System.Drawing.Point(4, 22);
            this.COM1.Name = "COM1";
            this.COM1.Padding = new System.Windows.Forms.Padding(3);
            this.COM1.Size = new System.Drawing.Size(277, 181);
            this.COM1.TabIndex = 1;
            this.COM1.Text = "COM порт 1";
            this.COM1.UseVisualStyleBackColor = true;
            // 
            // speedComboBox1
            // 
            this.speedComboBox1.FormattingEnabled = true;
            this.speedComboBox1.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400"});
            this.speedComboBox1.Location = new System.Drawing.Point(110, 75);
            this.speedComboBox1.Name = "speedComboBox1";
            this.speedComboBox1.Size = new System.Drawing.Size(121, 21);
            this.speedComboBox1.TabIndex = 6;
            // 
            // comPortNum1
            // 
            this.comPortNum1.FormattingEnabled = true;
            this.comPortNum1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comPortNum1.Location = new System.Drawing.Point(110, 31);
            this.comPortNum1.Name = "comPortNum1";
            this.comPortNum1.Size = new System.Drawing.Size(121, 21);
            this.comPortNum1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Скорость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "COM порт";
            // 
            // COM2
            // 
            this.COM2.Controls.Add(this.speedComboBox2);
            this.COM2.Controls.Add(this.comPortNum2);
            this.COM2.Controls.Add(this.label10);
            this.COM2.Controls.Add(this.label11);
            this.COM2.Location = new System.Drawing.Point(4, 22);
            this.COM2.Name = "COM2";
            this.COM2.Padding = new System.Windows.Forms.Padding(3);
            this.COM2.Size = new System.Drawing.Size(277, 181);
            this.COM2.TabIndex = 2;
            this.COM2.Text = "COM порт 2";
            this.COM2.UseVisualStyleBackColor = true;
            // 
            // speedComboBox2
            // 
            this.speedComboBox2.FormattingEnabled = true;
            this.speedComboBox2.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400"});
            this.speedComboBox2.Location = new System.Drawing.Point(110, 75);
            this.speedComboBox2.Name = "speedComboBox2";
            this.speedComboBox2.Size = new System.Drawing.Size(121, 21);
            this.speedComboBox2.TabIndex = 16;
            // 
            // comPortNum2
            // 
            this.comPortNum2.FormattingEnabled = true;
            this.comPortNum2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comPortNum2.Location = new System.Drawing.Point(110, 31);
            this.comPortNum2.Name = "comPortNum2";
            this.comPortNum2.Size = new System.Drawing.Size(121, 21);
            this.comPortNum2.TabIndex = 15;
            this.comPortNum2.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Скорость";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "COM порт";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 260);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Настройка подключения";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.COM1.ResumeLayout(false);
            this.COM1.PerformLayout();
            this.COM2.ResumeLayout(false);
            this.COM2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Login;
        private System.Windows.Forms.TabPage COM1;
        private System.Windows.Forms.ComboBox speedComboBox1;
        private System.Windows.Forms.ComboBox comPortNum1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage COM2;
        private System.Windows.Forms.ComboBox speedComboBox2;
        private System.Windows.Forms.ComboBox comPortNum2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label errorLabel;
    }
}

