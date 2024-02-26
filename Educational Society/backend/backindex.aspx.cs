using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.backend
{
    public partial class backindex : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    dateload();
                    unit();
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
                    Response.Write("<script>alert('非法操作');window.location.href='/frontend/login.aspx'</script>");
                }
            }
        }


        public void dateload(string searchstr = "")
        {
            string sql = "select Row_Number()over(order by id) as xuhao,id,unitname,location,unitType,unitmanager,address,result,level from membership where level='1' and result!='已通过' order by addtime";
            if (searchstr.Trim() != "where")
            {
                sql = "select Row_Number()over(order by id) as xuhao,id,unitname,location,unitType,unitmanager,address,result,level from membership where level='1' and result!='已通过' " + searchstr + " order by addtime";
            }
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            tb_user.DataSource = ds;
            tb_user.DataBind();
            conn.Close();
        }

        public void unit()
        {
            DropDownList4.Items.Insert(0, "全部");
            DropDownList4.Items.Insert(1, "行业协会");
            DropDownList4.Items.Insert(2, "社会团体");
            DropDownList4.Items.Insert(3, "科研机构");
            DropDownList4.Items.Insert(4, "事业单位");
            DropDownList4.Items.Insert(5, "院校");
            DropDownList4.Items.Insert(6, "企业");
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
                strsql.AppendFormat(" result='{0}'", DropDownList3.Text);
            }

            if (DropDownList4.Text != "全部")
            {
                if (!string.IsNullOrEmpty(strsql.ToString()))
                {
                    strsql.AppendFormat(" and ");
                }
                strsql.AppendFormat(" unitType='{0}'", DropDownList4.SelectedValue);
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

        protected void tb_user_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.tb_user.PageIndex = e.NewPageIndex;
            dateload();
        }

        protected void tb_user_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "more")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("userpass.aspx?id=" + id);
            }
        }
    }
}