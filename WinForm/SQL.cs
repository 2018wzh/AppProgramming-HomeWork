using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SQL;

namespace HW
{
    public partial class SQL : Form
    {
        private SQLHelper sh;
        private string msg = string.Empty;
        private string base_sql = @"select studentNo as 学号, studentname as 姓名,CASE gender WHEN 1 THEN '男' 
                      WHEN 0 THEN '女' 
                      ELSE '其他' 
         END as 性别,Major as 专业,Intro as 简介,Phone as 手机,Province as 省份,LoginTimes as 登录次数,QQ as qq, email as 邮箱 from tblTopStudents where 1=1";

        public SQL()
        {
            InitializeComponent();
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSearch.Enabled = false;
        }

        private void SQL_Load(object sender, EventArgs e)
        {
            bindData(base_sql);
            initCombox();
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSearch.Enabled = true;
        }

        private void bindData(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }
        }

        private void initCombox()
        {
            List<string> classNames = new List<string>
            {
                "全部显示",
                "学号",
                "姓名",
                "性别",
                "专业",
                "简介",
                "手机",
                "省份",
                "登录次数",
                "qq",
                "邮箱"
            };
            comboBoxData.DataSource = classNames;
            comboBoxData.Text = "全部显示";
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            sh = new SQLHelper(); //数据库链接对象初始化
            SQL_Load(sender, e);
            string sql = "select count(*) from tblTopStudents"; //该SQL意思是，获取tblstudents的行数
            try
            {
                string? num = sh.RunSelectSQLToScalar(sql);  //一般运行查询语句
                msg = string.Format("我们班共有{0}个同学!", num);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                sh.Close();
            }
            MessageBox.Show(msg);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addStudentForm = new AddStudent();
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                bindData(base_sql); // Refresh data
                MessageBox.Show("新增成功");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string sql = base_sql;
            string filterField = comboBoxData.Text;
            string filterValue = textBox1.Text;

            if (string.IsNullOrWhiteSpace(filterValue))
            {
                bindData(base_sql);
                return;
            }

            if (filterField == "全部显示")
            {
                sql += string.Format(" and (studentNo like '%{0}%' or studentname like '%{0}%' or Major like '%{0}%' or Intro like '%{0}%' or Phone like '%{0}%' or Province like '%{0}%' or QQ like '%{0}%' or email like '%{0}%')", filterValue);
            }
            else
            {
                string dbField = "";
                switch (filterField)
                {
                    case "学号":
                        dbField = "studentNo";
                        break;
                    case "姓名":
                        dbField = "studentname";
                        break;
                    case "专业":
                        dbField = "Major";
                        break;
                    case "简介":
                        dbField = "Intro";
                        break;
                    case "手机":
                        dbField = "Phone";
                        break;
                    case "省份":
                        dbField = "Province";
                        break;
                    case "登录次数":
                        dbField = "LoginTimes";
                        break;
                    case "qq":
                        dbField = "QQ";
                        break;
                    case "邮箱":
                        dbField = "email";
                        break;
                    case "性别":
                        if (filterValue == "男")
                        {
                            sql += " and gender = 1";
                        }
                        else if (filterValue == "女")
                        {
                            sql += " and gender = 0";
                        }
                        else
                        {
                            MessageBox.Show("性别请输入 '男' 或 '女'");
                            return;
                        }
                        break;
                }

                if (!string.IsNullOrEmpty(dbField))
                {
                    if (dbField == "LoginTimes")
                    {
                        if (int.TryParse(filterValue, out int times))
                        {
                            sql += string.Format(" and {0} = {1}", dbField, times);
                        }
                        else
                        {
                            MessageBox.Show("登录次数请输入一个有效的数字。");
                            return;
                        }
                    }
                    else
                    {
                        sql += string.Format(" and {0} like '%{1}%'", dbField, filterValue);
                    }
                }
                else if (filterField != "性别")
                {
                    bindData(base_sql);
                    return;
                }
            }
            bindData(sql);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    string? studentNo = row.Cells["学号"].Value.ToString();

                    string[] fields = { "姓名", "性别", "专业", "简介", "手机", "省份", "qq", "邮箱" };
                    string fieldToUpdate = Interaction.InputBox("请选择要修改的字段: " + string.Join(", ", fields), "选择字段");

                    if (string.IsNullOrWhiteSpace(fieldToUpdate) || !fields.Contains(fieldToUpdate))
                    {
                        MessageBox.Show("无效的字段选择。");
                        return;
                    }

                    string dbField = "";
                    string currentValue = "";
                    switch (fieldToUpdate)
                    {
                        case "姓名": dbField = "studentname"; currentValue = row.Cells["姓名"].Value.ToString(); break;
                        case "性别": dbField = "gender"; currentValue = row.Cells["性别"].Value.ToString(); break;
                        case "专业": dbField = "Major"; currentValue = row.Cells["专业"].Value.ToString(); break;
                        case "简介": dbField = "Intro"; currentValue = row.Cells["简介"].Value.ToString(); break;
                        case "手机": dbField = "Phone"; currentValue = row.Cells["手机"].Value.ToString(); break;
                        case "省份": dbField = "Province"; currentValue = row.Cells["省份"].Value.ToString(); break;
                        case "qq": dbField = "qq"; currentValue = row.Cells["qq"].Value.ToString(); break;
                        case "邮箱": dbField = "email"; currentValue = row.Cells["邮箱"].Value.ToString(); break;
                    }

                    string newValue = Interaction.InputBox($"请输入新的 {fieldToUpdate}:", $"修改 {fieldToUpdate}", currentValue ?? "");

                    if (string.IsNullOrWhiteSpace(newValue))
                    {
                        return; // User cancelled
                    }

                    string sql;
                    if (dbField == "gender")
                    {
                        int genderValue;
                        if (newValue == "男") genderValue = 1;
                        else if (newValue == "女") genderValue = 0;
                        else
                        {
                            MessageBox.Show("性别请输入 '男' 或 '女'。");
                            return;
                        }
                        sql = string.Format("UPDATE tblTopStudents SET {0} = {1}, LoginTimes = LoginTimes + 1 WHERE studentNo = '{2}'", dbField, genderValue, studentNo);
                    }
                    else
                    {
                        sql = string.Format("UPDATE tblTopStudents SET {0} = '{1}', LoginTimes = LoginTimes + 1 WHERE studentNo = '{2}'", dbField, newValue, studentNo);
                    }

                    int ret = sh.RunSQL(sql);
                    if (ret > 0)
                    {
                        msg = "修改成功";
                        bindData(base_sql);
                    }
                    else
                    {
                        msg = "修改失败";
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    sh.Close();
                }
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("请先选择一行进行修改。");
            }
        }
    }
}
