namespace HW
{
    partial class ResetPwd
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
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            buttonSendCode = new Button();
            labelCode = new Label();
            textBoxCode = new TextBox();
            labelNewPassword = new Label();
            textBoxNewPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonReset = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(35, 42);
            labelEmail.Margin = new Padding(4, 0, 4, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(42, 17);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(175, 38);
            textBoxEmail.Margin = new Padding(4, 4, 4, 4);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(233, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // buttonSendCode
            // 
            buttonSendCode.Location = new Point(432, 35);
            buttonSendCode.Margin = new Padding(4, 4, 4, 4);
            buttonSendCode.Name = "buttonSendCode";
            buttonSendCode.Size = new Size(88, 33);
            buttonSendCode.TabIndex = 2;
            buttonSendCode.Text = "发送验证码";
            buttonSendCode.UseVisualStyleBackColor = true;
            buttonSendCode.Click += buttonSendCode_Click;
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(35, 99);
            labelCode.Margin = new Padding(4, 0, 4, 0);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(111, 17);
            labelCode.TabIndex = 3;
            labelCode.Text = "验证码:";
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(175, 95);
            textBoxCode.Margin = new Padding(4, 4, 4, 4);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(233, 23);
            textBoxCode.TabIndex = 4;
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.Location = new Point(35, 156);
            labelNewPassword.Margin = new Padding(4, 0, 4, 0);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(97, 17);
            labelNewPassword.TabIndex = 5;
            labelNewPassword.Text = "新密码:";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.Location = new Point(175, 152);
            textBoxNewPassword.Margin = new Padding(4, 4, 4, 4);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.Size = new Size(233, 23);
            textBoxNewPassword.TabIndex = 6;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Location = new Point(35, 212);
            labelConfirmPassword.Margin = new Padding(4, 0, 4, 0);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(117, 17);
            labelConfirmPassword.TabIndex = 7;
            labelConfirmPassword.Text = "确认密码:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(175, 208);
            textBoxConfirmPassword.Margin = new Padding(4, 4, 4, 4);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(233, 23);
            textBoxConfirmPassword.TabIndex = 8;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(175, 269);
            buttonReset.Margin = new Padding(4, 4, 4, 4);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(88, 33);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "重置";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(321, 269);
            buttonCancel.Margin = new Padding(4, 4, 4, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(88, 33);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ResetPwd
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 341);
            Controls.Add(buttonCancel);
            Controls.Add(buttonReset);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(labelConfirmPassword);
            Controls.Add(textBoxNewPassword);
            Controls.Add(labelNewPassword);
            Controls.Add(textBoxCode);
            Controls.Add(labelCode);
            Controls.Add(buttonSendCode);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ResetPwd";
            Text = "Reset Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSendCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonCancel;
    }
}