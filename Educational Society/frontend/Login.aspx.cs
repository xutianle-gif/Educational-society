using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class Login : System.Web.UI.Page
    {
        const string constr = "Data Source=172.16.12.55;Initial Catalog=voucherManage;User ID=sa;Password=123456";
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbFind_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindPassword.aspx");
        }

        protected void lbCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public static string ReplaceSqlKey(string strRequest)
        {

            strRequest = strRequest.ToLower();

            //strRequest = strRequest.Replace(" ", "");

            strRequest = strRequest.Replace("'", "''");

            strRequest = strRequest.Replace("--", "");

            strRequest = strRequest.Replace("select", "");

            strRequest = strRequest.Replace("insert", "");

            strRequest = strRequest.Replace("delete from", "");

            strRequest = strRequest.Replace("count(", "");

            strRequest = strRequest.Replace("drop table", "");

            strRequest = strRequest.Replace("drop", "");

            strRequest = strRequest.Replace("update", "");

            strRequest = strRequest.Replace("delete", "");

            strRequest = strRequest.Replace("truncate", "");

            strRequest = strRequest.Replace("asc(", "");

            strRequest = strRequest.Replace("mid(", "");

            strRequest = strRequest.Replace("char(", "");

            strRequest = strRequest.Replace("xp_cmdshell", "");

            strRequest = strRequest.Replace("exec master", "");

            strRequest = strRequest.Replace("net localgroup administrators", "");

            strRequest = strRequest.Replace("and", "");

            strRequest = strRequest.Replace("net user", "");

            return strRequest.Trim();

        }

        protected void lg_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                lblPleaseInputUser.Visible = true;
                
            }
            else
            {
                lblPleaseInputUser.Visible = false;
            }

            if (txtpassword.Text == "")
            {
                lblPleaseInputPassword.Visible = true;
                return;
            }
            else
            {
                lblPleaseInputPassword.Visible = false;
            }

            string sql = "select * from membership where name='" + txtuser.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            object obj = cmd.ExecuteReader();
            conn.Close();
            if (obj == null)
            {
                Response.Write("<script>alert('用户名不存在');</script>");
            }
            else
            {
                string user = txtuser.Text;
                string pass = txtpassword.Text;

                user=ReplaceSqlKey(user);
                pass=ReplaceSqlKey(pass);

                pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5").ToLower();

                string sqlsearch = "select * from membership where name='" + user + "' and password='" + pass + "' and [level]='1'";
                SqlCommand cmdsearch = new SqlCommand(sqlsearch, conn);

                string sqlSearch = "select * from membership where name='" + user + "' and password='" + pass + "' and [level]='0'";
                SqlCommand cmdSearch = new SqlCommand(sqlSearch, conn);

                conn.Open();


                if (cmdsearch.ExecuteScalar() != null)
                {
                    string state = "";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Session["ID"] = dr["ID"].ToString();
                        state = dr["state"].ToString();
                    }
                    conn.Close();
                    if (state == "冻结")
                    {
                        Response.Write("<script>alert('您的账号已冻结');</script>");
                    }
                    else
                    {
                        sql = "select result from membership where name='" + txtuser.Text + "'";
                        SqlCommand cnd = new SqlCommand(sql, conn);
                        conn.Open();
                        if (Convert.ToString(cnd.ExecuteScalar()) == "已通过")
                        {
                            Response.Redirect("transferCoucherManage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('您的账号暂时没有通过审核，请您过段时间再试试！');</script>");
                        }
                    }
                }
                else if (cmdSearch.ExecuteScalar() != null)
                {


                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Session["ID"] = dr["ID"].ToString();
                    }
                    conn.Close();
                    Response.Redirect("/backend/backindex.aspx");//后台入口

                }
                else
                {
                    Response.Write("<script>alert('密码错误');</script>");
                    conn.Close();
                }


            }
        }
        //public static string GetMD5(string myString)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x");
        //    }

        //    return byte2String;
        //}
    }
}