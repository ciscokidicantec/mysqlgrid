using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Text.RegularExpressions;


namespace mysqlgrid
{

    public class MyRegextraction
    {

        public string PropertyDescription { get; set; }
        public string Groupnme { get; set; }


        public List<MyRegextraction> GetDescription(string searcttext, string regexpattern)
        {

            List<MyRegextraction> propertydes = new List<MyRegextraction>();

            Regex rgxgroup = new Regex(regexpattern);
            //            Match match = Regex.Match(searcttext, "mypattern");

            foreach (Match mymatchdesc in rgxgroup.Matches(searcttext))
            {
                //propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Groups["grouppagenumer"].Value });
                propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Value });

            }
            return propertydes;
        }

    }
}