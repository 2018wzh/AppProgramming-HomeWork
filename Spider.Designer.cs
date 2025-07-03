namespace HW
{
    partial class Spider
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
            numericUpDown1 = new NumericUpDown();
            buttonStart = new Button();
            labelPages = new Label();
            labelName = new Label();
            progressBar1 = new ProgressBar();
            labelStatus = new Label();
            dataGridView1 = new DataGridView();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            buttonLoad = new Button();
            openFileDialog1 = new OpenFileDialog();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnReplyCount = new DataGridViewTextBoxColumn();
            ColumnAuthor = new DataGridViewTextBoxColumn();
            ColumnLastReplyUser = new DataGridViewTextBoxColumn();
            ColumnCreateTime = new DataGridViewTextBoxColumn();
            ColumnLastReplyTime = new DataGridViewTextBoxColumn();
            ColumnView = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(6, 7);
            textBoxInput.Margin = new Padding(2);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.PlaceholderText = "请输入贴吧名称，例如：编程";
            textBoxInput.Size = new Size(445, 23);
            textBoxInput.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(455, 7);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(85, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(549, 6);
            buttonStart.Margin = new Padding(2);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 25);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "开始爬取";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // labelPages
            // 
            labelPages.AutoSize = true;
            labelPages.ForeColor = SystemColors.GrayText;
            labelPages.Location = new Point(481, 33);
            labelPages.Margin = new Padding(2, 0, 2, 0);
            labelPages.Name = "labelPages";
            labelPages.Size = new Size(32, 17);
            labelPages.TabIndex = 3;
            labelPages.Text = "页数";
            labelPages.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.ForeColor = SystemColors.GrayText;
            labelName.Location = new Point(251, 33);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(56, 17);
            labelName.TabIndex = 4;
            labelName.Text = "贴吧名称";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 512);
            progressBar1.Margin = new Padding(2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(698, 25);
            progressBar1.TabIndex = 5;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(6, 539);
            labelStatus.Margin = new Padding(2, 0, 2, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(44, 17);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "状态：";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnTitle, ColumnReplyCount, ColumnAuthor, ColumnLastReplyUser, ColumnCreateTime, ColumnLastReplyTime, ColumnView });
            dataGridView1.Location = new Point(6, 52);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(698, 457);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += DataGridView1_CellClick;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(6, 52);
            webView.Margin = new Padding(2);
            webView.Name = "webView";
            webView.Size = new Size(698, 457);
            webView.TabIndex = 8;
            webView.Visible = false;
            webView.ZoomFactor = 1D;
            webView.DoubleClick += WebView_DoubleClick;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(629, 7);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 9;
            buttonLoad.Text = "加载";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "标题";
            ColumnTitle.Name = "ColumnTitle";
            ColumnTitle.ReadOnly = true;
            ColumnTitle.Width = 400;
            // 
            // ColumnReplyCount
            // 
            ColumnReplyCount.HeaderText = "回复数";
            ColumnReplyCount.Name = "ColumnReplyCount";
            ColumnReplyCount.ReadOnly = true;
            // 
            // ColumnAuthor
            // 
            ColumnAuthor.HeaderText = "作者";
            ColumnAuthor.Name = "ColumnAuthor";
            ColumnAuthor.ReadOnly = true;
            // 
            // ColumnLastReplyUser
            // 
            ColumnLastReplyUser.HeaderText = "最后回复";
            ColumnLastReplyUser.Name = "ColumnLastReplyUser";
            ColumnLastReplyUser.ReadOnly = true;
            // 
            // ColumnCreateTime
            // 
            ColumnCreateTime.HeaderText = "创建时间";
            ColumnCreateTime.Name = "ColumnCreateTime";
            ColumnCreateTime.ReadOnly = true;
            // 
            // ColumnLastReplyTime
            // 
            ColumnLastReplyTime.HeaderText = "回复时间";
            ColumnLastReplyTime.Name = "ColumnLastReplyTime";
            ColumnLastReplyTime.ReadOnly = true;
            // 
            // ColumnView
            // 
            ColumnView.HeaderText = "查看";
            ColumnView.Name = "ColumnView";
            ColumnView.Text = "查看";
            ColumnView.UseColumnTextForButtonValue = true;
            // 
            // Spider
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 561);
            Controls.Add(buttonLoad);
            Controls.Add(dataGridView1);
            Controls.Add(labelStatus);
            Controls.Add(progressBar1);
            Controls.Add(labelName);
            Controls.Add(labelPages);
            Controls.Add(buttonStart);
            Controls.Add(numericUpDown1);
            Controls.Add(textBoxInput);
            Controls.Add(webView);
            Margin = new Padding(2);
            Name = "Spider";
            Text = "百度贴吧爬虫";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxInput;
        private NumericUpDown numericUpDown1;
        private Button buttonStart;
        private Label labelPages;
        private Label labelName;
        private ProgressBar progressBar1;
        private Label labelStatus;
        private DataGridView dataGridView1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button buttonLoad;
        private OpenFileDialog openFileDialog1;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnReplyCount;
        private DataGridViewTextBoxColumn ColumnAuthor;
        private DataGridViewTextBoxColumn ColumnLastReplyUser;
        private DataGridViewTextBoxColumn ColumnCreateTime;
        private DataGridViewTextBoxColumn ColumnLastReplyTime;
        private DataGridViewButtonColumn ColumnView;
    }
}