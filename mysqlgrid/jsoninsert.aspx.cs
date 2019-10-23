using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.web.extension;
using System.Web.DynamicData;
using System.Runtime.Serialization.Formatters.Binary;

using System.Json;
using System.Net;

using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;



namespace mysqlgrid
{
    public partial class jsoninsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid estate_guid;

            estate_guid = Guid.NewGuid();


//            GameObject[] houses = new GameObject[200];

//            for (int i = 0;`i < house` i < houses.length; i++)
//            { houses[i] = new GameObject(); }


            Images[] images = new Images[200];

            //images.

            for (int i = 0 ; i < images.Length ;  i++)
            {
                images[i] = new Images();
            }

            //Images[] image1 = new Images[5];

            //image1 = new Images[1];


// NEED TO GET DIRECTORY FILES ARRAY AND PLACE INTO THIS STRUCTURE READY FOR SERIALISATION.


            images[0].myindex = "345";
            images[0].imagepath = "h.jpg";
            images[0].myguid = estate_guid.ToString();

            estate_guid = Guid.NewGuid();

            images[1].myindex = "456";
            images[1].imagepath = "helenedited.jpg";
            images[1].myguid = estate_guid.ToString();

            List<Images> listimages = new List<Images>();

            listimages.Add(images[0]);
            listimages.Add(images[1]);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(listimages);

            Response.Write(jsonString);

            return;

            List<Images> myImages = new List<Images>();

            Guid estate_guid1;
            Guid estate_guid2;

            estate_guid1 = Guid.NewGuid();
            estate_guid2 = Guid.NewGuid();

//            string myjsonString = "[{\"myindex\":\"345\",\"imagepath\":\"h.jpg\",\"myguid\":" + \" + estate_guid1.ToString() + "\"},\" + \"{\"myindex\":\"546\",\"imagepath\":\"helenedited.jpg\",\"myguid\":" + estate_guid2.ToString() + "}]";

            string myjsonString = "[{\"myindex\":\"345\",\"imagepath\":\"h.jpg\",\"myguid\": estate_guid1.tostring()}," +
                "{\"myindex\":\"546\",\"imagepath\":\"helenedited.jpg\",\"myguid\":estate_guid2.tostring()}]";

            JavaScriptSerializer myjavaScriptSerializer = new JavaScriptSerializer();
            myImages = (List<Images>)myjavaScriptSerializer.Deserialize(myjsonString, typeof(List<Images>));

            foreach (Images myimage in myImages)
            {
                Response.Write("<br /><br/><br/>Primary Key Index = " + myimage.myindex);
                Response.Write("<br />Path To Image File = " + myimage.imagepath);
                Response.Write("<br />Image Guid = " + myimage.myguid + "<br/><br/><br/><br/><br/>");
            }

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            Guid estate_guid = Guid.NewGuid();


            //string mydirerror;
            string[] mydirs = Directory.GetDirectories(@"c:\\", "ProgramData\\MySQL\\MySQL Server 8.0\\Uploads");
            int Totalfiles = mydirs.Count();
            // Loop through them to see if they have any other subdirectories

            foreach (string subdirectory in mydirs)
            {
                string[] array2 = Directory.GetFiles(subdirectory, "*.jpg");
                string csvString = string.Join(",", array2);
            }

            //            Guid estateguid;
            Guid myestateguid = Guid.NewGuid();

            JsonValue value3 = myestateguid.ToString();
            JsonValue MyIndex = (int)168;

            JsonObject target = new JsonObject
            {
               new KeyValuePair<string, JsonValue>("FirstName", "Mario"),
               new KeyValuePair<string, JsonValue>("LastName", "Wakeham"),
               new KeyValuePair<string, JsonValue>("MyGuid", value3)
            };

            JsonObject[] arraytarget = new JsonObject[5];
            //            arraytarget[0] = new JsonObject[5];

            int arraysize = 6;

            string[] mystringarray = new string[arraysize];
            mystringarray[0] = "M";
            mystringarray[1] = "A";
            mystringarray[2] = "R";
            mystringarray[3] = "I";
            mystringarray[4] = "O";
            mystringarray[5] = "W";

            //   JsonArray myjson;
            //    JsonValue = "34";

            //    myjson.Add(JsonValue = "ww");


            string dummy;

            foreach (var item in target)
            {
                dummy = item.Value;
            }
                    
            System.Web.Script.Serialization.JavaScriptSerializer js;
            //           js.Serialize

            string mybreakpoint = "";

            var spimageinsert = new
            {
                items = new[] {new {imageindex = 1, filename = "h.jpg", myestateguid },
                               new {imageindex = 2, filename = "helenedited.jpg",myestateguid }
                }
            };

            //     System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            js = new System.Web.Script.Serialization.JavaScriptSerializer();

            //spimageinsert.items.item.where<>;

            Console.WriteLine(js.Serialize(spimageinsert));

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "";
            MySqlCommand mycmd = new MySqlCommand(query);

            //Generate GUIDS
            string myguidfilename;
            int myimageindex = 0;
            Guid myestate_guid;
            string[] basedirs = Directory.GetDirectories(@"c:\\", "ProgramData\\MySQL\\MySQL Server 8.0\\Uploads");

 
            
            
            JsonObject jsonguid = new JsonObject()
            {
 //              for (int i=0;i<100;i++)
 //               {

//                }

               new KeyValuePair<string, JsonValue>("FirstName", "Mario"),
               new KeyValuePair<string, JsonValue>("LastName", "Wakeham"),
               new KeyValuePair<string, JsonValue>("MyGuid", value3)
            };


            foreach (string mysubdirectory in basedirs)
            {
                string[] array2 = Directory.GetFiles(mysubdirectory, "*.jpg");
                foreach (string myname in array2)
                {

                    myguidfilename = Path.GetFileName(myname);
                    myimageindex += 1;
                    myestate_guid = Guid.NewGuid();


                }
            }

            string mydirerror;
            string[] dirs = Directory.GetDirectories(@"c:\\", "ProgramData\\MySQL\\MySQL Server 8.0\\Uploads");
            int Howmanyfiles = dirs.Count();
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in dirs)
            {
                try
                {
                    string[] array2 = Directory.GetFiles(subdirectory, "*.jpg");
                    string myfilename = "";
                    int imageindex = 0;
                    //system.char guidchar;
                    //MySqlConnection 
                    //MySqlCommand mycmd;
                    conn.Open();
                    foreach (string name in array2)
                    {
                        myfilename = Path.GetFileName(name);
                        imageindex += 1;
                        estate_guid = Guid.NewGuid();

                        query = "INSERT INTO estateporrtal.images (`imageindex`,`image`, `myguid`) VALUES (" + imageindex + ", LOAD_FILE(" + "'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/" + myfilename + "')" + ",'" + estate_guid + "');";
                        mycmd = new MySqlCommand(query);
                        mycmd.Connection = conn;
                        mycmd.ExecuteNonQuery();
                        mycmd.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    mydirerror = ex.Message;
                    conn.Close();
                    conn.Dispose();
                }
            }




        }
    }
}