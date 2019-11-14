using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Configuration;

using System.Net;
using System.Text.RegularExpressions;

namespace mysqlgrid
{
    public partial class getdetails : System.Web.UI.Page
    {
//        string wholeurl = "https://www.zoopla.co.uk/for-sale/property/sn/?page_size=1&q=ab&results_sort=lowest_price&search_source=home&radius=0&pn=1";
        string wholeurl = "https://www.zoopla.co.uk/for-sale/property/sn/?page_size=5&q=ab&results_sort=lowest_price&search_source=home&radius=0&pn=1";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string myplaceofpostcode;
            int indexofpostcode;
            string myplaceofnamepostcode;
            List<Postcode> Gotallthepostcodes;
            WebClient mywebClient;
            int filesizeKbytes;
            string htmlpage;

            //get all postal codes
            Postcodes postcodes = new Postcodes();
            Gotallthepostcodes = postcodes.Getallpostcodes("SN");

            foreach (var mylistofpostcodes in Gotallthepostcodes)
            {
             myplaceofpostcode = mylistofpostcodes.nameofplace;
             indexofpostcode = mylistofpostcodes.postcodeindex;
             myplaceofnamepostcode = mylistofpostcodes.postcode;
             Response.Write("<br/> Place Name = " + myplaceofpostcode + "<br/> Index Of Post Code = " + indexofpostcode + "<br/> Actual Post Code = " + myplaceofnamepostcode);
            }

            //Get to the top level selling page for zoopla, start at page zero
            mywebClient = new CustomWebClient();
            mywebClient.Headers[HttpRequestHeader.Authorization] = "Basic "; //+ base64String;
            htmlpage = mywebClient.DownloadString(wholeurl);

            //qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq

            //string pagepattern = "/for-sale/property/sn/?q=sn&search_source=home&radius=0&pn=";
            //string pagepattern = "/for-sale/property/sn";
            //string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2" + '"';
            //string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/?p\\w+";
            //"" + "page_size";
            //=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2" + '"';

            //string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=477" + '"';
            //string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=\\d\\d\\d" + '"';
            //string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=\\d\\d\\d" + '"';


            //< a href = "/for-sale/property/sn/\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2"\s\s\s\s\s\s\s>Next</a>
            //   string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2" + '"' + "\\s{7}>Next</a>";
            //<a href="/for-sale/property/sn/\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2"\s{1}\r\n\s\s\s\s>Next</a>

            string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=2" + '"' + "\\s{1}\\r\\n\\s{4}>Next</a>\r\n";

//qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq
 //       public static Regex regex = new Regex(
//      "<a href=\"/for-sale/property/sn/\\?page_size=5&amp;q=ab&amp;" +
//      "results_sort=lowest_price&amp;search_source=home&amp;radius=" +
//      "0&amp;pn=2\"\\s{1}\\r\\n\\s{4}>Next</a>\r\n",
//    RegexOptions.CultureInvariant
//    | RegexOptions.Compiled
//    );







        //ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt



        string totalurl = "https://www.zoopla.co.uk";
            
            
            Regex regexlastpagenumber = new Regex(pagepattern);

            foreach (Match mymatchpage in regexlastpagenumber.Matches(htmlpage))
            {

                Response.Write("<br/><br/>Page Matches = " + totalurl + mymatchpage.Value + ">" + mymatchpage.Value + "</a>");


            }

            return;


                Response.Write("Start of href");

            string getnumberofpages = "<br/><br/><a href=" + '"' + "https://www.zoopla.co.uk/for-sale/property/sn/?q=sn&search_source=home&radius=0&pn=3" + '"' + ">" + "Next Page Number To Click" + "</a><br/><br/>";
            Response.Write(getnumberofpages);

        //    Regex rgxgroup = new Regex(pagepattern);
        //    Match match = Regex.Match(htmlpage, "mypattern");


            Response.Write("End of href");


            //Response.Write("<br/>url used = " + htmlpage + "<br/>");
            //Find references
            //https://www.zoopla.co.uk/for-sale/details/53283801
            //<a href="/for-sale/details/53288433?search_identifier=dda9bf2d323c9ba5b89f632a8b764c35" class="listing-results-price text-price">

            Getwebparts getpathref = new Getwebparts();
            List<getpropref> allreference = getpathref.Getpropertyreferences(htmlpage, "<a href=" + '"' + "/for-sale/details/", '"' + " ");
            //List<getpropref> allreference = getpathref.Getpropertyreferences(htmlpage, "&pound;"," ");
            //List<getpropref> allreference = getpathref.Getpropertyreferences(htmlpage, "<a href=" + '"' + "/for-sale/details/", "?");

            Getwebparts getpathrefregex = new Getwebparts();

            // string mypattern = @"<a href=" + '"' + "/for-sale/details/\\d{8}?";
            //string mypattern = "<a href=" + '"' + "/for-sale/details/\\d{8}";
            //string mypattern = "<a class="photo-hover" href="/for-sale/details/53305860">
            //string mypattern = "<a class=" + '"' + "photo-hover" + '"' + " href=" + '"' + "/for-sale/details/\\d{8}";
            //string mypattern = "<a class=" + '"' + "photo-hover" + '"' + " href=" + '"' + "/for-sale/details/\\d{8}";
            //string mypattern = "<a class=" + '"' + "photo-hover" + '"' + " href=" + '"' + "(?<groupmario>/for-sale/details/\\d{8})";
            string mypattern = "(?<groupclass><a class=)" + '"' + "(?<grouphover>photo-hover)" + '"' + "(?<grouphref> href=)" + '"' + "(?<groupmario>/for-sale/details/\\d{8})";

            // Match extractgroupmario;

            Regex rgxgroup = new Regex(mypattern);
            Match match = Regex.Match(htmlpage, "mypattern");

            string website = "https://www.zoopla.co.uk";


            foreach (Match mymatchgroup in rgxgroup.Matches(htmlpage))
            {
              //  ListBox1.Items.Add(mymatchgroup.Value);
                ListBox1.Items.Add(mymatchgroup.Groups["groupmario"].Value);
                ListBox1.Items.Add(mymatchgroup.Groups["grouphref"].Value);
                ListBox1.Items.Add(mymatchgroup.Groups["grouphover"].Value);
                ListBox1.Items.Add(mymatchgroup.Groups["groupclass"].Value);
                ListBox1.Items.Add(mymatchgroup.Groups[0].Value);
            }

            foreach (Match mymatchgroup in rgxgroup.Matches(htmlpage))
            {
                ListBox2.Items.Add(website + mymatchgroup.Groups["groupmario"].Value);
            }

            int hitc = 0;

            foreach (Match mymatchgroup in rgxgroup.Matches(htmlpage))
            {
                ListBox3.Items.Add("<a href=" + '"' + website + mymatchgroup.Groups["groupmario"].Value + '"' + ">" + " Hit Number = " + hitc + "</a>");
                hitc += 1;

                Response.Write("<br/><a href=" + '"' + website + mymatchgroup.Groups["groupmario"].Value + '"' + "target=" + '"' + "_blank" + '"' + ">" + website + mymatchgroup.Groups["groupmario"].Value + " Hit Number = " + hitc + "</a>");

            }



            //< a class="photo-hover" href="/for-sale/details/53305860">



            //            List<getpropref> patermatchpropertyreference = getpathrefregex.patermatchpropertyreference(htmlpage, "<a href=" + '"' + "/for-sale/details/\\d\\d\\d\\d\\d\\d\\d\\d[?]");
            //            List<getpropref> patermatchpropertyreference = getpathrefregex.patermatchpropertyreference(htmlpage, "<a href=" + '"' + "/for-sale/details/\\d{8}?search_identifier=");


            List< getpropref> patermatchpropertyreference = getpathrefregex.patermatchpropertyreference(htmlpage, mypattern);


            int mycounter = 0;
            string buildancor = "";

            foreach (var mytotrefregex in patermatchpropertyreference)
            {
                //Response.Write("<br/>Path To Detail Descriptions  Using REGEX = " + mytotrefregex.propertyreference.ToString() + " Value from zero based start = " + mytotrefregex.matchindex.ToString()  + "<br/>");
                //Response.Write("<br/><br/>");
                //<a href="https://www.w3schools.com/html/">Visit our HTML tutorial</a>

                //buildancor = "<br/>" + mytotrefregex.propertyreference.ToString() + '"' + "https://ciscokidicantec.mario.wakeham.name/" + '"' + ">My Google Web Site " + mytotrefregex.matchindex.ToString() + "<a/>" + "<br/>";
                //buildancor = "<br/>" + mytotrefregex.propertyreference.ToString() + '"' + "https://ciscokidicantec.mario.wakeham.name/" + '"' + ">My Google Web Site " + mytotrefregex.matchindex.ToString() + "<a/>" + "<br/>";

                buildancor = "<br/><br/>" + mytotrefregex.propertyreference.ToString();

                Response.Write(buildancor);
                mycounter++;
            }

             

      //      foreach (var mytotref in allreference)
      //      {
     //           Response.Write("<br/>Path To Detail Descriptions = " + mytotref.propertyreference + "<br/>");
     //       }




        }
    }
}