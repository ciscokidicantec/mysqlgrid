using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace mysqlgrid
{
    public partial class picturegallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadImages();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + fileName);
            }
            Response.Redirect("~/picturegallery.aspx");
        }

        private void LoadImages()
        {
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Data")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fi = new FileInfo(strfile);
                imageButton.ImageUrl = "~/Data/" + fi.Name;
                imageButton.Height = Unit.Pixel(450);
                imageButton.Style.Add("padding", "5px");
                //imageButton.Width = Unit.Pixel(100);
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                Panel1.Controls.Add(imageButton);
            }
        }

        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("webform2.aspx?ImageURL=" + ((ImageButton)sender).ImageUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (1602, LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/101D0578.JPG'));
            string constr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            int imageindex = 2345;
            //string filedirectory = "LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/101D0578.JPG')";
            //INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (1602, LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/101D0578.JPG'));

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //string query = "INSERT INTO estateporrtal.images(`imageindex`, `image`) VALUES (@imageindex, @filedirectory)";
                string query = "INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (1602, LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/101D0578.JPG'));";


                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                //    cmd.Parameters.AddWithValue("@imageindex", imageindex);
                //    cmd.Parameters.AddWithValue("@filedirectory", filedirectory);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}