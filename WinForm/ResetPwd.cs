using SecurityUtils;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW
{
    public partial class ResetPwd : Form
    {
        private SQLHelper _sql;
        private string _code;
        public ResetPwd()
        {
            InitializeComponent();
            _sql = new SQLHelper();
        }

        private void buttonSendCode_Click(object sender, EventArgs e)
        {
            string mail = textBoxEmail.Text;
            string msg = "验证码已发送，请注意查收";
            try
            {
                string sql = string.Format("select count(*) from tbltopstudents where email='{0}'", mail);
                string ret = _sql.RunSelectSQLToScalar(sql); //一般运行 查询之外的删、改、增
                if (ret == "0")
                {
                    MessageBox.Show("邮箱不存在，请检查后重试");
                    return;
                }

                _code = CommFunction.GenerateSafeCode();
                MessageBox.Show("验证码：" + _code, "验证码", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!CommFunction.SendVerificationEmail(mail, _code))
                {
                    MessageBox.Show("验证码发送失败，请检查网络连接或联系管理员", "发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(msg);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                _sql.Close();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text != _code)
            {
                MessageBox.Show("验证码错误，请重试");
                return;
            }
            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }

            try
            {
                string salt;
                string hashedPassword = PasswordHelper.CreateHash(textBoxNewPassword.Text, out salt);
                string sql = string.Format("update tbltopstudents set pwd='{0}', salt='{1}' where email='{2}'",
                                             hashedPassword, salt, textBoxEmail.Text);
                int ret = _sql.RunSQL(sql);
                if (ret > 0)
                {
                    MessageBox.Show("密码重置成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码重置失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _sql.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
