using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net;
using System.Drawing;
using System.IO;



namespace mysqlgrid
{
    public class Insertsvgtodatabase
    {

        public bool Insimagetodb(List<MyRegextraction> Gotsvg, bool SavetoFile)
        {
            string fileName = "";
            WebClient client;
            Stream streamdata;
            Bitmap bitmap;

            int fileindex = 0;

            client = new WebClient();

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlConnection myConn = new MySqlConnection(connStr);
            myConn.ConnectionString = connStr;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            Guid myguid;
            myConn.Open();

            fileindex = 10074;

            string mysubstring;

            foreach (var imageUrl in Gotsvg)
            {
                fileindex += 1;

                if (SavetoFile)
                {
                    client = new WebClient();
                    fileName = "C:\\Compress\\" + "downloaded " + fileindex.ToString() + ".jpg";
                    streamdata = client.OpenRead(imageUrl.PropertyDescription);
                    bitmap = new Bitmap(streamdata);
                    bitmap.Save(fileName);
                    bitmap.Dispose();

                }

                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

                mysubstring = imageUrl.PropertyDescription.Substring(0, 5);

                //Check for the group only regex which is groupclass, normally the even parts of the list
                if (mysubstring != "https") continue;


                    byte[] imagebytes = client.DownloadData(imageUrl.PropertyDescription);
                int filesizeKbytes = imagebytes.Length;


                byte[] imagecontent = new byte[imagebytes.Length];

            //    var memoryStream = new MemoryStream(imagebytes);
            //    bitmap = new Bitmap(memoryStream);

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
                    cmd.Parameters.Add("@imageindex", MySqlDbType.VarChar,36);
                    cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@myguid", MySqlDbType.VarChar, 36);
                    cmd.Parameters.Add("@originalfilename", MySqlDbType.VarChar, 200);
                    cmd.Parameters.Add("@imagesizeKbytes", MySqlDbType.Int32);
                    cmd.Parameters.Add("@savedondiskfilename", MySqlDbType.VarChar, 255);
                    cmd.Parameters.Add("@inserteddate", MySqlDbType.DateTime);
                    Guid.NewGuid();
                    cmd.Parameters["@imageindex"].Value = Guid.NewGuid();
                    //cmd.Parameters["@imageindex"].Value = fileindex;
                    cmd.Parameters["@image"].Value = imagebytes;
                    cmd.Parameters["@myguid"].Value = myguid;
                    cmd.Parameters["@originalfilename"].Value = imageUrl.PropertyDescription;
                    cmd.Parameters["@imagesizeKbytes"].Value = filesizeKbytes;
                    cmd.Parameters["@savedondiskfilename"].Value = fileName;
                    cmd.Parameters["@inserteddate"].Value = DateTime.Now;


                    int RowsAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    string errmsg = ex.Message;
                    return false;
                }
                conn.Close();
                conn.Dispose();

                //return true;
            }
            return true;
        }
    }
}
