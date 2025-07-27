using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQL;
using SecurityUtils;

namespace HW
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            comboBoxGender.Items.Add("男");
            comboBoxGender.Items.Add("女");
            comboBoxGender.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBoxId.Text) ||
                string.IsNullOrWhiteSpace(textBoxStudentNo.Text) ||
                string.IsNullOrWhiteSpace(textBoxStudentName.Text) ||
                string.IsNullOrWhiteSpace(textBoxMajor.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("ID、学号、姓名、专业和密码不能为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!int.TryParse(textBoxId.Text, out int id))
            {
                MessageBox.Show("ID必须为数字。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int gender = comboBoxGender.SelectedIndex == 0 ? 1 : 0;

            var sh = new SQLHelper();
            string msg = string.Empty;
            try
            {
                string salt;
                string hashedPassword = PasswordHelper.CreateHash(textBoxPassword.Text, out salt);

                string sql = string.Format(@"INSERT INTO tblTopStudents (id, studentNo, studentname, gender, Major, Intro, Phone, Province, birthday, pwd, salt, LoginTimes, Status, QQ, Email) 
                                             VALUES ({0}, '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', 0, 1, '{11}', '{12}')",
                                             id, textBoxStudentNo.Text, textBoxStudentName.Text, gender, textBoxMajor.Text,
                                             textBoxIntro.Text, textBoxPhone.Text, textBoxProvince.Text, dateTimePickerBirthday.Value.ToString("yyyy-MM-dd"),
                                             hashedPassword, salt, textBoxQQ.Text, textBoxEmail.Text);

                int ret = sh.RunSQL(sql);
                if (ret > 0)
                {
                    msg = "新增成功";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    msg = "新增失败";
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
            if (this.DialogResult != DialogResult.OK)
            {
                MessageBox.Show(msg);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
