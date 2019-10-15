using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace mysqlgrid
{
    public partial class picturegallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadImages();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + fileName);
            }
            Response.Redirect("~/picturegallery.aspx");
        }

        private void LoadImages()
        {
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Data")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fi = new FileInfo(strfile);
                imageButton.ImageUrl = "~/Data/" + fi.Name;
                imageButton.Height = Unit.Pixel(450);
                imageButton.Style.Add("padding", "5px");
                //imageButton.Width = Unit.Pixel(100);
                imageButton.Click += new ImageClickEventHandler(ImageButton_Click);
                Panel1.Controls.Add(imageButton);
            }

        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("webform2.aspx?ImageURL=" + ((ImageButton)sender).ImageUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (1602, LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/101D0578.JPG'));
            string constr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            int imageindex = 8000;
            string myfilename;

            Label1.Text = "Just Started";

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //    cmd.Parameters.AddWithValue("@imageindex", imageindex);
                //    cmd.Parameters.AddWithValue("@filedirectory", filedirectory);

                string mydirerror;
                string[] dirs = Directory.GetDirectories(@"c:\\", "ProgramData\\MySQL\\MySQL Server 8.0\\Uploads");

                // Loop through them to see if they have any other subdirectories
                foreach (string subdirectory in dirs)
                {
                    try
                    {
                        string[] array2 = Directory.GetFiles(subdirectory, "*.jpg");
                        con.Open();
                        foreach (string name in array2)
                        {
                            myfilename = Path.GetFileName(name);
                            imageindex += 1;
                            string query = "INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (" + imageindex + ", LOAD_FILE(" + "'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/" + myfilename + "'));";
                            //string query = "INSERT INTO estateporrtal.images (`imageindex`,`image`) VALUES (" + imageindex + ", LOAD_FILE('" + myfilename + "'));";
                            MySqlCommand cmd = new MySqlCommand(query);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        con.Close();
                        con.Dispose();
                        Label1.Text = "Completed";
                    }
                    catch (Exception ex)
                    {
                        mydirerror = ex.Message;
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Guid estate_guid;
            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "";
            MySqlCommand mycmd = new MySqlCommand(query);

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
                    Label1.Text = "Completed";
                }
                catch (Exception ex)
                {
                    mydirerror = ex.Message;
                    conn.Close();
                    conn.Dispose();
                }
            }

            estate_guid = Guid.NewGuid();


            string rtn = "sploadimage";     //Stored Procedure Name
            int getbackindex;
            int myrecordseffected = 0;
            MySqlCommand cmd = new MySqlCommand(rtn, conn);
            cmd.Parameters.AddWithValue("@idx", 601);
            cmd.Parameters.AddWithValue("@myfilename", "h.jpg");
            cmd.Parameters.AddWithValue("@myguid", estate_guid);
            cmd.Parameters["@myguid"].Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters["@idx"].Direction = System.Data.ParameterDirection.InputOutput;

            //   cmd.Parameters.AddWithValue("seeindex", getbackindex);


            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                //Connecting to MySQL.
                conn.Open();

              //  int liststr = 0;
                //string displayitem = "";

                MySqlDataReader rdr = cmd.ExecuteReader();
                myrecordseffected = rdr.RecordsAffected;
                string returnedguid;
                string message = " Not Found 601";

                GridView1.DataSource = rdr;
                GridView1.DataBind();

                //return;

                // while (rdr.HasRows)
                while (rdr.Read())
                {
                    getbackindex = rdr.GetInt32("imageindex");
                    if (getbackindex == 601)
                    {
                        message = "Found 601";
                    }
                    //getbackindex = rdr["imageindex"].ToString(); // Convert.ToBase64String((byte[])Eval("image"))
                    //getbackindex = Convert.ToString(rdr["imageindex"]);

                    //getbackindex = rdr["imageindex"];

                    //ListBox1.Items.Add(rdr["imageindex"].ToString() +  " " + rdr["myguid"].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }

}

