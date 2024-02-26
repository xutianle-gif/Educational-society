using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class transferCoucherManage : System.Web.UI.Page
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
                    content2.Style.Add("display", "none");
                    loadyear();//加载年份
                    loading();//加载全部数据
                    loaddetails();//判断按钮
                }
            }
        }

        public void loading()
        {
            string sql = "select Row_Number()over(order by YearManage.payid) as xuhao,YearManage.payid,Unitmanager,payyear,paymoney,voucherstatus,details,voucherimg,voucherid" +
                " from voucherManage,YearManage,membership " +
                " where voucherManage.payid=YearManage.payid and membership.id=voucherManage.id and voucherManage.id='" + Session["ID"].ToString() + "'";
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            ltvDetails.DataSource = ds;
            ltvDetails.DataBind();
            conn.Close();
        }

        public void loadyear()
        {
            string sql = "select * from YearManage";
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dplYear.DataSource = ds;
            this.dplYear.DataValueField = "payID";
            this.dplYear.DataTextField = "payyear";
            dplYear.DataBind();
            dplYear.Items.Insert(0, new ListItem("全部"));
        }
        public void loaddetails()
        {
            string sql = "select voucherstatus from voucherManage where id='" + Session["ID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                for (int i = 0; i < ltvDetails.Rows.Count; i++)
                {
                    Label PaymentStatus = ltvDetails.Rows[i].FindControl("lblPaymentStatus") as Label;

                    if (PaymentStatus.Text == "待审核" || PaymentStatus.Text=="已缴费")
                    {
                        LinkButton Upload = ltvDetails.Rows[i].FindControl("lbupload") as LinkButton;
                        LinkButton look = ltvDetails.Rows[i].FindControl("lblook") as LinkButton;
                        LinkButton Download = ltvDetails.Rows[i].FindControl("lbdownload") as LinkButton;
                        LinkButton xian = ltvDetails.Rows[i].FindControl("lbxian") as LinkButton;

                        Upload.Visible = false;
                        look.Visible = true;
                        Download.Visible = true;
                        xian.Visible = true;
                    }
                    else
                    {

                        LinkButton Upload = ltvDetails.Rows[i].FindControl("lbupload") as LinkButton;
                        LinkButton look = ltvDetails.Rows[i].FindControl("lblook") as LinkButton;
                        LinkButton Download = ltvDetails.Rows[i].FindControl("lbdownload") as LinkButton;
                        LinkButton xian = ltvDetails.Rows[i].FindControl("lbxian") as LinkButton;

                        Upload.Visible = true;
                        look.Visible = false;
                        Download.Visible = false;
                        xian.Visible = false;
                    }
                }
            }

            conn.Close();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dplYear.SelectedValue == "全部")
            {
                loaddetails();
            }
            else
            {
                string sql = "select Row_Number()over(order by YearManage.payid) as xuhao,YearManage.payid,Unitmanager,payyear,paymoney,voucherstatus,details,voucherimg,voucherid" +
                " from voucherManage,YearManage,membership " +
                " where voucherManage.payid=YearManage.payid and membership.id=voucherManage.id and voucherManage.id='" + Session["ID"].ToString() + "' and YearManage.payid='" + dplYear.SelectedValue + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
                ltvDetails.DataSource = ds;
                ltvDetails.DataBind();
            }
        }

        //protected void ltvDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    loaddetails();
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (FileUpload1.FileName == "")
            //{
            //    this.Response.Write("<script language='javascript'>alter('请上传文件再操作');</script>");
            //    return;
            //}
            //bool fileIsVaild = false;
            //if (this.FileUpload1.HasFile)
            //{
            //    String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            //    String[] restrictExtension = { ".jpg", ".gif", ".png", ".bmp" };
            //    for (int i = 0; i < restrictExtension.Length; i++)
            //    {
            //        if (fileExtension == restrictExtension[i])
            //        {
            //            fileIsVaild = true;
            //        }
            //        if (fileIsVaild == true)
            //        {
            //            try
            //            {
            //                this.Image1.ImageUrl = "../img/" + FileUpload1.FileName;
            //                this.FileUpload1.SaveAs(Server.MapPath("~/img/") + FileUpload1.FileName);
            //                this.Response.Write("<script language='javascript'>alter('上传成功');</script>");
            //            }
            //            catch
            //            {
            //                this.Response.Write("<script language='javascript'>alter('上传失败')</script>");
            //            }
            //            finally { }
            //        }
            //        else
            //        {
            //            this.Response.Write("<script language='javascript'>alter('请上传正确格式的文件！');</script>");
            //            return;
            //        }
            //    }
            //}
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (pic.Src == "../img/加.png")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('请上传图片！')</script>");
            }
            else
            {
                string sql = "update voucherManage set voucherimg='" + pic.Src.ToString() + "',voucherstatus='待审核',addtime='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where payid='" + lblYear.Text + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('上传成功，请等待审核！')</script>");
                loading();
                loaddetails();
                content2.Style.Add("display", "none");
            }

        }










        protected void Lkbdownload_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                string file = e.CommandArgument.ToString();
                string sql = "select voucherimg from voucherManage where voucherID='" + file + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    string fileName = "voucherimg.jpg";//客户端保存的文件名
                    string ff = obj.ToString();
                    string filePath = Server.MapPath(ff);//路径
                    //以字符流的形式下载文件
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('下载失败！');</script>");
                }
                conn.Close();
            }


        }

        protected void ltvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "qwer")
            {
                content2.Style.Add("display", "block");
                lblYear.Text = e.CommandArgument.ToString();

            }
            if (e.CommandName == "download")
            {
                string file = e.CommandArgument.ToString();
                string sql = "select voucherimg from voucherManage where voucherID='" + file + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    string fileName = "voucherimg.jpg";//客户端保存的文件名
                    string ff = obj.ToString();
                    string filePath = Server.MapPath(ff);//路径
                    //以字符流的形式下载文件
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('下载失败！');</script>");
                }
                conn.Close();
            }
            if (e.CommandName == "btnlookit")
            {
                string imgSrc =e.CommandArgument.ToString();
                bigg.Src=imgSrc;
                masks.Style.Add("display","block");
                bigg.Style.Add("display","block");
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            content2.Style.Add("display", "none");
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
    }
}