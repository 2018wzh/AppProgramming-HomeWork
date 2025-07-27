namespace HW
{
    partial class NER
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
            textBoxInput = new TextBox();
            textBoxOutput = new TextBox();
            buttonRun = new Button();
            buttonClear = new Button();
            labelInput = new Label();
            labelOutput = new Label();
            treeViewResult = new TreeView();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(10, 40);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(666, 113);
            textBoxInput.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(10, 249);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(666, 339);
            textBoxOutput.TabIndex = 1;
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(10, 170);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(88, 34);
            buttonRun.TabIndex = 2;
            buttonRun.Text = "开始识别";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(114, 170);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(88, 34);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "清空输出";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(10, 17);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(59, 17);
            labelInput.TabIndex = 5;
            labelInput.Text = "输入文本:";
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(10, 227);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(59, 17);
            labelOutput.TabIndex = 6;
            labelOutput.Text = "识别结果:";
            // 
            // treeViewResult
            // 
            treeViewResult.Location = new Point(681, 40);
            treeViewResult.Name = "treeViewResult";
            treeViewResult.Size = new Size(219, 549);
            treeViewResult.TabIndex = 7;
            // 
            // NER
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 613);
            Controls.Add(treeViewResult);
            Controls.Add(labelOutput);
            Controls.Add(labelInput);
            Controls.Add(buttonClear);
            Controls.Add(buttonRun);
            Controls.Add(textBoxOutput);
            Controls.Add(textBoxInput);
            Name = "NER";
            Text = "BERT中文命名实体识别";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TreeView treeViewResult;
    }
}