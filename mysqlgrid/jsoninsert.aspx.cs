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
using System.Data;




namespace mysqlgrid
{
    public partial class jsoninsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] mydirs = Directory.GetDirectories(@"c:\\", "ProgramData\\MySQL\\MySQL Server 8.0\\Uploads");
            int Totalfiles = mydirs.Count();
            // Loop through them to see if they have any other subdirectories

 //           string filenameonly;

            List<Images> listimages = new List<Images>();
            Guid estate_guid;

            foreach (string subdirectory in mydirs)
            {
                string[] array2 = Directory.GetFiles(subdirectory, "*.jpg");
                string csvString = string.Join(",", array2);

                Images[] images = new Images[array2.Length];

                for (int i = 0; i < array2.Length; i++)
                {
                    estate_guid = Guid.NewGuid();
                    images[i] = new Images();
                    images[i].myindex = i.ToString();
                //    images[i].imagepath = array2[i];
                    images[i].imagepath = Path.GetFileName(array2[i]);
                    images[i].myguid = estate_guid.ToString();

                    listimages.Add(images[i]);

                }
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(listimages);

            // jsonString.Split(jsonString,"}");

            Response.Write(jsonString);

            List<Images> myImages = new List<Images>();

            JavaScriptSerializer myjavaScriptSerializer = new JavaScriptSerializer();
            myImages = (List<Images>)myjavaScriptSerializer.Deserialize(jsonString, typeof(List<Images>));

            Response.Write("<br/><br/>");


            foreach (Images myimage in myImages)
            {
                Response.Write("<br/>Primary Key Index = " + myimage.myindex);
                Response.Write("<br />Path To Image File = " + myimage.imagepath);
                Response.Write("<br />Image Guid = " + myimage.myguid + "<br/>");
            }


            //Binding gridview from dynamic object   
            grdJSON2Grid.DataSource = myImages;
            grdJSON2Grid.DataBind();

            DataTable dt = new DataTable();
            //            dt.Columns.Add("File");
            //            dt.Columns.Add("Size");
            //            dt.Columns.Add("Type");


            //Using DataTable with JsonConvert.DeserializeObject, here you need to import using System.Data;
            // dt = (List<Images>)myjavaScriptSerializer.Deserialize(jsonString, typeof(List<Images>));

            JavaScriptSerializer myjavaScriptdatatabledeSerializer = new JavaScriptSerializer();

            //Random json string, No fix number of columns or rows and no fix column name.   
            //           string myDynamicJSON = "[{'Member ID':'00012','First Name':'Vicki','Last Name':'Jordan','Registered Email':'vicki.j @tacinc.com.au','Mobile':'03 6332 3800','MailSuburb':'','MailState':'','MailPostcode':'','Engagement':'attended an APNA event in the past and ventured onto our online education portal APNA Online Learning','Group':'Non-member'},{'Member ID':'15072','First Name':'Vicki','Last Name':'Jordan','Registered Email':'vicki.j @tacinc.com.au','Mobile':'03 6332 3800','MailSuburb':'','MailState':'','MailPostcode':'','Engagement':'attended an APNA event in the past and ventured onto our online education portal APNA Online Learning','Group':'Non-member'}]";

            //Using dynamic keyword with JsonConvert.DeserializeObject, here you need to import Newtonsoft.Json  
            //           dynamic myObject = myjavaScriptdatatabledeSerializer.DeserializeObject(myDynamicJSON);

            //Binding gridview from dynamic object   
            //           grdJSON2Grid.DataSource = myObject;
            //           grdJSON2Grid.DataBind();

            //Using DataTable with JsonConvert.DeserializeObject, here you need to import using System.Data;  
            //           DataTable myObjectDT = myjavaScriptdatatabledeSerializer.DeserializeObject<DataTable>(myDynamicJSON);

            //Binding gridview from dynamic object   
            //           grdJSON2Grid2.DataSource = myObjectDT;
            //           grdJSON2Grid2.DataBind();

            dynamic myObject = myjavaScriptSerializer.Deserialize(jsonString, typeof(List<Images>));

            //Binding gridview from dynamic object   
            grdJSON3Grid.DataSource = myObject;
            grdJSON3Grid.DataBind();

            string rtn = "spoutrecords";

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand cmd = new MySqlCommand(rtn, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            //  int liststr = 0;
            //string displayitem = "";

            int myrecordseffected = 0;

            return;

            MySqlDataReader rdr = cmd.ExecuteReader();
            myrecordseffected = rdr.RecordsAffected;

            grdJSON4Grid.DataSource = rdr;
            grdJSON4Grid.DataBind();

            conn.Close();
            conn.Dispose();

        
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