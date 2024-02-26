using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class passwordChanged : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Write("<script>alert('请先登录');window.location.href='Login.aspx'</script>");
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string pass = txtfirst.Text;
            pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5").ToLower();
            string sql1 = "select password from membership where ID='" + Session["ID"].ToString() + "' and password='" +pass + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            conn.Open();

            if (cmd.ExecuteScalar() == null)
            {
                Response.Write("<script language='javascript'>alert('旧密码不正确')</script>");
                conn.Close();
            }
            else
            {

                conn.Close();
                string newpass = txtNewpassword.Text;
                newpass = FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5").ToLower();
                string sql2 = "update membership set password='" + newpass + "' where ID=" + Session["ID"].ToString();
                conn.Open();
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteReader();
                Response.Write("<script>alert('修改成功！请重新登录！');window.location.href='Login.aspx'</script>");
                Session["user"] = null;
                conn.Close();

            }
        }
    }
}