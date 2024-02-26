using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class register3 : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);

        private string sfrom = "3513911134@qq.com";
        private string sfromer = "江苏省职业技术教育学会";
        private string sSMTPHost = "smtp.qq.com";
        private string sSMTPuser = "3513911134@qq.com";
        private string sSMTPpass = "nbwdxcwjpmuocjfd";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
        public bool a = true;
        public bool b = true;
        public bool c = true;
        public bool d = true;
        public bool f = true;
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                g1.Style.Add("color", "red");
                g1.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g1.Style.Add("border", "1px solid #f1bdbd");
                a = false;
            }
            else
            {
                g1.Style.Add("color", "black");
                g1.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g1.Style.Add("border", " 1px solid #bde2f1");
                a = true;
            }
            if (txt_yzm.Text == "")
            {
                g2.Style.Add("color", "red");
                g2.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g2.Style.Add("border", "1px solid #f1bdbd");
                b = false;
            }
            else
            {
                g2.Style.Add("color", "black");
                g2.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g2.Style.Add("border", " 1px solid #bde2f1");
                b = true;
            }
            if (txt_password.Text == "")
            {
                g3.Style.Add("color", "red");
                g3.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g3.Style.Add("border", "1px solid #f1bdbd");
                c = false;
            }
            else
            {
                g3.Style.Add("color", "black");
                g3.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g3.Style.Add("border", " 1px solid #bde2f1");
                c = true;
            }
            if (txt_password.Text == "" && txt_repeatpassword.Text == "" || txt_password.Text != txt_repeatpassword.Text)
            {
                g4.Style.Add("color", "red");
                g4.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g4.Style.Add("border", "1px solid #f1bdbd");
                g4.Style.Add("display", "block");
                d = false;
            }
            else
            {
                g4.Style.Add("display", "none");
                d = true;
            }
            if (a == true && b == true && c == true && d == true)
            {
                if (Session["VE"].ToString() != txt_yzm.Text)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('验证码不正确！')</script>");
                }
                else
                {
                    string sql1 = "select * from membership where name='" + txt_name.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    object obj = new object();
                    conn.Open();
                    obj = cmd1.ExecuteScalar();
                    conn.Close();
                    if (obj == null)
                    {
                        string sql2 = "select * from membership where email='" + txt_email.Text + "'";
                        SqlCommand cmd2 = new SqlCommand(sql2, conn);
                        object obj1 = new object();
                        conn.Open();
                        obj1 = cmd2.ExecuteScalar();
                        conn.Close();
                        if (obj1 == null)
                        {
                            string password = txt_password.Text;
                            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower();
                            string sql = "update membership set name='" + txt_name.Text + "',email='" + txt_email.Text + "',password='" + password + "' where id='" + Session["ID"].ToString() + "'";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            conn.Open();
                            cmd.ExecuteReader();
                            conn.Close();
                            Response.Redirect("register4.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('该邮箱已被注册！')</script>");
                        }

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('用户名重复了！换一个试试呢？')</script>");
                        txt_name.Text = "";
                    }

                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!r.IsMatch(txt_email.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('这不是一个正确的邮箱！')</script>");
                spanyz.InnerText = "no";
            }
            else
            {
                spanyz.InnerText = "ok";
                sendEmail();

            }

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
        public string verificationcode = "";
        public void sendEmail()
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("3513911134@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(txt_email.Text));
            //邮件标题。
            mailMessage.Subject = "江苏省职业教育平台验证码";
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
            //Response.Write("<script>alert('验证码发送成功！请注意查收并及时填写验证码！')</script>");

            Session["VE"] = verificationcode;
        }
    }
}