using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using MySql.Data;

namespace mysqlgrid
{
    public class Dummyparam
    {
        //public void CySqlCommand()
        //public void CreateMySqlCommand(MySqlConnection myConnection, string mySelectQuery,MySqlParameter[] myParamArray)
        public void CreateMySqlCommand(string[] teststring)
        {

            string connStr = ConfigurationManager.ConnectionStrings["estateportalConnectionString"].ConnectionString;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            string mySelectQuery = "SELECT * FROM estateporrtal.images";


            MySqlParameter parameter = new MySqlParameter();
            parameter.ParameterName = "@CategoryName";
            parameter.MySqlDbType = MySqlDbType.Int32;
            //parameter.Direction = MySqlDbDirection.Input;
            parameter.Value = 2345;

            // Add the parameter to the Parameters collection. 
            MySqlCommand command = new MySqlCommand(mySelectQuery, myConnection);

            command.Parameters.Add(parameter);
          //  command.Parameters.

           // MySqlParameter mysp = new MySqlParameter();

           //           string mypname = "myp";
           MySqlParameter myp0 = new MySqlParameter("@imageindex", MySqlDbType.Int32);
           MySqlParameter myp1 = new MySqlParameter("@image", MySqlDbType.LongBlob);

           // , MySqlDbType.VarChar, 36);
            //MySqlParameter myp2 = new MySqlParameter("@myguid",
              //                          MySqlDbType.VarChar,36,
                //                        ParameterDirection.Input,
                  //                      false,
                    //                    byte precision,
                      //                  byte scale,
                        //                string sourceColumn,
                          //              DataRowVersion sourceVersion,
                            //            Object value
                              //          );



            //MySqlParameter output = mysp.ParameterName("myname");


            //teststring = "qwerty";
            string tester = "";
            _ = tester + teststring;


            //MySql.Data.MySqlClient.MySqlParameter

           String[] arrayurlimage = new String[4];

            arrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";

            //.SMySqlParameter[] myParamArray = new MySqlParameter[4];

           // myParamArray[0] = "eee";


            MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
            myCommand.CommandText = "SELECT * FROM estateporrtal.images";
            myCommand.Parameters.Add(myParamArray);
         //   for (int j = 0; j < myParamArray.Length; j++)
            {
        //        myCommand.Parameters.Add(myParamArray[j]);
            }

            //    for (int i = 0; i < myCommand.Parameters.Count; i++)
            //    {
            //        myMessage += myCommand.Parameters[i].ToString() + "\n";
            //    }

            MySql.Data.MySqlClient.MySqlConnection conn;
            string Error_Message = "";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Error_Message = "Cannot connect to server.  Contact administrator";
                        break;
                    case 1045:
                        Error_Message = "Invalid username/password, please try again";
                        break;
                }
            }





        }
    }
}