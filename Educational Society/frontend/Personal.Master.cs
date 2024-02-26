using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class Personal : System.Web.UI.MasterPage
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    string sql = "select unitname from membership where id='" + Session["id"] + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    Label1.Text = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
        }

        protected void btnTVM_Click(object sender, EventArgs e)
        {
            Response.Redirect("transferCoucherManage.aspx");
        }

        protected void btnPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("personalInformationLook.aspx");
        }

        protected void btnCP_Click(object sender, EventArgs e)
        {
            Response.Redirect("passwordChanged.aspx");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["name"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}