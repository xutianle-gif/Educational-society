using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class userpass : System.Web.UI.Page
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
                if (Request["ID"] == null)
                {
                    Response.Write("<script>alert('非法操作！');window.location.href='backindex.aspx'</script>");
                }
                else
                {
                    dateload();
                }
            }
        }

        public void dateload()
        {
            string sql = "select membership.id,name,unitname,unitmanager,location,address,license,tel,email,frontcard,backcard,handcard,tname,unitType from membership,annex where annex.ID=membership.ID and  membership.ID=" + Request["ID"].ToString() + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lb_tname.Text = dr["tname"].ToString();
                lb_unit.Text = dr["unitType"].ToString();
                lb_tel.Text = dr["tel"].ToString();
                lb_name.Text = dr["unitname"].ToString();
                lb_fname.Text = dr["unitmanager"].ToString();
                lb_email.Text = dr["email"].ToString();
                lb_address2.Text = dr["address"].ToString();
                lb_address.Text = dr["location"].ToString();
                img1.ImageUrl = dr["license"].ToString();
                img2.ImageUrl = dr["frontcard"].ToString();
                img3.ImageUrl = dr["backcard"].ToString();
                img4.ImageUrl = dr["handcard"].ToString();
            }
            conn.Close();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("backindex.aspx");
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (rb1.Checked == true)
            {
                string sql = "update membership set result='已通过',addtime='" + DateTime.Now.ToString("yyyy/MM/dd") + "' where id='" + Request["id"] + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                insert();
                emails();
                email();
            }
            if (rb2.Checked == true)
            {
                string sql = "update membership set result='驳回' where id='" + Request["id"] + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                email2();
            }
        }
        public void email()
        {
            string sql = "select count(*) from YearManage where paystatus='启用'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar()), qb = 1;
            string[] art = new string[count];
            string[] title = new string[count];
            conn.Close();
            for (int i = 0; i < count; i++)
            {
                sql = "select top 1 * from (select top " + qb + " * from YearManage where paystatus='启用' order by payid) as a order by payid desc ";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    art[i] = dr["paytext"].ToString();
                    title[i] = dr["payyear"].ToString() + "年会费缴纳通知";
                }
                conn.Close();
                string content = art[i];
                MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                MailAddress to = new MailAddress(lb_email.Text);//收件人地址对象
                MailMessage oMail = new MailMessage(from, to);
                oMail.Subject = title[i];//设置邮件标题
                oMail.Body = content;//设置邮件文本内容
                oMail.IsBodyHtml = false;//设置为HTML格式
                oMail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//正文编码
                oMail.Priority = MailPriority.High;//优先级
                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;//由于使用了授权码必须设置该属性为true
                client.Host = sSMTPHost;//指定SMTP服务器
                client.Credentials = new NetworkCredential(sSMTPuser, sSMTPpass);//邮箱的用户名和密码，注意使用qq邮箱时密码使用的是授权码
                client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
                client.Send(oMail);
                oMail.Dispose();
                qb++;
            }
            Response.Write("<script>alert('操作已完成！');window.location.href='backindex.aspx'</script>");
        }

        public void insert()
        {
            string sql = "select count(*) from YearManage where paystatus='启用'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar()), qb = 1;
            string[] year = new string[count];
            conn.Close();
            for (int i = 0; i < count; i++)
            {
                sql = "select top 1 * from (select top " + qb + " * from YearManage where paystatus='启用' order by payid) as a order by payid desc ";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    year[i] = dr["payid"].ToString();
                } conn.Close();
                sql = "insert into voucherManage(voucherid,payid,id,voucherimg,voucherstatus,details) values('" + DateTime.Now.ToString("yyyyMMddhhmmss") + "" + i + "','" + year[i] + "','" + Request["id"] + "','~/img/1.jpg','待缴费','无')";
                SqlCommand cmd3 = new SqlCommand(sql, conn);
                conn.Open();
                cmd3.ExecuteScalar();
                conn.Close();
                qb++;
            }
        }

        public void email2()
        {
            string content = txt_back.InnerText;
            MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
            MailAddress to = new MailAddress(lb_email.Text);//收件人地址对象
            MailMessage oMail = new MailMessage(from, to);
            oMail.Subject = "江苏省职业技术教育学会申请结果反馈";//设置邮件标题
            oMail.Body = "很抱歉，您递交的江苏省职业技术教育学会申请没有通过审核，可能是以下原因：" + content + ",请核对后重新发送申请！";//设置邮件文本内容
            oMail.IsBodyHtml = false;//设置为HTML格式
            oMail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//正文编码
            oMail.Priority = MailPriority.High;//优先级
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;//由于使用了授权码必须设置该属性为true
            client.Host = sSMTPHost;//指定SMTP服务器
            client.Credentials = new NetworkCredential(sSMTPuser, sSMTPpass);//邮箱的用户名和密码，注意使用qq邮箱时密码使用的是授权码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            client.Send(oMail);
            oMail.Dispose();
            Response.Write("<script>alert('操作已完成！');window.location.href='backindex.aspx'</script>");
        }

        public void emails()
        {
            string content = txt_back.InnerText;
            MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
            MailAddress to = new MailAddress(lb_email.Text);//收件人地址对象
            MailMessage oMail = new MailMessage(from, to);
            oMail.Subject = "江苏省职业技术教育学会申请结果反馈";//设置邮件标题
            oMail.Body = "您递交的江苏省职业技术教育学会申请已通过审核！";//设置邮件文本内容
            oMail.IsBodyHtml = false;//设置为HTML格式
            oMail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//正文编码
            oMail.Priority = MailPriority.High;//优先级
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;//由于使用了授权码必须设置该属性为true
            client.Host = sSMTPHost;//指定SMTP服务器
            client.Credentials = new NetworkCredential(sSMTPuser, sSMTPpass);//邮箱的用户名和密码，注意使用qq邮箱时密码使用的是授权码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            client.Send(oMail);
            oMail.Dispose();
            Response.Write("<script>alert('操作已完成！');window.location.href='backindex.aspx'</script>");
        }

        protected void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2.Checked == true)
            {
                tr_back.Visible = true;
            }
        }

        protected void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1.Checked == true)
            {
                tr_back.Visible = false;
            }
        }

       
    }
}