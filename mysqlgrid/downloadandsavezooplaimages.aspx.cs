using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mysqlgrid;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Drawing;
using MySql.Data.MySqlClient;




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

            string[] estateagentwebsite = new string[5];
            estateagentwebsite[0] = "Https://www.zoopla.co.uk";
            estateagentwebsite[1] = "Https://www.purplebricks.co.uk";



            String[] arrayurlimage = new String[4];

            arrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            arrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
        //  arrayurlimage[4] = "https://www.rightmove.co.uk/property-for-sale/fullscreen/image-gallery.html?propertyId=64668300&photoIndex=4#";
        //  pn=8 is the page number /ab/ is the post code radius=0 search source=home
        //  https://www.zoopla.co.uk/for-sale/property/ab/?q=ab&search_source=home&radius=0&pn=8


            string fileName = "";
            WebClient client;
            Stream stream;
            Bitmap bitmap;

            int fileindex = 0;
            Guid fileguid;
            string current_post_code;

            //Cycle around post codes for each estate agents web site
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
                MySqlConnection conn = new MySqlConnection(connStr);

                MySqlConnection myConn = new MySqlConnection(connStr);
                myConn.ConnectionString = connStr;
                MySqlCommand SelectCommand = new MySqlCommand();
                string mySQL = "SELECT * FROM estateporrtal.postcodes";
                SelectCommand.CommandText = mySQL;
                //                SelectCommand.Parameters.AddWithValue("@myname", myname);
                SelectCommand.Connection = myConn;
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    current_post_code = (string)(myReader["postcode"]);
                    //start scraping the web site for the images for that post code



                }

            }
            catch (Exception ex)
            {
                Response.Write("Error Message = " + ex.Message);
            }

//            while (reader.read())
//            {
//                var image = (byte[])reader.getColumn(0);
//                File.WriteAllBytes(@"c:\image.extension", image);
//            }

            foreach (string imageUrl in arrayurlimage)
            {
                fileindex += 1;
                fileguid = Guid.NewGuid();
                fileName = "C:\\Compress\\" + fileguid.ToString() + ".jpg";
                client = new WebClient();
                stream = client.OpenRead(imageUrl);
                bitmap = new Bitmap(stream);

                if (bitmap != null)
                {
                    bitmap.Save(fileName);
                    bitmap.Dispose();
                }
            }



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
                string strfile = "Some info";
                while (myReader.Read())
                {
                    byte[] imgg = (byte[])(myReader["image"]);
                    if (imgg == null)
                        Image1.ImageUrl = null;
                    else
                    {
                        ImageButton imageButton = new ImageButton();
                        FileInfo fi = new FileInfo(strfile);
                     //   imageButton.AlternateText = "mario";
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