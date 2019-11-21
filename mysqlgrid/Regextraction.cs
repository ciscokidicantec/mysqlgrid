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

        public List<MyRegextraction> GetDescription(string searcttext, string regexpattern)
        {
            List<MyRegextraction> propertydes = new List<MyRegextraction>();
            Regex rgxgroup = new Regex(regexpattern);

            int numberofgroups = 0;


//            foreach (Match mymatchdesc in rgxgroup.Matches(searcttext))
//            {
//                propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Groups[numberofgroups].Value });
//                numberofgroups += 1;
//            }

            //return propertydes;


            foreach (Match mymatchdesc in rgxgroup.Matches(searcttext))
            {
                propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Value });
                numberofgroups = mymatchdesc.Groups.Count;

                for (int i = 0; i < mymatchdesc.Groups.Count; i++)
                {
                     propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Groups[i].Value});
                }
            }

            return propertydes;
        }

    }
}