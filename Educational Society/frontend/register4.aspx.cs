using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class register4 : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "delete from membership where id='" + Session["ID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

            string sql2 = "delete from annex where id='" + Session["ID"].ToString() + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            conn.Open();
            cmd2.ExecuteReader();
            conn.Close();
            Session["ID"] = null;
            Response.Redirect("Login.aspx");

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('注册成功，请等待管理员审核，审核成功后会通过邮箱通知您！');location.href='Login.aspx';</script>");
            }
          
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}