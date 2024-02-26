using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class oldusers : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        private string sfrom = "3513911134@qq.com";
        private string sfromer = "江苏省职业技术教育学会";
        private string sSMTPHost = "smtp.qq.com";
        private string sSMTPuser = "3513911134@qq.com";
        private string sSMTPpass = "nbwdxcwjpmuocjfd";
        string art = "尊敬的用户，您的账号由于违规或整改方面的原因已暂停使用，请立即联系客服了解详情！";
        string remove = "尊敬的用户，您的账号已解冻，请在日后规范您的使用！";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                
                loading();
                dateload();
                drop1();
                DropDownList1.Items.Insert(0, new ListItem("全部"));
                DropDownList1.SelectedIndex = 0;
                DropDownList2.Items.Insert(0, new ListItem("全部"));
                DropDownList2.SelectedIndex = 0;
                if (DropDownList2.SelectedIndex != 0)
                {
                    drop2();
                }
                }
                else
                {
                    Response.Redirect("/frontend/Login.aspx");
                }
            }
        }

        public void loading()
        {
            DropDownList4.Items.Insert(0, "全部");
            DropDownList4.Items.Insert(1, "行业协会");
            DropDownList4.Items.Insert(2, "社会团体");
            DropDownList4.Items.Insert(3, "科研机构");
            DropDownList4.Items.Insert(4, "事业单位");
            DropDownList4.Items.Insert(5, "院校");
            DropDownList4.Items.Insert(6, "企业");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                drop2();
            }
            else
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("全部"));
                DropDownList2.SelectedIndex = 0;
            }
        }

        public void drop1()
        {
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/PatentProvince.xml");
            xds.XPath = "//province";
            DropDownList1.DataSource = xds;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "name";
            DropDownList1.DataBind();
        }//省下拉框

        public void drop2()
        {
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/PatentProvince.xml");
            xds.XPath = "//province [@name='" + DropDownList1.SelectedValue + "'] /city";
            DropDownList2.DataSource = xds;
            DropDownList2.DataTextField = "cname";
            DropDownList2.DataValueField = "cname";
            DropDownList2.DataBind();
        }//市下拉框

      

        public void dateload(string searchstr = "")
        {
            string sql = "select Row_Number()over(order by id) as xuhao,id,unitname,location,unitType,unitmanager,address,state,addtime,level from membership where level='1'  and result='已通过' order by addtime ";
            if (searchstr.Trim() != "where")
            {
                sql = "select Row_Number()over(order by id) as xuhao,id,unitname,location,unitType,unitmanager,address,state,addtime,level from membership where level='1' and  result='已通过' " + searchstr + " order by addtime ";
            }
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
            string sql = "select state from membership";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                for (int i = 0; i < tb_user.Rows.Count; i++)
                {
                    Label PaymentStatus = tb_user.Rows[i].FindControl("lblPaymentStatus") as Label;

                    if (PaymentStatus.Text == "冻结")
                    {
                        LinkButton Upload = tb_user.Rows[i].FindControl("LinkButton2") as LinkButton;
                        LinkButton Download = tb_user.Rows[i].FindControl("LinkButton3") as LinkButton;
                        Upload.Visible = false;
                        Download.Visible = true; 
                    }
                    else
                    {

                        LinkButton Upload = tb_user.Rows[i].FindControl("LinkButton2") as LinkButton;
                        LinkButton Download = tb_user.Rows[i].FindControl("LinkButton3") as LinkButton;

                       Upload.Visible = true;
                        Download.Visible = false;
                    }
                }
            }

            conn.Close();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder strsql = new StringBuilder();

            if (TextBox1.Text != "")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" unitname like '%{0}%'", TextBox1.Text);
            }

            if (DropDownList1.Text != "全部")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" location like '%{0}%'", DropDownList1.Text);
            }

            if (DropDownList2.Text != "全部")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" location like '%{0}%'", DropDownList2.Text);
            }

            if (DropDownList3.Text != "全部")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" state='{0}'", DropDownList3.Text);
            }

            if (DropDownList4.Text != "全部")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" membership.unitType='{0}'", DropDownList4.SelectedValue);
            }

            if (date1.Value != "")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" addtime>='{0}'", date1.Value);
            }

            if (date2.Value != "")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" addtime<='{0}'", date2.Value);
            }
            string sql = "";
            if (string.IsNullOrEmpty(strsql.ToString().Trim()))
            {
                sql = strsql.ToString();
            }
            else
            {
                sql = "and " + strsql.ToString();
            }
            dateload(sql);
        }

        protected void tb_user_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

      

        protected void tb_user_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ice")
            {
                string id = e.CommandArgument.ToString();
                string strup = "update membership set state='冻结' where id='" + id + "'";
                SqlCommand cmd = new SqlCommand(strup,conn);
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
                dateload();
                //??
                string sql = "select email from membership where id='"+id+"'";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                conn.Open();
                object obj = cmd1.ExecuteScalar();
                conn.Close();

                string content = remove;
                MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                MailAddress to = new MailAddress(obj.ToString());//收件人地址对象
                MailMessage oMail = new MailMessage(from, to);
                oMail.Subject = "江苏省职业教育学会用户通知";//设置邮件标题
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

                //!!
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('该用户已冻结！')</script>");
            //    string id = e.CommandArgument.ToString();
            //    string str = "select state from membership where id='" + id + "'";
            //    bool bos = true;
            //    SqlCommand cnd = new SqlCommand(str, conn);
            //    conn.Open();
            //    SqlDataReader dr = cnd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        string state = dr["state"].ToString();
            //        if (state == "启用")
            //        {
            //            bos = true;
            //        }
            //        else
            //        {
            //            bos = false;
            //        }
            //    }
            //    conn.Close();
            //    if (bos == true)
            //    {
            //        string sql = "update membership set state='冻结' where id='" + id + "'";
            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        conn.Open();
            //        cmd.ExecuteReader();
            //        conn.Close();
            //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('该用户已冻结！')</script>");
            //        dateload();
            //    }
            //    else
            //    {
            //        string sql = "update membership set state='启用' where id='" + id + "'";
            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        conn.Open();
            //        cmd.ExecuteReader();
            //        conn.Close();
            //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('该用户已解冻！')</script>");
            //        dateload();
            //    }
            }

            if (e.CommandName == "start")
            {
                string id = e.CommandArgument.ToString();
                string strup = "update membership set state='启用' where id='" + id + "'";
                SqlCommand cmd = new SqlCommand(strup, conn);
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
                dateload();
                //??
                string sql = "select email from membership where id='" + id + "'";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                conn.Open();
                object obj = cmd1.ExecuteScalar();
                conn.Close();

                string content = art;
                MailAddress from = new MailAddress(sfrom, sfromer);//发件人地址对象
                MailAddress to = new MailAddress(obj.ToString());//收件人地址对象
                MailMessage oMail = new MailMessage(from, to);
                oMail.Subject = "江苏省职业教育学会用户通知";//设置邮件标题
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

                //!!
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('该用户已启用！')</script>");
            }
            if (e.CommandName == "more")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("useredit.aspx?id=" + id);
            }
        }
    }
}
