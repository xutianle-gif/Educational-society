using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Educational_Society.frontend
{
    public partial class FindPassword : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        public static bool x = false;//判断值是否正确

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void lbFind_Click(object sender, EventArgs e)
        {
            check();
        }

        public void check()
        {
            string sql = "select * from membership where name='" + txtuser.Text + "' and email='" + txtEmail.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            if (cmd.ExecuteScalar() == null)
            {
                conn.Close();
                Response.Write("<script>alert('用户名和邮箱不匹配！');</script>");
            }
            else
            {
                conn.Close();
                sendEmail();
            }

        }

        public string verificationcode = "";
        public void sendEmail()
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("3513911134@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(txtEmail.Text));
            //邮件标题。
            mailMessage.Subject = "江苏省职业教育平台密码找回";
            verificationcode = createrandom(6);
            //邮件内容。
            mailMessage.Body = "你的验证码是" + verificationcode;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("3513911134@qq.com", "nbwdxcwjpmuocjfd");
            //发送
            client.Send(mailMessage);
            Response.Write("<script>alert('验证码发送成功！请注意查收并及时填写验证码！')</script>");

            Session["VE"] = verificationcode;
        }

        private string createrandom(int codelengh)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codelengh; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (x == false)
            {
                txtCode.Text = "";
                txtNewpassword.Text = "";
                txtRepeatNewpassword.Text = "";
                Response.Write("<script>alert('验证码错误！请重新获取并填写验证码！')</script>");
            }
            else
            {
                if (txtNewpassword.Text == txtRepeatNewpassword.Text)
                {
                    string sql = "update membership set password='" + txtNewpassword.Text + "' where name='" + txtuser.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                    Response.Write("<script>alert('密码修改成功！请登录');window.location.href='Login.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('两次密码不一致')</script>");
                }
            }
        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == Session["VE"].ToString())
                {
                    x = true;
                }
                else
                {
                    x = false;
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('您还没有获取验证码！')</script>");
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}