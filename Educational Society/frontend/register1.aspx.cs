using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class register1 : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);

        private string sfrom = "3513911134@qq.com";
        private string sfromer = "江苏省职业技术教育学会";
        private string sSMTPHost = "smtp.qq.com";
        private string sSMTPuser = "3513911134@qq.com";
        private string sSMTPpass = "nbwdxcwjpmuocjfd";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    drop1();
                    drop2();
                    unit();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
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

        public void unit()
        {
            DropDownList3.Items.Insert(0, "请选择");
            DropDownList3.Items.Insert(1, "行业协会");
            DropDownList3.Items.Insert(2, "社会团体");
            DropDownList3.Items.Insert(3, "科研机构");
            DropDownList3.Items.Insert(4, "事业单位");
            DropDownList3.Items.Insert(5, "院校");
            DropDownList3.Items.Insert(6, "企业");
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "delete from membership where id='" + Session["ID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql,conn);
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            check1();

        }
        public bool a = true;
        public bool b = true;
        public bool c = true;
        public bool d = true;
        public bool e = true;
        public bool f = true;
        public void check1()
        {
            if (pic_name.Text == "")
            {
                g1.Style.Add("color", "red");
                g1.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g1.Style.Add("border", "1px solid #f1bdbd");
                a = false;

            }
            else
            {
                g1.Style.Add("color", "black");
                g1.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g1.Style.Add("border", " 1px solid #bde2f1");
                a = true;
            }
            if (txt_address.Text == "")
            {
                g2.Style.Add("color", "red");
                g2.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g2.Style.Add("border", "1px solid #f1bdbd");
                b = false;
            }
            else
            {
                g2.Style.Add("color", "black");
                g2.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g2.Style.Add("border", " 1px solid #bde2f1");
                b = true;
            }
            if (txt_mail.Text == "")
            {
                g3.Style.Add("color", "red");
                g3.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g3.Style.Add("border", "1px solid #f1bdbd");
                c = false;
            }
            else
            {
                g3.Style.Add("color", "black");
                g3.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g3.Style.Add("border", " 1px solid #bde2f1");
                c = true;
            }
            if (DropDownList2.SelectedValue == "请选择")
            {
                Div1.Style.Add("color", "red");
                Div1.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                Div1.Style.Add("border", "1px solid #f1bdbd");
                d = false;
            }
            else
            {
                Div1.Style.Add("color", "black");
                Div1.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                Div1.Style.Add("border", " 1px solid #bde2f1");
                d = true;
            }
            if (txt_mail.Text.Length > 6 || txt_mail.Text.Length==0)
            {
                this.g3.InnerHtml = "请输入正确格式的邮箱 *";
                g3.Style.Add("color", "red");
                g3.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g3.Style.Add("border", "1px solid #f1bdbd");
                e = false;
            }
            else
            {
                this.g3.InnerHtml = "请输入单位的邮政编码 *";
                g3.Style.Add("color", "black");
                g3.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g3.Style.Add("border", " 1px solid #bde2f1");
                e = true;
            }
            if (pic.Src == "../img/加.png")
            {
                g4.Style.Add("color", "red");
                g4.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g4.Style.Add("border", "1px solid #f1bdbd");
                f = false;
            }
            else
            {
                f = true;
            }
            if (a == true && b == true && c == true && d == true && e==true && f==true)
            {
                string sql1 = "select * from membership where unitname='" + pic_name.Text + "' and Unitmanager='" + txt_person.Text + "'";//判断不是重复注册的用户
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                conn.Open();
                object obj1 = cmd1.ExecuteScalar();
                if (obj1 == null)
                {
                    conn.Close();
                    string sql2 = "select * from membership where unitname='" + pic_name.Text + "' and Unitmanager='" + txt_person.Text + "' and state='冻结'";//判断不是有账号被冻结的情况
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    conn.Open();
                    object obj2 = cmd2.ExecuteScalar();
                    conn.Close();
                    if (obj2 != null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('您的账号已被冻结！无法注册新的账号！请与管理员联系！')</script>");
                    }
                    else
                    {
                        string city = DropDownList1.SelectedValue + "," + DropDownList2.SelectedValue;
                        string sqlinsert = "insert into membership (id,unitType,[address],mail,jointime,Unitmanager,Addtime,result,level,unitname,location)  values('" + Session["ID"].ToString() + "','" + DropDownList3.SelectedValue + "','" + txt_address.Text + "',"+
                        "'" + txt_mail.Text + "','" + txt_time.Value + "','" + txt_person.Text + "','" + DateTime.Now.ToString("yyyyMMdd") + "','待审核','1','" + pic_name.Text + "','" + city + "')";
                        //string sqlinsert = "insert into membership set id='" + Session["ID"].ToString() + "',unitType='" + DropDownList3.SelectedValue + "'，address='" + txt_address.Text + "'" +
                        //    "mail='" + txt_mail.Text + "',jointime='" + txt_time.Value + "',Unitmanager='" + txt_person.Text + "'";//可以添加数据了
                        SqlCommand cmd = new SqlCommand(sqlinsert, conn);
                        conn.Open();
                        cmd.ExecuteScalar();
                        conn.Close();


                        string insertlicense = "insert into annex (license,Addtime,ID) values('" + pic.Src + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Session["ID"].ToString() + "')"; 
                            //"update annex set license='" + pic.Src + "' where annexID='" + Session["ID"].ToString() + "' and Addtime='"+DateTime.Now.ToString("yyyy-MM-dd")+"'";
                        SqlCommand cmd3 = new SqlCommand(insertlicense, conn);
                        conn.Open();
                        cmd3.ExecuteScalar();
                        conn.Close();

                        Response.Redirect("register2.aspx");
                    }
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('您已注册过一个账号，无法注册新的账号！')</script>");
                }
            }
        }
        public string ac="";
        protected void lbUploadPhoto_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileName == "")
            {
                this.Response.Write("<script language='javascript'>alter('您还没上传图片！');</script>");
                return;
            }
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
                        string  ad = "~/img/" + FileUpload1.FileName;
                        ac="../img/"+FileUpload1.FileName;

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

    }


}


