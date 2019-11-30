using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;


namespace mysqlgrid
{

    public class Postcodes
    {

      //  public string Getallpostcodes { get; set; }
 
        public List<Postcode> postcodelist = new List<Postcode>();
        public Postcode postcodeinstance = new Postcode();

        string errormessage;
        string dummypostcode;
        int dummypostindex;
        string dummyplaceof;

       public List<Postcode> Getallpostcodes(string particularcodename)
        {
            string commandstring;
            try
            {
                string myconnpostcodeStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
                MySqlConnection connpostcode = new MySqlConnection(myconnpostcodeStr);

                if (particularcodename == "*")
                {
                    commandstring = "SELECT * FROM postcodes";
                }
                else
                {
                    commandstring = "SELECT * FROM postcodes WHERE TRIM(POSTCODE) = '" + particularcodename + "'";
                }

//                string commandstring = "SELECT * FROM postcodes WHERE TRIM(POSTCODE) = 'SN'";
                //                string commandstring = "SELECT * FROM postcodes WHERE TRIM(POSTCODE) = 'BN' OR TRIM(POSTCODE) = 'BD' OR TRIM(POSTCODE) = 'CB'";

                MySqlCommand mypostcodecmd = new MySqlCommand(commandstring, connpostcode);
                mypostcodecmd.CommandType = System.Data.CommandType.Text;

                connpostcode.Open();
                //  string areapostcode;
                MySqlDataReader rdrpostcode = mypostcodecmd.ExecuteReader();
                while (rdrpostcode.Read())
                {
                    postcodelist.Add(new Postcode
                    {
                        postcodeindex = (int)rdrpostcode["indexpostcode"],
                        postcode = (string)rdrpostcode["postcode"],
                        nameofplace = (string)rdrpostcode["codeareadescription"]
                    });
                }

                connpostcode.Close();
                connpostcode.Dispose();
            }
            catch (Exception postcodeex)
            {
                errormessage = "Error Message = " + postcodeex.Message;
            }

            foreach(var samplepostcode in postcodelist)
            {
                dummyplaceof = samplepostcode.nameofplace;
                dummypostindex = samplepostcode.postcodeindex;
                dummypostcode = samplepostcode.postcode;
            }

            return postcodelist;
        }

    }
}