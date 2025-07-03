namespace HW
{
    partial class Selector
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
            listBox = new ListBox();
            buttonLaunch = new Button();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(200, 37);
            listBox.Name = "listBox";
            listBox.Size = new Size(409, 314);
            listBox.TabIndex = 0;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // buttonLaunch
            // 
            buttonLaunch.Location = new Point(334, 375);
            buttonLaunch.Name = "buttonLaunch";
            buttonLaunch.Size = new Size(150, 46);
            buttonLaunch.TabIndex = 1;
            buttonLaunch.Text = "Launch";
            buttonLaunch.UseVisualStyleBackColor = true;
            buttonLaunch.Click += buttonLaunch_Click;
            // 
            // Selector
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLaunch);
            Controls.Add(listBox);
            Name = "Selector";
            Text = "Selector";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox;
        private Button buttonLaunch;
    }
}