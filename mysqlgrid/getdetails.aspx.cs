using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Configuration;

using System.Net;



namespace mysqlgrid
{
    public partial class getdetails : System.Web.UI.Page
    {

        string wholeurl = "https://www.zoopla.co.uk/for-sale/property/sn/?page_size=1&q=ab&results_sort=newest_listings&search_source=home&radius=0&pn=0";

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

            //Response.Write("<br/>url used = " + htmlpage + "<br/>");
            //Find references
            //https://www.zoopla.co.uk/for-sale/details/53283801
            //<a href="/for-sale/details/53288433?search_identifier=dda9bf2d323c9ba5b89f632a8b764c35" class="listing-results-price text-price">

            Getwebparts getpathref = new Getwebparts();
            List<getpropref> allreference = getpathref.Getpropertyreferences(htmlpage, "<a href=" + '"' + "/for-sale/details/", '"' + " ");

            foreach (var mytotref in allreference)
            {
                Response.Write("<br/>Path To Detail Descriptions = " + mytotref.propertyreference + "<br/>");
            }




        }
    }
}