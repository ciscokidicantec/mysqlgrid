using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mysqlgrid
{
    public class Getwebparts
    {

        public List<getpropref> Getpropertyreferences(string htmlpage, string texttosearch, string endtext)
        {
            string fullref;
            List<getpropref> propertyref = new List<getpropref>();

            //string texttosearch = "src=" + '"' + "https://lid.zoocdn.com";
            //string endtext = ".jpg";
            int ihits = 0;
            int interator = 0;
            int ihitsendpos;
            string retString;

            while ((ihits = htmlpage.IndexOf(texttosearch, ihits)) != -1)
            {
                // Print out the substring.
                interator++;
                ihitsendpos = htmlpage.IndexOf(endtext, ihits);
                retString = htmlpage.Substring(ihits + 9, ihitsendpos - (ihits + 10));
                fullref = "https://www.zoopla.co.uk" + retString;
                // Increment the index.
                ihits++;


                //downloadpath.Add(new imagedownloadpath { downloadpath = retString, detaildescriptionpath = returndetails });
                propertyref.Add(new getpropref { propertyreference = fullref });
            }

            return propertyref;


        }




    }
}