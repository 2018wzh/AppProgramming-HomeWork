namespace HW
{
    partial class SQL
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
            dataGridView1 = new DataGridView();
            buttonRefresh = new Button();
            buttonSearch = new Button();
            textBox1 = new TextBox();
            comboBoxData = new ComboBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(71, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(639, 382);
            dataGridView1.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(71, 449);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 1;
            buttonRefresh.Text = "刷新";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(635, 449);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "查询";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(529, 449);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // comboBoxData
            // 
            comboBoxData.FormattingEnabled = true;
            comboBoxData.Location = new Point(402, 449);
            comboBoxData.Name = "comboBoxData";
            comboBoxData.Size = new Size(121, 25);
            comboBoxData.TabIndex = 4;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(152, 449);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "新增";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(233, 449);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 6;
            buttonUpdate.Text = "修改";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // SQL
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 524);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(comboBoxData);
            Controls.Add(textBox1);
            Controls.Add(buttonSearch);
            Controls.Add(buttonRefresh);
            Controls.Add(dataGridView1);
            Name = "SQL";
            Text = "SQL";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonRefresh;
        private Button buttonSearch;
        private TextBox textBox1;
        private ComboBox comboBoxData;
        private Button buttonAdd;
        private Button buttonUpdate;
    }
}