namespace HW
{
    partial class Login
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
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            checkBoxRemeberMe = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            checkBoxAutoLogin = new CheckBox();
            buttonForget = new Button();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(104, 57);
            textBoxUsername.Margin = new Padding(2, 2, 2, 2);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(192, 23);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.ImeMode = ImeMode.Off;
            textBoxPassword.Location = new Point(104, 98);
            textBoxPassword.Margin = new Padding(2, 2, 2, 2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(192, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(136, 145);
            buttonLogin.Margin = new Padding(2, 2, 2, 2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(114, 25);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "登录";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // checkBoxRemeberMe
            // 
            checkBoxRemeberMe.AutoSize = true;
            checkBoxRemeberMe.Location = new Point(104, 122);
            checkBoxRemeberMe.Margin = new Padding(2, 2, 2, 2);
            checkBoxRemeberMe.Name = "checkBoxRemeberMe";
            checkBoxRemeberMe.Size = new Size(75, 21);
            checkBoxRemeberMe.TabIndex = 3;
            checkBoxRemeberMe.Text = "记住密码";
            checkBoxRemeberMe.UseVisualStyleBackColor = true;
            checkBoxRemeberMe.CheckedChanged += checkBoxRemeberMe_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 38);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 4;
            label1.Text = "学号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 80);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 5;
            label2.Text = "密码";
            // 
            // checkBoxAutoLogin
            // 
            checkBoxAutoLogin.AutoSize = true;
            checkBoxAutoLogin.Location = new Point(196, 122);
            checkBoxAutoLogin.Margin = new Padding(2, 2, 2, 2);
            checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            checkBoxAutoLogin.Size = new Size(75, 21);
            checkBoxAutoLogin.TabIndex = 6;
            checkBoxAutoLogin.Text = "自动登录";
            checkBoxAutoLogin.UseVisualStyleBackColor = true;
            checkBoxAutoLogin.CheckedChanged += checkBoxAutoLogin_CheckedChanged;
            // 
            // buttonForget
            // 
            buttonForget.Location = new Point(136, 173);
            buttonForget.Margin = new Padding(2, 2, 2, 2);
            buttonForget.Name = "buttonForget";
            buttonForget.Size = new Size(114, 25);
            buttonForget.TabIndex = 7;
            buttonForget.Text = "找回密码";
            buttonForget.UseVisualStyleBackColor = true;
            buttonForget.Click += buttonForget_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 247);
            Controls.Add(buttonForget);
            Controls.Add(checkBoxAutoLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBoxRemeberMe);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private CheckBox checkBoxRemeberMe;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxAutoLogin;
        private Button buttonForget;
    }
}