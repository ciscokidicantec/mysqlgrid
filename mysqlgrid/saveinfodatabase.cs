using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql;
using MySql.Data.MySqlClient;
using System.Configuration;

using System.Net;
using System.IO;
using System.Drawing;
//using MySql.Data.MySqlClient;



namespace mysqlgrid
{

    public class Savetodatabase
    {

        public int Savephototodatabase(string[] Url, string filename, bool savethefile)
        {

            WebClient client;
            Stream streamdata;
            Bitmap bitmap;

            string Errormessages;

            int numberofrecords = 0;
            string fileName;
            Guid fileindex;

            String[] myarrayurlimage = new String[4];

            myarrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            myarrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
            myarrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
            myarrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";


            string imageUrl = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";
            Url[1] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";

            client = new WebClient();

            if (savethefile)
            {
                fileName = "C:\\Compress\\" + "downloaded" + filename + ".jpg";
                streamdata = client.OpenRead(imageUrl);
                bitmap = new Bitmap(streamdata);
                bitmap.Save(fileName);
                bitmap.Dispose();
            }

            byte[] imagebytes = client.DownloadData(imageUrl);
            int filesizeKbytes = imagebytes.Length;

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            Guid myguid;
            myConn.Open();

            fileindex = Guid.NewGuid();

            try
            {

                foreach (string myimageUrl in myarrayurlimage)
                {

                    myguid = Guid.NewGuid();



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
                    cmd.Parameters["@savedondiskfilename"].Value = myimageUrl;
                    cmd.Parameters["@inserteddate"].Value = DateTime.Now; ;


                    int RowsAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                }
                catch (Exception ex)
            {
                Errormessages = ex.Message;

            }
            conn.Close();
            conn.Dispose();
            client.Dispose();

            return numberofrecords;
        }

    }

}