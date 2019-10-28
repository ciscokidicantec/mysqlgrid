using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Configuration;
//using System.Drawing.Imaging;
//using System.Web.UI.WebControls;
//using Image = System.Web.UI.WebControls.Image;
//using System.Drawing.Drawing2;
//using System.Drawing.Image;

using System.Drawing.Drawing2D;



namespace mysqlgrid
{
    public partial class downloadimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String[] arrayurlimage = new String[4];

            arrayurlimage[0] =  "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            arrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
         //   arrayurlimage[4] = "https://www.rightmove.co.uk/property-for-sale/fullscreen/image-gallery.html?propertyId=64668300&photoIndex=4#";

            string fileName = "";
            WebClient client;
            Stream streamdata;
            Bitmap bitmap;

            System.IO.Stream fsObj;
            BinaryReader binRdr;


            int fileindex = 0;

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;


            string a = "myname";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            //            cmd.CommandText = "INSERT INTO room(person,address) VALUES(?,?)";
            //cmd.Prepare();

            //            cmd.Parameters.Add("person", MySqlDbType.VarChar).Value = a;
            //            cmd.Parameters.Add("address", MySqlDbType.VarChar).Value = "myaddress";
            //            cmd.ExecuteNonQuery(); // HERE I GOT AN EXCEPTION IN THIS LINE

            Guid myguid;
            myConn.Open();
            fileindex = 10064;

            foreach (string imageUrl in arrayurlimage)
            {
                fileindex += 1;
                fileName = "C:\\Compress\\" + "downloaded " + fileindex.ToString() + ".jpg";
                client = new WebClient();
                streamdata = client.OpenRead(imageUrl);
                bitmap = new Bitmap(streamdata);

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                byte[] imagebytes = client.DownloadData(imageUrl);
                byte[] imagecontent = new byte[imagebytes.Length];

                var memoryStream = new MemoryStream(imagebytes);
                bitmap = new Bitmap(memoryStream);

                myguid = Guid.NewGuid();

                try
                {

                    cmd.Connection = myConn;

                    string CmdString = "INSERT INTO estateporrtal.images(imageindex, image, myguid) VALUES(@imageindex, @image, @myguid)";
                    cmd = new MySqlCommand(CmdString, myConn);
                    cmd.Parameters.Add("@imageindex", MySqlDbType.Int32);
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                    cmd.Parameters["@imageindex"].Value = fileindex;
                    cmd.Parameters["@image"].Value = imagebytes;
                    cmd.Parameters["@myguid"].Value = myguid;
                //    con.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    //cmd.Dispose();
                }
                catch(Exception ex)
                {
                    Response.Write("Error Message = " + ex.Message);

                }
                if (bitmap != null)
                {
                    bitmap.Save(fileName);
                    bitmap.Dispose();
                }
            }
        }
    } 
}