using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class register2 : System.Web.UI.Page
    {

        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public bool a = true;
        public bool b = true;
        public bool c = true;
        public bool d = true;
        public bool f = true;
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (txt_tname.Text == "")
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
            if (txt_tel.Text == "")
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
            if (pic.Src == "")
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
            if (pic2.Src == "")
            {
                g3.Style.Add("color", "red");
                g3.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g3.Style.Add("border", "1px solid #f1bdbd");
                d = false;
            }
            else
            {
                g3.Style.Add("color", "black");
                g3.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g3.Style.Add("border", " 1px solid #bde2f1");
                d = true;
            }
            if (pic3.Src == "")
            {
                g4.Style.Add("color", "red");
                g4.Style.Add("background-color", "rgba(255, 215, 215, 0.3)");
                g4.Style.Add("border", "1px solid #f1bdbd");
                f = false;
            }
            else
            {
                g4.Style.Add("color", "black");
                g4.Style.Add("background-color", "rgba(215, 243, 255, 0.3)");
                g4.Style.Add("border", " 1px solid #bde2f1");
                f = true;
            }
            if (a == true && b == true && c == true && d == true && f == true)
            {
                string sql = "update membership set Tname='" + txt_tname.Text + "',tel='" + txt_tel.Text + "' where id='" + Session["ID"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();

                string sql2 = "update annex set frontcard='" + pic.Src + "',backcard='" + pic2.Src + "',handcard='" + pic3.Src + "' where id='" + Session["ID"].ToString() + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                conn.Open();
                cmd2.ExecuteReader();
                conn.Close();

                Response.Redirect("register3.aspx");
            }
        }

        protected void lbUploadPhoto_Click(object sender, EventArgs e)
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

        protected void lbUploadPhoto1_Click(object sender, EventArgs e)
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

        protected void lbUploadPhoto2_Click(object sender, EventArgs e)
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
    }
}