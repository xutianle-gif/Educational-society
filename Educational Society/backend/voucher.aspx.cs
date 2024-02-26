using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class voucher : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        private string sfrom = "3513911134@qq.com";
        private string sfromer = "江苏省职业技术教育学会";
        private string sSMTPHost = "smtp.qq.com";
        private string sSMTPuser = "3513911134@qq.com";
        private string sSMTPpass = "nbwdxcwjpmuocjfd";
        string art = "您的凭证审核未通过，请您核对后重新上传！";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    dateload();
                    drop();
                    DropDownList1.Items.Insert(0, new ListItem("全部"));
                }
                else
                {
                    Response.Redirect("../frontend/Login.aspx");
                }

            }
        }

        public void dateload(string searchstr = "")
        {
            string sql = "select Row_Number()over(order by voucherid) as xuhao,voucherid,payyear,unitname,unitType,unitmanager,membership.addtime,paymoney,voucherimg from membership,voucherManage,YearManage where voucherManage.id=membership.id and voucherManage.payid=YearManage.payid ";
            if (searchstr.Trim() != "where")
            {
                sql = "select Row_Number()over(order by voucherid) as xuhao,voucherid,payyear,unitname,unitType,unitmanager,membership.addtime,paymoney,voucherimg from membership,voucherManage,YearManage where voucherManage.id=membership.id and voucherManage.payid=YearManage.payid " + searchstr + "";
            }
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            tb_user.DataSource = ds;
            tb_user.DataBind();
            conn.Close();

        }

        public void drop()
        {
            string sql = "select distinct payyear,YearManage.payid as payid from voucherManage,YearManage where YearManage.payid=voucherManage.payid";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            DropDownList1.DataTextField = "payyear";
            DropDownList1.DataValueField = "payid";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
        }


        protected void btn_add_Click(object sender, EventArgs e)
        {
            string sql = "update voucherManage set details='" + txt_art.InnerText + "' where voucherid='" + test.Value + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
            sql = "select payyear,email from YearManage,voucherManage,membership where voucherManage.payid=YearManage.payid and membership.id=voucherManage.id and voucherid='" + test.Value + "'";
            SqlCommand cmd2 = new SqlCommand(sql, conn);
            conn.Open();
            string year = "", email = "";
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                year = dr["payyear"].ToString();
                email = dr["email"].ToString();
            }
            conn.Close();
            if (txt_art.InnerText != "")
            {
                art = txt_art.InnerText;
            }
            MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
            MailAddress to = new MailAddress(email);//收件人地址对象
            MailMessage oMail = new MailMessage(from, to);
            oMail.Subject = "江苏省职业教育学会" + year + "年会费缴费结果";//设置邮件标题
            oMail.Body = art;//设置邮件文本内容
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
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('处理完成！')</script>");
            dateload();
        }

        protected void tb_user_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tb_user_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "pass")
            {
                string id = e.CommandArgument.ToString();
                string sql = "update voucherManage set voucherstatus='已缴费',details='已通过' where voucherid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                sql = "select payyear,email from YearManage,voucherManage,membership where voucherManage.payid=YearManage.payid and membership.id=voucherManage.id and voucherid='" + id + "'";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                string year = "", email = "";
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    year = dr["payyear"].ToString();
                    email = dr["email"].ToString();
                }
                conn.Close();
                MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                MailAddress to = new MailAddress(email);//收件人地址对象
                MailMessage oMail = new MailMessage(from, to);
                oMail.Subject = "江苏省职业教育学会" + year + "年会费缴费结果";//设置邮件标题
                oMail.Body = "您的会费缴纳已通过审核，非常感谢您的支持！";//设置邮件文本内容
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
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('处理完成！')</script>");
                dateload();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "";
            if (DropDownList1.Text != "全部")
            {
                str = " and voucherManage.payid='" + DropDownList1.SelectedValue + "'";
            }
            dateload(str);
        }

        protected void tb_user_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}