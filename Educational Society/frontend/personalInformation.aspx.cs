using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class personalInformation : System.Web.UI.Page
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
                    aloudproinve();
                    loading();

                }

            }
        }

        public void aloudproinve()
        {
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/PatentProvince.xml");
            xds.XPath = "//province";
            dpl1.DataSource = xds;
            dpl1.DataTextField = "name";
            dpl1.DataValueField = "name";
            dpl1.DataBind();

            dpl1.Items.Insert(0, new ListItem("请选择"));
            dpl1.SelectedIndex = 0;
            dpl2.Items.Insert(0, new ListItem("请选择"));
            dpl2.SelectedIndex = 0;

            if (dpl2.SelectedIndex != 0)
            {
                xds.XPath = "//province [@name='" + dpl1.SelectedValue + "'] /city";
                dpl1.DataSource = xds;
                dpl1.DataTextField = "cname";
                dpl1.DataValueField = "cname";
                dpl1.DataBind();
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
                dpl1.SelectedValue = arr[0];

                loadcity();

                dpl2.SelectedValue = arr[1];


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
        public void loadcity()
        {
            XmlDataSource xds = new XmlDataSource();
            xds.DataFile = Server.MapPath("~/PatentProvince.xml");
            xds.XPath = "//province [@name='" + dpl1.SelectedValue + "'] /city";
            dpl2.DataSource = xds;
            dpl2.DataTextField = "cname";
            dpl2.DataValueField = "cname";
            dpl2.DataBind();
        }




        protected void dpl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpl1.SelectedIndex != 0)
            {
                XmlDataSource xds = new XmlDataSource();
                xds.DataFile = Server.MapPath("~/PatentProvince.xml");
                xds.XPath = "//province [@name='" + dpl1.SelectedValue + "'] /city";
                dpl2.DataSource = xds;
                dpl2.DataTextField = "cname";
                dpl2.DataValueField = "cname";
                dpl2.DataBind();
            }
            else
            {
                dpl2.Items.Clear();
                dpl2.Items.Insert(0, new ListItem("请选择"));
                dpl2.SelectedIndex = 0;
            }
        }




        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string company = txtCompany.Text;
            string legalperson = txtlegalperson.Text;

            string province = dpl1.SelectedValue;
            string city = dpl2.SelectedValue;

            string location = province + "," + city;
            string address = txtLocationAddress.Text;
            string img1 = pic.Src;
            string img2 = pic2.Src;
            string img3 = pic3.Src;
            string img4 = pic4.Src;

            string ContantPeopleName = txtContantPeopleName.Text;
            string ContantPeopleTel = txtContantPeopleTel.Text;
            string ContantPeopleEmail = txtContantPeopleEmail.Text;

            string sql = "update membership set tname='" + ContantPeopleName + "',unitname='" + company + "',location='" + location + "',address='"
                + address + "',tel='" + ContantPeopleTel + "',email='" + ContantPeopleEmail + "',Unitmanager='" + legalperson + "' where ID='" + Session["ID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();

            string sql1 = "update annex set license='" + img1 + "',frontcard='" + img2 + "',backcard='" +
                img3 + "',handcard='" + img4 + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            cmd1.ExecuteScalar();
            conn.Close();

            Response.Write("<script>alert('信息更新成功！')</script>");
        }



        protected void lbUploadPhoto2_Click(object sender, EventArgs e)
        {
            bool fileIsVaild = false;
            if (this.FileUpload2.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload2.FileName).ToLower();
                String[] restrictExtension = { ".jpg", ".gif", ".png", ".bmp" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsVaild = true;
                    }
                    if (fileIsVaild == true)
                    {
                        this.FileUpload2.SaveAs(Server.MapPath("~/img/") + FileUpload2.FileName);
                        string ad = "~/img/" + FileUpload2.FileName;
                        string ac = "../img/" + FileUpload2.FileName;

                        pic2.Src = ac;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请上传正确格式的文件！')</script>");
                        return;
                    }
                }
            }
        }

        protected void lbUploadPhoto3_Click(object sender, EventArgs e)
        {
            bool fileIsVaild = false;
            if (this.FileUpload3.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload3.FileName).ToLower();
                String[] restrictExtension = { ".jpg", ".gif", ".png", ".bmp" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsVaild = true;
                    }
                    if (fileIsVaild == true)
                    {
                        this.FileUpload3.SaveAs(Server.MapPath("~/img/") + FileUpload3.FileName);
                        string ad = "~/img/" + FileUpload3.FileName;
                        string ac = "../img/" + FileUpload3.FileName;

                        pic3.Src = ac;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请上传正确格式的文件！')</script>");
                        return;
                    }
                }
            }
        }

        protected void lbUploadPhoto4_Click(object sender, EventArgs e)
        {
            bool fileIsVaild = false;
            if (this.FileUpload4.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload4.FileName).ToLower();
                String[] restrictExtension = { ".jpg", ".gif", ".png", ".bmp" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsVaild = true;
                    }
                    if (fileIsVaild == true)
                    {
                        this.FileUpload4.SaveAs(Server.MapPath("~/img/") + FileUpload4.FileName);
                        string ad = "~/img/" + FileUpload4.FileName;
                        string ac = "../img/" + FileUpload4.FileName;

                        pic4.Src = ac;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请上传正确格式的文件！')</script>");
                        return;
                    }
                }
            }
        }

        protected void lbUploadPhoto1_Click(object sender, EventArgs e)
        {
            bool fileIsVaild = false;
            if (this.FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
                String[] restrictExtension = { ".jpg", ".gif", ".png", ".bmp" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        fileIsVaild = true;
                    }
                    if (fileIsVaild == true)
                    {
                        this.FileUpload1.SaveAs(Server.MapPath("~/img/") + FileUpload1.FileName);
                        string ad = "~/img/" + FileUpload1.FileName;
                        string ac = "../img/" + FileUpload1.FileName;

                        pic.Src = ac;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请上传正确格式的文件！')</script>");
                        return;
                    }
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("personalInformationLook.aspx");
        }


    }
}