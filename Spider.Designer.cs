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
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnReplyCount = new DataGridViewTextBoxColumn();
            ColumnAuthor = new DataGridViewTextBoxColumn();
            ColumnLastReplyUser = new DataGridViewTextBoxColumn();
            ColumnCreateTime = new DataGridViewTextBoxColumn();
            ColumnLastReplyTime = new DataGridViewTextBoxColumn();
            ColumnView = new DataGridViewButtonColumn();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            buttonLoad = new Button();
            openFileDialog1 = new OpenFileDialog();
            buttonLogin = new Button();
            buttonExport = new Button();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(12, 13);
            textBoxInput.Margin = new Padding(4);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.PlaceholderText = "请输入贴吧名称，例如：编程";
            textBoxInput.Size = new Size(734, 38);
            textBoxInput.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(758, 13);
            numericUpDown1.Margin = new Padding(4);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(170, 38);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(936, 9);
            buttonStart.Margin = new Padding(4);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(150, 46);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "开始爬取";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // labelPages
            // 
            labelPages.AutoSize = true;
            labelPages.ForeColor = SystemColors.GrayText;
            labelPages.Location = new Point(810, 60);
            labelPages.Margin = new Padding(4, 0, 4, 0);
            labelPages.Name = "labelPages";
            labelPages.Size = new Size(62, 31);
            labelPages.TabIndex = 3;
            labelPages.Text = "页数";
            labelPages.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.ForeColor = SystemColors.GrayText;
            labelName.Location = new Point(324, 60);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(110, 31);
            labelName.TabIndex = 4;
            labelName.Text = "贴吧名称";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 934);
            progressBar1.Margin = new Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1239, 46);
            progressBar1.TabIndex = 5;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 983);
            labelStatus.Margin = new Padding(4, 0, 4, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(86, 31);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "状态：";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnTitle, ColumnReplyCount, ColumnAuthor, ColumnLastReplyUser, ColumnCreateTime, ColumnLastReplyTime, ColumnView });
            dataGridView1.Location = new Point(12, 95);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1396, 833);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += DataGridView1_CellClick;
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "标题";
            ColumnTitle.MinimumWidth = 10;
            ColumnTitle.Name = "ColumnTitle";
            ColumnTitle.ReadOnly = true;
            ColumnTitle.Width = 400;
            // 
            // ColumnReplyCount
            // 
            ColumnReplyCount.HeaderText = "回复数";
            ColumnReplyCount.MinimumWidth = 10;
            ColumnReplyCount.Name = "ColumnReplyCount";
            ColumnReplyCount.ReadOnly = true;
            ColumnReplyCount.Width = 200;
            // 
            // ColumnAuthor
            // 
            ColumnAuthor.HeaderText = "作者";
            ColumnAuthor.MinimumWidth = 10;
            ColumnAuthor.Name = "ColumnAuthor";
            ColumnAuthor.ReadOnly = true;
            ColumnAuthor.Width = 200;
            // 
            // ColumnLastReplyUser
            // 
            ColumnLastReplyUser.HeaderText = "最后回复";
            ColumnLastReplyUser.MinimumWidth = 10;
            ColumnLastReplyUser.Name = "ColumnLastReplyUser";
            ColumnLastReplyUser.ReadOnly = true;
            ColumnLastReplyUser.Width = 200;
            // 
            // ColumnCreateTime
            // 
            ColumnCreateTime.HeaderText = "创建时间";
            ColumnCreateTime.MinimumWidth = 10;
            ColumnCreateTime.Name = "ColumnCreateTime";
            ColumnCreateTime.ReadOnly = true;
            ColumnCreateTime.Width = 200;
            // 
            // ColumnLastReplyTime
            // 
            ColumnLastReplyTime.HeaderText = "回复时间";
            ColumnLastReplyTime.MinimumWidth = 10;
            ColumnLastReplyTime.Name = "ColumnLastReplyTime";
            ColumnLastReplyTime.ReadOnly = true;
            ColumnLastReplyTime.Width = 200;
            // 
            // ColumnView
            // 
            ColumnView.HeaderText = "查看";
            ColumnView.MinimumWidth = 10;
            ColumnView.Name = "ColumnView";
            ColumnView.Text = "查看";
            ColumnView.UseColumnTextForButtonValue = true;
            ColumnView.Width = 200;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(12, 95);
            webView.Margin = new Padding(4);
            webView.Name = "webView";
            webView.Size = new Size(1396, 833);
            webView.TabIndex = 8;
            webView.Visible = false;
            webView.ZoomFactor = 1D;
            webView.DoubleClick += WebView_DoubleClick;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(1096, 7);
            buttonLoad.Margin = new Padding(6, 5, 6, 5);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(150, 47);
            buttonLoad.TabIndex = 9;
            buttonLoad.Text = "加载";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(1258, 7);
            buttonLogin.Margin = new Padding(6, 5, 6, 5);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(150, 47);
            buttonLogin.TabIndex = 10;
            buttonLogin.Text = "登录";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(1258, 934);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(150, 47);
            buttonExport.TabIndex = 11;
            buttonExport.Text = "导出";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // Spider
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 1023);
            Controls.Add(buttonExport);
            Controls.Add(buttonLogin);
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
            Margin = new Padding(4);
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
        private Button buttonLogin;
        private Button buttonExport;
        private SaveFileDialog saveFileDialog1;
    }
}