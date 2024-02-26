using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Educational_Society.frontend
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void hd3_Click(object sender, EventArgs e)
        {
            string ID = DateTime.Now.ToString("yyyymmddhhmmsssss");
            Session["ID"] = ID;
            Response.Redirect("register1.aspx");
        }
    }
}