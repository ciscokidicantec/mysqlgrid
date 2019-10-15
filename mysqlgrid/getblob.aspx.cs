using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;


namespace mysqlgrid
{
    public partial class getblob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            //string query = "SELECT * FROM estateporrtal.images";
            MySqlConnection conn = new MySqlConnection(connStr);
            //MySqlCommand mycmd = new MySqlCommand(query,conn);
            //MySqlDataAdapter da = new MySqlDataAdapter(mycmd);
            string rtn = "spoutrecords";
            MySqlCommand mycmd = new MySqlCommand(rtn, conn);
            mycmd.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlDataReader rdr = mycmd.ExecuteReader();


            //DataTable table = new DataTable();
            //da.Fill(table);

            //< asp:Image ID = "Image1" runat = "server" Height = "250" imageurl = '<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("image"))%>' />

            GridView1.DataSource = rdr;
            GridView1.DataBind();

            //table.Dispose();
            mycmd.Dispose();
            //da.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}