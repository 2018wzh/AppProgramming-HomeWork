using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW
{
    //static的意思是这个类在访问的时候不需要实例化
    public static class CommFunction
    {
        public static bool SendVerificationEmail(string email, string code)
        {
            try
            {

                // 配置 SMTP 客户端
                using (SmtpClient client = new SmtpClient("smtp.163.com", 25))  //本地使用25，云端可使用587
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("puxiaoming@163.com", "YQZUOJVTXJXYYJPL"); //授权码

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("puxiaoming@163.com", "系统管理员");
                    mail.To.Add(email);
                    mail.Subject = "密码重置验证码";

                    // 创建HTML格式的邮件内容
                    string htmlBody = $@"
            <html>
            <body>
                <h3>密码重置请求</h3>
                <p>您正在尝试重置密码，您的验证码是:</p>
                <h2 style='color: #3498db;'>{code}</h2>
                <p>请在10分钟内使用此验证码完成密码重置。</p>
                <p>如果您没有请求重置密码，请忽略此邮件。</p>
                <hr>
                <p style='color: #7f8c8d;'>此邮件由系统自动发送，请勿回复。</p>
            </body>
            </html>";

                    mail.Body = htmlBody;
                    mail.IsBodyHtml = true;

                    // 添加替代视图
                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                        $"您的验证码是: {code}\n\n请在10分钟内完成验证。",
                        null, "text/plain");

                    mail.AlternateViews.Add(plainView);
                    
                    client.Send(mail);
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                System.Console.Write($"SMTP错误: {ex.StatusCode} - {ex.Message}");
                MessageBox.Show("邮件发送失败，请检查网络连接或联系管理员", "发送错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                System.Console.Write($"邮件发送失败: {ex.Message}");
                MessageBox.Show("邮件发送失败，请稍后再试", "发送错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static string GenerateSafeCode(int length = 6)
        {
            Random random = new Random();
            // 排除易混淆字符: 1/l/I, 0/O, 2/Z, 5/S, 8/B 等
            const string chars = "34679ACDEFGHJKMNPRTUVWXY";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
