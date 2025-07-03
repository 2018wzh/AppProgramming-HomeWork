namespace HW1
{
    partial class QuizApp
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
            labelStatus = new Label();
            textBoxFileName = new TextBox();
            buttonLoad = new Button();
            answerBox = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            labelQuestion = new Label();
            buttonPrevQ = new Button();
            buttonNextQ = new Button();
            buttonControl = new Button();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            labelTimer = new Label();
            answerBox.SuspendLayout();
            SuspendLayout();
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Dock = DockStyle.Bottom;
            labelStatus.Location = new Point(0, 500);
            labelStatus.Margin = new Padding(2, 0, 2, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(145, 17);
            labelStatus.TabIndex = 0;
            labelStatus.Text = " Please Input File Name";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(0, 9);
            textBoxFileName.Margin = new Padding(2);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(516, 23);
            textBoxFileName.TabIndex = 1;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(518, 7);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 25);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // answerBox
            // 
            answerBox.Controls.Add(radioButton4);
            answerBox.Controls.Add(radioButton3);
            answerBox.Controls.Add(radioButton2);
            answerBox.Controls.Add(radioButton1);
            answerBox.Location = new Point(44, 151);
            answerBox.Margin = new Padding(2);
            answerBox.Name = "answerBox";
            answerBox.Padding = new Padding(2);
            answerBox.Size = new Size(439, 275);
            answerBox.TabIndex = 3;
            answerBox.TabStop = false;
            answerBox.Text = "Answer";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(28, 206);
            radioButton4.Margin = new Padding(2);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(35, 21);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "D";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += OnRadioButtonCheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(28, 152);
            radioButton3.Margin = new Padding(2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(34, 21);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "C";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += OnRadioButtonCheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(28, 96);
            radioButton2.Margin = new Padding(2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(34, 21);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "B";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += OnRadioButtonCheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(28, 41);
            radioButton1.Margin = new Padding(2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(34, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "A";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += OnRadioButtonCheckedChanged;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new Font("Microsoft YaHei UI", 11F);
            labelQuestion.Location = new Point(44, 70);
            labelQuestion.Margin = new Padding(2, 0, 2, 0);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(79, 20);
            labelQuestion.TabIndex = 4;
            labelQuestion.Text = "Question:";
            // 
            // buttonPrevQ
            // 
            buttonPrevQ.Location = new Point(501, 207);
            buttonPrevQ.Margin = new Padding(2);
            buttonPrevQ.Name = "buttonPrevQ";
            buttonPrevQ.Size = new Size(75, 25);
            buttonPrevQ.TabIndex = 5;
            buttonPrevQ.Text = "Previous";
            buttonPrevQ.UseVisualStyleBackColor = true;
            buttonPrevQ.Click += buttonPrevQ_Click;
            // 
            // buttonNextQ
            // 
            buttonNextQ.Location = new Point(501, 270);
            buttonNextQ.Margin = new Padding(2);
            buttonNextQ.Name = "buttonNextQ";
            buttonNextQ.Size = new Size(75, 25);
            buttonNextQ.TabIndex = 6;
            buttonNextQ.Text = "Next";
            buttonNextQ.UseVisualStyleBackColor = true;
            buttonNextQ.Click += buttonNextQ_Click;
            // 
            // buttonControl
            // 
            buttonControl.Location = new Point(501, 332);
            buttonControl.Margin = new Padding(2);
            buttonControl.Name = "buttonControl";
            buttonControl.Size = new Size(75, 25);
            buttonControl.TabIndex = 7;
            buttonControl.Text = "Finish";
            buttonControl.UseVisualStyleBackColor = true;
            buttonControl.Click += buttonControl_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(44, 453);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(439, 25);
            progressBar1.TabIndex = 8;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Location = new Point(501, 457);
            labelTimer.Margin = new Padding(2, 0, 2, 0);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(56, 17);
            labelTimer.TabIndex = 9;
            labelTimer.Text = "00:00:00";
            // 
            // QuizApp
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 517);
            Controls.Add(labelTimer);
            Controls.Add(progressBar1);
            Controls.Add(buttonControl);
            Controls.Add(buttonNextQ);
            Controls.Add(buttonPrevQ);
            Controls.Add(labelQuestion);
            Controls.Add(answerBox);
            Controls.Add(buttonLoad);
            Controls.Add(textBoxFileName);
            Controls.Add(labelStatus);
            Margin = new Padding(2);
            Name = "QuizApp";
            Text = "QuizApp";
            answerBox.ResumeLayout(false);
            answerBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelStatus;
        private TextBox textBoxFileName;
        private Button buttonLoad;
        private GroupBox answerBox;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label labelQuestion;
        private Button buttonPrevQ;
        private Button buttonNextQ;
        private Button buttonControl;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Label labelTimer;
    }
}
