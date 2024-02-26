using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class Payyear : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        private string sfrom = "3513911134@qq.com";
        private string sfromer = "江苏省职业技术教育学会";
        private string sSMTPHost = "smtp.qq.com";
        private string sSMTPuser = "3513911134@qq.com";
        private string sSMTPpass = "nbwdxcwjpmuocjfd";
        string art = "新的会费缴纳已经出炉，请尽快缴费并上传凭证,谢谢合作！";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    dateload();
                }
                else
                {
                    Response.Redirect("../frontend/Login.aspx");
                }
            }
        }


        public void dateload()
        {
            string sql = "select Row_Number()over(order by payid) as xuhao,payid,payyear,paytext,paymoney,paystatus from YearManage";
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            tb_user.DataSource = ds;
            tb_user.DataBind();
            conn.Close();
            preview();
        }

        public void preview()
        {
            string sql = "select paystatus from YearManage";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                for (int i = 0; i < tb_user.Rows.Count; i++)
                {
                    Label PaymentStatus = tb_user.Rows[i].FindControl("lblPaymentStatus") as Label;

                    if (PaymentStatus.Text == "禁用")
                    {
                        LinkButton Upload = tb_user.Rows[i].FindControl("lkbOpen") as LinkButton;
                        LinkButton Download = tb_user.Rows[i].FindControl("lkbFrozen") as LinkButton;
                        Upload.Visible = true;
                        Download.Visible = false;
                    }
                    else
                    {

                        LinkButton Upload = tb_user.Rows[i].FindControl("lkbOpen") as LinkButton;
                        LinkButton Download = tb_user.Rows[i].FindControl("lkbFrozen") as LinkButton;

                        Upload.Visible = false;
                        Download.Visible = true;
                    }
                }
            }

            conn.Close();
        }



        public void insert()
        {
            string sql = "select count(*) from membership where result='已通过' and state='启用'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar()), qb = 1;
            string[] id = new string[count];
            conn.Close();
            for (int i = 0; i < count; i++)
            {
                sql = "select top 1 * from (select top " + qb + " * from membership where result='已通过' and state='启用' order by id) as a order by id desc ";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    id[i] = dr["id"].ToString();
                }
                conn.Close();
                sql = "select payid from YearManage where payyear='" + txt_year.Text + "'";
                SqlCommand cmd3 = new SqlCommand(sql, conn);
                conn.Open();
                string yearid = Convert.ToString(cmd3.ExecuteScalar());
                conn.Close();
                string sqlselect = "select * from voucherManage where id=" + id[i] + " and payid='" + yearid + "'";
                conn.Open();
                SqlCommand cmd5 = new SqlCommand(sqlselect, conn);
                if (cmd5.ExecuteScalar() == null)
                {
                    conn.Close();
                    sql = "insert into voucherManage(voucherid,payid,id,voucherimg,voucherstatus,details) values('" + DateTime.Now.ToString("yyyyMMddhhmmss") + "" + i + "','" + yearid + "','" + id[i] + "','~/img/1.jpg','待缴费','无')";
                    SqlCommand cmd4 = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd4.ExecuteReader();
                    conn.Close();

                }
                else 
                {
                    conn.Close();
                }
                qb++;
            }
        }


        protected void tb_user_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tb_user_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.tb_user.PageIndex = e.NewPageIndex;
            dateload();
        }

        //protected void tb_user_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "ice")
        //    {
        //        string payyear = e.CommandArgument.ToString();
        //        bool bos = true;
        //        string str = "select paystatus from YearManage where payid='" + payyear + "'";
        //        SqlCommand cnd = new SqlCommand(str, conn);
        //        conn.Open();
        //        SqlDataReader dr = cnd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            string state = dr["paystatus"].ToString();
        //            if (state == "启用")
        //            {
        //                bos = true;
        //            }
        //            else
        //            {
        //                bos = false;
        //            }
        //        }
        //        conn.Close();
        //        if (bos == true)
        //        {
        //            string sql = "update YearManage set paystatus='禁用' where payyear='" + payyear + "'";
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            conn.Open();
        //            cmd.ExecuteReader();
        //            conn.Close();
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('已禁用该缴费！')</script>");
        //        }
        //        if (bos == false)
        //        {
        //            string sql = "update YearManage set paystatus='启用' where payyear='" + payyear + "'";
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            conn.Open();
        //            cmd.ExecuteReader();
        //            conn.Close();
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('已启用此缴费！')</script>");
        //        }
        //        dateload();
        //    }
        //}

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from YearManage where paystatus='启用'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            object obj = cmd1.ExecuteScalar();
            conn.Close();
            if (obj == null)
            {
                int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                if (txt_year.Text != null && Convert.ToInt32(txt_year.Text) <= year)
                {
                    Regex r = new Regex("^[0-9]+.{0,1}[0-9]{0,2}$");
                    if (!r.IsMatch(txt_money.Text))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('这不是一个正确的缴费金额！')</script>");
                    }
                    else
                    {
                        string sql = "select * from YearManage where payyear='" + txt_year.Text + "'";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        if (cmd.ExecuteScalar() != null)
                        {
                            conn.Close();
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('已经存在" + txt_year.Text + "的缴费！')</script>");
                        }
                        else
                        {
                            conn.Close();
                            if (txt_art.InnerText != "")
                            {
                                art = txt_art.InnerText;
                            }
                            sql = "insert into YearManage(payid,paytext,paymoney,payyear,paystatus) values('" + DateTime.Now.ToString("yyyyMMddhhmmss") + "','" + art + "','" + txt_money.Text + "','" + txt_year.Text + "','启用')";
                            SqlCommand cmd2 = new SqlCommand(sql, conn);
                            conn.Open();
                            cmd2.ExecuteReader();
                            conn.Close();
                            insert();
                            email();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('年份填写错误！')</script>");
                }
            }
            else
            {
                txt_art.InnerText = "";
                txt_money.Text = "";
                txt_year.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('操作无法完成！原因是有正在启用的缴费，请关闭其他的缴费后重试！');windows.location.href('Payyear.aspx');</script>");
            }


        }
        public void email()
        {
            string sql = "select count(*) from membership where result='已通过' and state='启用'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar()), qb = 1;
            string[] email = new string[count];
            conn.Close(); 
            for (int i = 0; i < count; i++)
            {
                sql = "select top 1 * from (select top " + qb + " * from membership where result='已通过' and state='启用' order by id) as a order by id desc ";
                SqlCommand cmd2 = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    email[i] = dr["email"].ToString();
                }
                conn.Close();
                string content = art;
                MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                MailAddress to = new MailAddress(email[i]);//收件人地址对象
                MailMessage oMail = new MailMessage(from, to);
                oMail.Subject = "江苏省职业教育学会" + txt_year.Text + "年会费缴费通知";//设置邮件标题
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
            }
            Response.Write("<script>alert('添加成功');window.location.href='payyear.aspx'</script>");
        }

        protected void lkbFrozen_Command(object sender, CommandEventArgs e)
        {
            string payyear = e.CommandArgument.ToString();
            string strUpdate = "update [dbo].[YearManage] set paystatus='禁用' where payyear=" + "'" + payyear + "'";
            conn.Open();
            SqlCommand com1 = new SqlCommand(strUpdate, conn);
            com1.ExecuteNonQuery();
            conn.Close();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('缴费年份禁用成功！')</script>");
            dateload();
        }

        protected void lkbOpen_Command(object sender, CommandEventArgs e)
        {
            string sql = "select * from [dbo].[YearManage] where paystatus='启用'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            object obj = cmd.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请关闭其他的缴费年份！')</script>");
            }
            else
            {
                string payyear = e.CommandArgument.ToString();
                string strUpdate = "update [dbo].[YearManage] set paystatus='启用' where payyear=" + "'" + payyear + "'";
                conn.Open();
                SqlCommand com1 = new SqlCommand(strUpdate, conn);
                com1.ExecuteNonQuery();
                conn.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('缴费年份启用成功！')</script>");
                dateload();
                //判断加入不加入vouchermananage
                string sql1 = "select count(*) from membership where result='已通过'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                conn.Open();
                int count = Convert.ToInt32(cmd1.ExecuteScalar()), qb = 1;
                string[] id = new string[count];
                conn.Close();
                for (int i = 0; i < count; i++)
                {
                    sql = "select top 1 * from (select top " + qb + " * from membership where result='已通过' order by id) as a order by id desc ";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        id[i] = dr["id"].ToString();
                    }
                    conn.Close();
                    sql = "select payid from YearManage where payyear='" + payyear + "'";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);
                    conn.Open();
                    string yearid = Convert.ToString(cmd3.ExecuteScalar());
                    conn.Close();
                    string sqlselect = "select * from voucherManage where id=" + id[i] + " and payid='" + yearid + "'";
                    conn.Open();
                    SqlCommand cmd5 = new SqlCommand(sqlselect, conn);
                    if (cmd5.ExecuteScalar() == null)
                    {
                        conn.Close();
                        sql = "insert into voucherManage(voucherid,payid,id,voucherimg,voucherstatus,details) values('" + DateTime.Now.ToString("yyyyMMddhhmmss") + "" + i + "','" + yearid + "','" + id[i] + "','~/img/1.jpg','待缴费','无')";
                        SqlCommand cmd4 = new SqlCommand(sql, conn);
                        conn.Open();
                        cmd4.ExecuteReader();
                        conn.Close();

                        //??
                        sql = "select count(*) from membership where result='已通过'";
                        SqlCommand cnd = new SqlCommand(sql, conn);
                        conn.Open();
                        count = Convert.ToInt32(cnd.ExecuteScalar());
                        qb = 1;
                        string[] email = new string[count];
                        conn.Close();
                        for (int j = 0; j < count; j++)
                        {
                            sql = "select top 1 * from (select top " + qb + " * from membership where result='已通过' order by id) as a order by id desc ";
                            SqlCommand cnd1 = new SqlCommand(sql, conn);
                            conn.Open();
                            SqlDataReader drd = cnd1.ExecuteReader();
                            while (drd.Read())
                            {
                                email[j] = drd["email"].ToString();
                            }
                            conn.Close();
                            string content = art;
                            MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                            MailAddress to = new MailAddress(email[i]);//收件人地址对象
                            MailMessage oMail = new MailMessage(from, to);
                            oMail.Subject = "江苏省职业教育学会" + payyear + "年会费缴费通知";//设置邮件标题
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
                        }
                        //!!

                    }
                    else
                    {
                        conn.Close();
                    }
                    qb++;
                }
                
            }
        }
    }
}