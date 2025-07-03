namespace HW
{
    partial class Gallery
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
            if (disposing)
            {
                // Dispose the current image
                pictureBox1?.Image?.Dispose();

                if (components != null)
                {
                    components.Dispose();
                }
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
            textBox1 = new TextBox();
            buttonLoad = new Button();
            buttonView = new Button();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            buttonPrev = new Button();
            buttonNext = new Button();
            labelPage = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 16);
            textBox1.Margin = new Padding(4, 4, 4, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1480, 38);
            textBox1.TabIndex = 0;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(1504, 13);
            buttonLoad.Margin = new Padding(4, 4, 4, 4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(150, 46);
            buttonLoad.TabIndex = 1;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonView
            // 
            buttonView.Location = new Point(1268, 1052);
            buttonView.Margin = new Padding(6, 5, 6, 5);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(228, 46);
            buttonView.TabIndex = 2;
            buttonView.Text = "View";
            buttonView.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(158, 159);
            pictureBox1.Margin = new Padding(6, 5, 6, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1338, 797);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(800, 1052);
            comboBox1.Margin = new Padding(6, 5, 6, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(216, 39);
            comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1032, 1052);
            comboBox2.Margin = new Padding(6, 5, 6, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(216, 39);
            comboBox2.TabIndex = 5;
            // 
            // buttonPrev
            // 
            buttonPrev.Location = new Point(158, 1052);
            buttonPrev.Margin = new Padding(6, 5, 6, 5);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(52, 46);
            buttonPrev.TabIndex = 6;
            buttonPrev.Text = "<";
            buttonPrev.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(384, 1052);
            buttonNext.Margin = new Padding(6, 5, 6, 5);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(52, 46);
            buttonNext.TabIndex = 7;
            buttonNext.Text = ">";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += ButtonNext_Click;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Location = new Point(272, 1059);
            labelPage.Margin = new Padding(6, 0, 6, 0);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(52, 31);
            labelPage.TabIndex = 8;
            labelPage.Text = "0/0";
            labelPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Gallery
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1672, 1227);
            Controls.Add(labelPage);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrev);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Controls.Add(buttonView);
            Controls.Add(buttonLoad);
            Controls.Add(textBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Gallery";
            Text = "Gallery";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonLoad;
        private Button buttonView;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button buttonPrev;
        private Button buttonNext;
        private Label labelPage;
    }
}