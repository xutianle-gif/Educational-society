using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class personalInformationLook : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Write("<script>alert('请先登录');window.location.href='Login.aspx'</script>");
                }
                else
                {
                    loading();

                }

            }
        }
       

        public void loading()
        {
            string sql = "select * from membership,annex where membership.id=annex.id and membership.id='" + Session["ID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                txtCompany.Text = dr["unitname"].ToString();
                txtlegalperson.Text = dr["Unitmanager"].ToString();

                string[] arr = new string[2];

                arr = dr["location"].ToString().Split(',');
                dpl1.Text = arr[0];

             

                dpl2.Text = arr[1];


                txtLocationAddress.Text = dr["address"].ToString();
                pic.Src = dr["license"].ToString();

                txtContantPeopleName.Text = dr["tname"].ToString();
                txtlegalperson.Text = dr["Unitmanager"].ToString();
                txtContantPeopleTel.Text = dr["tel"].ToString();
                txtContantPeopleEmail.Text = dr["email"].ToString();

                pic2.Src = dr["frontcard"].ToString();
                pic3.Src = dr["backcard"].ToString();
                pic4.Src = dr["handcard"].ToString();
            }
            conn.Close();
        }
      
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("personalInformation.aspx");
        }

    }
}