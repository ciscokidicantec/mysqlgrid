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
using System.Json;
using System.Web.Script.Serialization;





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

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Start with Zoopla.co.uk get all the photos by using the post code. So opem the post code table and read them 1 at a time until they are all in the post code array class.
            //Then we will iterate through the post codes one at a time to get the photos. So lets start by creating a Class List and saving the post code in there.

            List<Postcode> postcodelist = new List<Postcode>();
            Postcode postcodeinstance = new Postcode();


            try
            {
                string myconnpostcodeStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
                MySqlConnection connpostcode = new MySqlConnection(myconnpostcodeStr);

                string commandstring = "SELECT * FROM postcodes";

                MySqlCommand mypostcodecmd = new MySqlCommand(commandstring, connpostcode);
                mypostcodecmd.CommandType = System.Data.CommandType.Text;

                connpostcode.Open();
              //  string areapostcode;
                MySqlDataReader rdrpostcode = mypostcodecmd.ExecuteReader();
                while (rdrpostcode.Read())
                {
                  postcodelist.Add(new Postcode { postcodeindex = (int)rdrpostcode["indexpostcode"], postcode = (string)rdrpostcode["postcode"], nameofplace = (string)rdrpostcode["codeareadescription"] });
                }

                connpostcode.Close();
                connpostcode.Dispose();
            }catch (Exception postcodeex)
            {
                Response.Write("Error Message = " + postcodeex.Message);

            }
            //spinsertwithblobwithinjson this is the stored procedure for multiple image inserts using json
            //jsonlongblob class defines the List structure getting ready to serialise the json structure.

            String[] arrayurlimage = new String[4];

            arrayurlimage[0] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
            arrayurlimage[1] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            arrayurlimage[2] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            arrayurlimage[3] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";

            string fileName = "";
            WebClient client;
            WebClient jsonclient;
            Stream streamdata;
            Bitmap bitmap;

            int fileindex = 0;

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;

            //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            int myrecordseffected = 0;
            MySqlCommand cmd = new MySqlCommand();

            string rtn = "spinsertwithblobwithinjson";

            //Connecting to MySQL.
            cmd = new MySqlCommand(rtn, myConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            fileindex = 23456;
            Guid myguid;
            Guid myguidindex;

            List<jsonlongblobarray> jsonblobarray = new List<jsonlongblobarray>();

            //Get the first post code from the list, and cycle round getting the images.

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
                client.Dispose();
            }
                jsonlongblob creatjson = new jsonlongblob();
                jsonlongblobarray creatjsonarrayimage = new jsonlongblobarray();

                jsonclient = new WebClient();
                byte[] imagebytes;

                for (int i = 0; i < arrayurlimage.Length; i++)
                {
                    imagebytes = jsonclient.DownloadData(arrayurlimage[i]);
                    int filesizeKbytes = imagebytes.Length;
                    myguid = Guid.NewGuid();
                    myguidindex = Guid.NewGuid();
                    //Add each image with index, guid etc to the list class, To start with we will have 4 image items - later it will be a page load for a
                    //particular post code. Then we will call the sp again for the next page until all that post code is completed. Then we go onto next post code.

                    //    jsonblob.Add(new jsonlongblob { myindex = i.ToString(), imagelongblob = imagebytes.ToString(), myguid = myguid.ToString() });
                    jsonblobarray.Add(new jsonlongblobarray { Myindex = myguidindex, Imagelongblob = imagebytes, Myguid = myguid});
                }

                //               Response.Write("<br/> jsonblob Count = " + jsonblob.Count + "<br />");


                /*
                                foreach (var mycreatjson in jsonblobarray)
                                {
                                    Response.Write("<br />" + mycreatjson.Myindex + "<br />");

                                    for (int i = 0; i < mycreatjson.Imagelongblob.Length; i++)
                                    {
                                    Response.Write(mycreatjson.Imagelongblob[i]);
                                    }
                */
                /*                   Response.Write(mycreatjson.imagelongblob + "<br />");
                                    Response.Write(mycreatjson.Myguid + "<br /><br />");
                                }

                */

                //Having now got pictures, index, guid etc we now need to make this list of itel into a json structure by serialising the list as below.
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                JavaScriptSerializer javaScriptSerializerarrayimage = new JavaScriptSerializer();

//              string jsonString;
                string jsonStringarray;

                //               javaScriptSerializer = new JavaScriptSerializer();
                //               jsonString = javaScriptSerializer.Serialize(jsonblob);

                javaScriptSerializerarrayimage = new JavaScriptSerializer();
                javaScriptSerializerarrayimage.MaxJsonLength = Int32.MaxValue;

                jsonStringarray = javaScriptSerializerarrayimage.Serialize(jsonblobarray);
                Guid  indexguid;


                indexguid = Guid.NewGuid();
                cmd.Parameters.Add("@myjson", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                cmd.Parameters.Add("@imageindex", MySqlDbType.VarChar, 36);



                foreach (jsonlongblobarray mycreatjsonarrayimage in jsonblobarray)
                {
                    myConn.Open();
                    myguid = Guid.NewGuid();
                    cmd.Parameters["@myguid"].Value = myguid;
                    cmd.Parameters["@myjson"].Value = mycreatjsonarrayimage.Imagelongblob;
                    indexguid = Guid.NewGuid();
                    cmd.Parameters["@imageindex"].Value = indexguid;
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    myrecordseffected = rdr.RecordsAffected;
                    myConn.Close();
                }


                //To check the serialisation we will deserialize the newly created json structure back to a new different list in our class jsonlongblob 
                //So lets create this new emty list to check and see the json as a list structure again by deserilaizeing as below.

                /* keep this,however there isa problem with the size of the data.
                                List<jsonlongblob> myImages = new List<jsonlongblob>();
                                JavaScriptSerializer myjavaScriptSerializer = new JavaScriptSerializer();
                                myImages = (List<jsonlongblob>)myjavaScriptSerializer.Deserialize(jsonString, typeof(List<jsonlongblob>));

                                List<jsonlongblobarray> MyImagesarray = new List<jsonlongblobarray>();
                                JavaScriptSerializer myjavaScriptSerializerarray = new JavaScriptSerializer();
                                MyImagesarray = (List<jsonlongblobarray>)myjavaScriptSerializerarray.Deserialize(jsonStringarray, typeof(List<jsonlongblobarray>));


                                //Its worth noting that although we can create an array of json structures MYSQL currently does not accept arrays. And in any case
                                //I am not sure if there is the capacity of passing that many images across in one go to MYSQL and then the Stored Procedure will have to
                                //then do the database INSERT, if all that effort would be worth while.

                                //Now we have a set of list structures. We can print each item of the structure out. Either using a foreach or array structure
                                foreach (var mydeserializeImages in MyImagesarray)
                                {
                                    Response.Write("<br/>Primary Key Index = " + mydeserializeImages.Myindex);
                                    Response.Write("<br />File BLOB = " + mydeserializeImages.Imagelongblob);
                                    Response.Write("<br />Image Guid = " + mydeserializeImages.Myguid + "<br/>");
                                }

                                // < asp:Image ID = "Image1" runat = "server" ImageUrl = '<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("imagelongblob"))%>' />
                */
                cmd.Dispose();
                //                myConn.Close();
                myConn.Dispose();
                jsonclient.Dispose();


                //            GridView1.DataSource = MyImagesarray;
                //            GridView1.DataBind();
            
        }
    }
}
