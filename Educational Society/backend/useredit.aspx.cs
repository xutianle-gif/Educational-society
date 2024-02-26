using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class useredit : System.Web.UI.Page
    {

        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        bool state = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] == null)
                {
                    Response.Write("<script>alert('干嘛呢干嘛呢！');window.location.href='backindex.aspx'</script>");
                }
                else
                {
                    dateload();
                }

            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (btn_ok.Text=="冻结")
            {
                string sql = "update menbership set state='冻结' where id='" + Request["id"] + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                Response.Write("<script>alert('冻结成功！');window.location.href='oldusers.aspx'</script>");
            }
            else
            {
                string sql = "update menbership set state='启用' where id='" + Request["id"] + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                Response.Write("<script>alert('启用成功！');window.location.href='oldusers.aspx'</script>");
            }

        }
        

        public void dateload()
        {
            string sql = "select annex.id,name,unitname,unitType,unitmanager,location,address,license,tel,state,email,frontcard,backcard,handcard,tname from membership,annex where membership.id=annex.id and annex.id=" + Request["id"] + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lb_tname.Text = dr["tname"].ToString();
                lb_unit.Text = dr["unitType"].ToString();
                lb_tel.Text = dr["tel"].ToString();
                lb_name.Text = dr["unitType"].ToString();
                lb_fname.Text = dr["unitmanager"].ToString();
                lb_email.Text = dr["email"].ToString();
                lb_address2.Text = dr["address"].ToString();
                lb_address.Text = dr["location"].ToString();
                img1.ImageUrl = dr["license"].ToString();
                img2.ImageUrl = dr["frontcard"].ToString();
                img3.ImageUrl = dr["backcard"].ToString();
                img4.ImageUrl = dr["handcard"].ToString();
                string cv = dr["state"].ToString();
                if (cv == "冻结")
                {
                    state = false;
                }
            }
            conn.Close();
            if (state == false)
            {
                btn_ok.Text = "启用";
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("oldusers.aspx");
        }
    }
}