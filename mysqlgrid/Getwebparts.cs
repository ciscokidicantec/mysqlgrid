using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;
using System.Globalization;

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


        public List<getpropref> patermatchpropertyreference(string htmlpage, string pattern)
        {
            RegionInfo country = new RegionInfo(new CultureInfo("en-GB", false).LCID);

            List<getpropref> propertyref = new List<getpropref>();

            Regex rgx = new Regex(pattern);
            string totalurl = "http://www.zoopla.co.uk";
            int extractpos;
            string retpagenostring;

            //<a class="photo-hover" href="/for-sale/details/53305860">

            //split out the <a href text
            foreach (Match match in rgx.Matches(htmlpage))
            {
                //extractpos = pattern.IndexOf("<a href", 0);
                extractpos = pattern.IndexOf("href=",0);

//                retpagenostring = match.Value.Substring("<a href".Length + 2, (match.Value.Length - "<a href".Length - 2));
                //retpagenostring = match.Value.Substring(extractpos + "href=".Length + 1, 26);
                //propertyref.Add(new getpropref{propertyreference = totalurl + retpagenostring, matchindex = match.Index, matchlength = match.Length });
            }

            return propertyref;
        }


    }
}