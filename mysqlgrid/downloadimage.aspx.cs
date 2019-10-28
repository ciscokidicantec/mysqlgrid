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
            fileindex = 10010;

            foreach (string imageUrl in arrayurlimage)
            {
                fileindex += 1;
                fileName = "C:\\Compress\\" + "downloaded " + fileindex.ToString() + ".jpg";
                client = new WebClient();
                streamdata = client.OpenRead(imageUrl);
                bitmap = new Bitmap(streamdata);

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                BinaryReader br = new BinaryReader(streamdata);
                byte[] bytes = br.ReadBytes((Int32)streamdata.Length);


                    fsObj = client.OpenRead(imageUrl);
                //                fsObj = File.OpenRead(imageUrl);
                byte[] imgContent = new byte[fsObj.Length];
                binRdr = new BinaryReader(fsObj);
                imgContent = binRdr.ReadBytes((int)fsObj.Length);
            //    mcon = new MySqlConnection("server=localhost;user=root;pwd=root;database=test;");
            //    mcon.Open();

                //inserting into MySQL db
      //          cmd = new MySqlCommand("insert into users  (userid,username,userphoto) values (@userid, @username,  @userphoto)", mcon);
      //          cmd.Parameters.Add(new MySqlParameter("@userid", (object)textBox1.Text));
      //          cmd.Parameters.Add(new MySqlParameter("@username", (object)textBox2.Text));
      //          cmd.Parameters.Add(new MySqlParameter("@userphoto", (object)imgContent));
      //          MessageBox.Show(cmd.ExecuteNonQuery().ToString() + " rows  affected");





                //               var outimagre = System.Drawing.Image.FromStream(stream);

                myguid = Guid.NewGuid();


//                string query = "INSERT INTO estateporrtal.images (`imageindex`,`image`, `myguid`) VALUES (" + fileindex + "," + streamdata + ",'" + myguid + "');";
                string query = "INSERT INTO estateporrtal.images (`imageindex`,`image`, `myguid`) VALUES (" + fileindex + ",'" + imgContent + "','" + myguid + "');";

                try
                {

//                   System.IO.FileStream fs = new FileStream(@"D:\link\to\image.png", FileMode.Open);
//                   System.IO.BufferedStream bf = new BufferedStream(fs);
//                    byte[] buffer = new byte[bf.Length];
//                    bf.Read(buffer, 0, buffer.Length);

//                    byte[] buffer_new = buffer;

//                    MySqlConnection connection = new MySqlConnection(MyConString);
//                    connection.Open();
//                    MySqlCommand command = new MySqlCommand("", connection);
//                    command.CommandText = "insert into table(fldImage) values(@image);";
//                    command.Parameters.AddWithValue("@image", buffer_new);
//                    command.ExecuteNonQuery();
//                    connection.Close();

                    //                    cmd = new MySqlCommand(query, myConn);
                    cmd = new MySqlCommand(query, myConn);
                    //                  cmd.CommandText = "INSERT INTO estateporrtal.images (`imageindex`,`image`, `myguid`) VALUES (" + fileindex + "," + streamdata + ",'" + myguid + "');";


                    //                   System.IO.FileStream fs = new FileStream(@"D:\link\to\image.png", FileMode.Open);
                    //                   System.IO.BufferedStream bf = new BufferedStream(fs);

                    //       System.IO.BufferedStream bf = new BufferedStream(streamdata);
                    //       byte[] buffer = new byte[streamdata.Length];
                    //       streamdata.Read(buffer, 0, buffer.Length);
                    //       byte[] buffer_new = buffer;
                    //                    cmd.Parameters.AddWithValue("@image", streamdata);
                    cmd.Parameters.Add(new MySqlParameter("@image", (object)imgContent));
                    cmd.Parameters.Add("imageindex", MySqlDbType.Int32).Value = fileindex;
                 //   cmd.Parameters.Add("image", MySqlDbType.LongBlob).Value = streamdata;
                 //   cmd.Parameters.Add("image", MySqlDbType.LongBlob).Value = "abc";
                 //   cmd.Parameters.Add("myguid", MySqlDbType.Guid).Value = myguid;
                    cmd.Connection = myConn;

                    //cmd.Dispose();
                    cmd.ExecuteNonQuery();
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