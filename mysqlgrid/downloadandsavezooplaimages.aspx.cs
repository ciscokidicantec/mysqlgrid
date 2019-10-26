using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;
using System.Data;
using System.IO;


namespace mysqlgrid
{
    public partial class downloadandsavezooplaimages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Download Picures From Zoopla Website By Post Code.
            //Create A Connection using Web Config

            //  connectionString

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //            String myname = Request.QueryString["Name"];
            //            string myConnection = "server=127.0.0.1;uid=root;" + "pwd=81210ZLK;database=database;" + "Allow User Variables=True";

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
                MySqlConnection conn = new MySqlConnection(connStr);

                MySqlConnection myConn = new MySqlConnection(connStr);
                myConn.ConnectionString = connStr;
                MySqlCommand SelectCommand = new MySqlCommand();
                //string mySQL = "SELECT iddb1,fullname,age,gender,healthrecord,headpicture FROM database.db1 where fullname = @myname  ";
                string mySQL = "SELECT * FROM estateporrtal.images";
                SelectCommand.CommandText = mySQL;
                //                SelectCommand.Parameters.AddWithValue("@myname", myname);
                SelectCommand.Connection = myConn;
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
 //               string strfile = "Some info";
                while (myReader.Read())
                {
                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                        Image1.ImageUrl = null;
                    else
                    {
                        ImageButton imageButton = new ImageButton();
 //                       FileInfo fi = new FileInfo(strfile);
                        imageButton.Height = Unit.Pixel(450);
                        imageButton.Style.Add("padding", "5px");
                        //imageButton.Width = Unit.Pixel(100);
                     //   imageButton.Click += new ImageClickEventHandler(ImageButton_Click);
                        //  MemoryStream mstream = new MemoryStream(imgg);
                        Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imgg);
                        imageButton.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imgg);
                        Panel1.Controls.Add(imageButton);
                    }
                }
                myConn.Close();
                myConn.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("Error Message = " + ex.Message);
            }

        }
    }
}