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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExample = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.treeViewResult = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 35);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(760, 100);
            this.textBoxInput.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 220);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(760, 300);
            this.textBoxOutput.TabIndex = 1;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 150);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(100, 30);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "开始识别";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(130, 150);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 30);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "清空输出";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonExample
            // 
            this.buttonExample.Location = new System.Drawing.Point(248, 150);
            this.buttonExample.Name = "buttonExample";
            this.buttonExample.Size = new System.Drawing.Size(100, 30);
            this.buttonExample.TabIndex = 4;
            this.buttonExample.Text = "加载示例";
            this.buttonExample.UseVisualStyleBackColor = true;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 15);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(68, 15);
            this.labelInput.TabIndex = 5;
            this.labelInput.Text = "输入文本:";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(12, 200);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(68, 15);
            this.labelOutput.TabIndex = 6;
            this.labelOutput.Text = "识别结果:";
            // 
            // treeViewResult
            // 
            this.treeViewResult.Location = new System.Drawing.Point(778, 35);
            this.treeViewResult.Name = "treeViewResult";
            this.treeViewResult.Size = new System.Drawing.Size(250, 485);
            this.treeViewResult.TabIndex = 7;
            // 
            // NER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 541);
            this.Controls.Add(this.treeViewResult);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.buttonExample);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Name = "NER";
            this.Text = "BERT中文命名实体识别";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExample;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TreeView treeViewResult;
    }
}