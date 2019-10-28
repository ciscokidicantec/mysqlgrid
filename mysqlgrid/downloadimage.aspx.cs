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

            arrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            arrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
            //   arrayurlimage[4] = "https://www.rightmove.co.uk/property-for-sale/fullscreen/image-gallery.html?propertyId=64668300&photoIndex=4#";

            string fileName = "";
            WebClient client;
            Stream streamdata;
            Bitmap bitmap;

            int fileindex = 0;

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            Guid myguid;
            myConn.Open();

            fileindex = 10074;

            foreach (string imageUrl in arrayurlimage)
            {
                fileindex += 1;
                client = new WebClient();

                if (CheckBox1.Checked)
                {
                    fileName = "C:\\Compress\\" + "downloaded " + fileindex.ToString() + ".jpg";
                    streamdata = client.OpenRead(imageUrl);
                    bitmap = new Bitmap(streamdata);
                    bitmap.Save(fileName);
                    bitmap.Dispose();

                }

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                byte[] imagebytes = client.DownloadData(imageUrl);
                int filesizeKbytes = imagebytes.Length;


                //   byte[] imagecontent = new byte[imagebytes.Length];

                //   var memoryStream = new MemoryStream(imagebytes);
                //   bitmap = new Bitmap(memoryStream);

                myguid = Guid.NewGuid();

                try
                {

                    cmd.Connection = myConn;

                    string CmdString = "INSERT INTO estateporrtal.images(" +
                        "imageindex," +
                        "image," +
                        "myguid," +
                        "originalfilename," +
                        "imagesizeKbytes," +
                        "savedondiskfilename," +
                        "inserteddate) " +
                        "VALUES(" +
                        "@imageindex," +
                        "@image," +
                        "@myguid," +
                        "@originalfilename," +
                        "@imagesizeKbytes," +
                        "@savedondiskfilename," +
                        "@inserteddate)";

                    cmd = new MySqlCommand(CmdString, myConn);
                    cmd.Parameters.Add("@imageindex", MySqlDbType.Int32);
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                    cmd.Parameters.Add("@originalfilename", MySqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@imagesizeKbytes", MySqlDbType.Int32);
                    cmd.Parameters.Add("@savedondiskfilename", MySqlDbType.VarChar, 255);
                    cmd.Parameters.Add("@inserteddate", MySqlDbType.DateTime);

                    cmd.Parameters["@imageindex"].Value = fileindex;
                    cmd.Parameters["@image"].Value = imagebytes;
                    cmd.Parameters["@myguid"].Value = myguid;
                    cmd.Parameters["@originalfilename"].Value = imageUrl;
                    cmd.Parameters["@imagesizeKbytes"].Value = filesizeKbytes;
                    cmd.Parameters["@savedondiskfilename"].Value = fileName;
                    cmd.Parameters["@inserteddate"].Value = DateTime.Now; ;


                    int RowsAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    Response.Write("Error Message = " + ex.Message);
                }
                conn.Close();
                conn.Dispose();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String[] arrayurlimage = new String[4];

            arrayurlimage[0] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
            arrayurlimage[1] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[2] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[3] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            //   arrayurlimage[4] = "https://www.rightmove.co.uk/property-for-sale/fullscreen/image-gallery.html?propertyId=64668300&photoIndex=4#";

            //   MySqlCommand cmd;



            string fileName = "";
            WebClient client;
            Stream streamdata;
            Bitmap bitmap;

            int fileindex = 0;

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            Guid myguid;
            myConn.Open();

            fileindex = 10174;

            foreach (string imageUrl in arrayurlimage)
            {
                fileindex += 1;
                client = new WebClient();

                if (CheckBox1.Checked)
                {
                    fileName = "C:\\Compress\\" + "downloaded " + fileindex.ToString() + ".jpg";
                    streamdata = client.OpenRead(imageUrl);
                    bitmap = new Bitmap(streamdata);
                    bitmap.Save(fileName);
                    bitmap.Dispose();

                }

                byte[] imagebytes = client.DownloadData(imageUrl);
                int filesizeKbytes = imagebytes.Length;
                myguid = Guid.NewGuid();

                try
                {

                    cmd.Connection = myConn;
                    string rtn = "spinsertlblob";

                    int myrecordseffected = 0;
                    //Connecting to MySQL.
                    cmd = new MySqlCommand(rtn, myConn);
 //                   cmd = new MySqlCommand(CmdString, myConn);
 
                    cmd.Parameters.Add("@imageindex", MySqlDbType.Int32);
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
 //                   cmd.Parameters.Add("@originalfilename", MySqlDbType.VarChar, 200);
 //                   cmd.Parameters.Add("@imagesizeKbytes", MySqlDbType.Int32);
 //                   cmd.Parameters.Add("@savedondiskfilename", MySqlDbType.VarChar, 255);
 //                   cmd.Parameters.Add("@inserteddate", MySqlDbType.DateTime);

                    cmd.Parameters["@imageindex"].Value = fileindex;
                    cmd.Parameters["@image"].Value = imagebytes;
                    cmd.Parameters["@myguid"].Value = myguid;
//                    cmd.Parameters["@originalfilename"].Value = imageUrl;
//                    cmd.Parameters["@imagesizeKbytes"].Value = filesizeKbytes;
//                    cmd.Parameters["@savedondiskfilename"].Value = fileName;
//                    cmd.Parameters["@inserteddate"].Value = DateTime.Now; ;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    //  int liststr = 0;
                    //string displayitem = "";

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    myrecordseffected = rdr.RecordsAffected;

                    //                        GridView1.DataSource = rdr;
                    //                        GridView1.DataBind();

                    //return;


 //                   string CmdString = "INSERT INTO estateporrtal.images(" +
 //                   "imageindex," +
 //                   "image," +
 //                   "myguid," +
 //                   "originalfilename," +
 //                   "imagesizeKbytes," +
 //                   "savedondiskfilename," +
 //                   "inserteddate) " +
 //                   "VALUES(" +
 //                   "@imageindex," +
 //                   "@image," +
//                    "@myguid," +
//                    "@originalfilename," +
//                    "@imagesizeKbytes," +
//                    "@savedondiskfilename," +
//                    "@inserteddate)";


 //                   int RowsAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                }
                catch (Exception ex)
                {
                    Response.Write("Error Message = " + ex.Message);
                }
                conn.Close();
                conn.Dispose();

            }

        }
    }


}
