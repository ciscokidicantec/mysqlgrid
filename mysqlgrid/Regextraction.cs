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
        public string[] AllGroups { get; set; }


        public List<MyRegextraction> GetDescription(string searcttext, string regexpattern)
        {

            List<MyRegextraction> propertydes = new List<MyRegextraction>();

            AllGroups = new string[2] { AllGroups[0] = "123", AllGroups[1] = "345" };

            propertydes.Add(new MyRegextraction.AllGroups[]);




            //propertydes.Add(new MyRegextraction {
            //    AllGroups[0] = "123",
            //    AllGroups[1] = "345"
            //});



            //string[] MyRegextraction.arraygroup = new MyRegextraction.AllGroups[4];
            //var arraygroup = new MyRegextraction.AllGroups[4];

            //string arraygroup

            Regex rgxgroup = new Regex(regexpattern);

            int GroupNumber = -1;

            // foreach (Match mymatchgroup in rgxgroup.Matches(searcttext))
            //  {
            //  ListBox3.Items.Add("<a href=" + '"' + website + mymatchgroup.Groups["groupmario"].Value + '"' + ">" + " Hit Number = " + hitc + "</a>");
            //  hitc += 1;


            //            foreach (groupdetails in Groups)
            //            {
            //GroupNumber += 1;
            //propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Groups[GroupNumber].Value });
            //mymatchdesc.Groups[0].Value

            //            }

            int numberofgroups;

            foreach (Match mymatchdesc in rgxgroup.Matches(searcttext))
            {


                //propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Value });
               // propertydes.Add(new MyRegextraction { PropertyDescription = mymatchdesc.Value, AllGroups = new propertydes.Add{AllGroups[0] = "abc", AllGroups[1] = "abc")
                
                
                
                
                
                
           //     });

                numberofgroups = mymatchdesc.Groups.Count;

                //propertydes.AllGroups[] CurrentGroups = new propertydes.AllGroups[numberofgroups];

                List<string> authors = new List<string>(5);
                authors.Add("Mahesh Chand");
                authors.Add("Chris Love");
                authors.Add("Allen O'neill");
                authors.Add("Naveen Sharma");
                authors.Add("Monica Rathbun");
                authors.Add("David McCarter");

                for (int i = 0; i < mymatchdesc.Groups.Count; i++)
                {
                    //  propertydes.Add(new MyRegextraction { AllGroups[i] = mymatchdesc.Groups[0].Value, PropertyDescription = mymatchdesc.Value });

                   // mymatchdesc.Groups[0].Value;
                    }
            }
            return propertydes;
        }

    }
}