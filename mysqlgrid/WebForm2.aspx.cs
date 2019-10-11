using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mysqlgrid
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = Request.QueryString["ImageURL"];
        }

        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm2.aspx?ImageURL=" + ((ImageButton)sender).ImageUrl);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("picturegallery.aspx");
        }
    }
}