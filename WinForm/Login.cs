using Microsoft.VisualBasic;
using Newtonsoft.Json;
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
    public partial class Login : Form
    {
        private SQLHelper _sql;
        private string _username, _password;
        private bool isAutoLogin, isRememberPassword, isLoginSuccess;
        private static string configFile = "user.json";
        public Login()
        {
            InitializeComponent();
            _username = "";
            _password = "";
            _sql = new SQLHelper();
            this.StartPosition = FormStartPosition.CenterScreen;
            AppInit();
        }

        private void LoadConfig()
        {
            if (!System.IO.File.Exists(configFile))
            {
                SaveConfig();
                return;
            }
            string json = System.IO.File.ReadAllText(configFile);
            try
            {
                var jsonData = JsonConvert.DeserializeAnonymousType(json, new
                {
                    username = "",
                    password = "",
                    autoLogin = false,
                    rememberPassword = false
                });
                _username = jsonData.username;
                _password = jsonData.password;
                isAutoLogin = jsonData.autoLogin;
                isRememberPassword = jsonData.rememberPassword;
            }
            catch (JsonException)
            {
                MessageBox.Show("配置文件格式错误，请检查 config.json 文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(new
            {
                username = _username,
                password = _password,
                autoLogin = isAutoLogin,
                rememberPassword = isRememberPassword
            }, Formatting.Indented);
            try
            {
                System.IO.File.WriteAllText(configFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存配置文件失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AppInit()
        {
            LoadConfig();
            isLoginSuccess = false;
            if (isAutoLogin)
            {
                textBoxUsername.Text = _username;
                textBoxPassword.Text = _password;
                checkBoxRemeberMe.Checked = isRememberPassword;
                UserLogin();
            }
            else
            {
                textBoxUsername.Text = _username;
                textBoxPassword.Text = "";
                checkBoxRemeberMe.Checked = isRememberPassword;
            }
        }
        private void UserLogin()
        {
            _username = textBoxUsername.Text.Trim();
            _password = textBoxPassword.Text.Trim();
            string sql = string.Format("select pwd,salt from tblTopstudents where studentNo='{0}'", _username);
            try
            {
                DataSet ds = new DataSet();
                _sql.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                //1个dataset包含落干个datatable
                if (dt.Rows.Count > 0)
                {
                    string pwd = dt.Rows[0]["pwd"].ToString();
                    string salt = dt.Rows[0]["salt"].ToString();
                    if (PasswordHelper.VerifyHash(_password, salt, pwd))//登录成功的逻辑
                    {
                        SaveConfig();
                        isLoginSuccess = true;
                        MessageBox.Show("登陆成功");
                        this.Hide();
                    }
                    else
                        MessageBox.Show("密码不匹配！");
                }
                else
                {
                    MessageBox.Show("学号不存在！");
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
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoLogin.Checked)
            {
                isAutoLogin = true;
            }
            else
            {
                isAutoLogin = false;
            }
        }

        private void checkBoxRemeberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRemeberMe.Checked)
            {
                isRememberPassword = true;
            }
            else
            {
                isRememberPassword = false;
                isAutoLogin = false;
                checkBoxAutoLogin.Checked = false;
            }
        }

        private void buttonForget_Click(object sender, EventArgs e)
        {
            var wnd = new ResetPwd();
            wnd.Show();
        }
    }
}
