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
using System.Drawing;

using System.IO;
using System.Drawing.Drawing2D;
using System.Json;
using System.Web.Script.Serialization;





namespace mysqlgrid
{
    public partial class getdetails : System.Web.UI.Page
    {
        string wholeurl = "https://www.zoopla.co.uk/for-sale/houses/sn/?beds_min=3&price_max=2000000&property_type=houses&price_min=10000&page_size=25&q=sn&results_sort=lowest_price&search_source=refine&radius=0&pn=14";


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


            // string pagepattern = "<a href=" + '"' + "/for-sale/property/sn/\\?page_size=\\d{0,5}&amp;q=ab&amp;results_sort=lowest_price&amp;search_source=home&amp;radius=0&amp;pn=(?<grouppagenumer>\\d{0,5})" + '"';
            string pagepattern = "<a href=" + '"' + "/for-sale/houses/sn/\\?beds_min=\\d{0,3}&amp;price_max=\\d{0,10}&amp;property_type=houses&amp;price_min=\\d{0,10}&amp;page_size=\\d{0,5}&amp;q=sn&amp;results_sort=lowest_price&amp;search_source=refine&amp;radius=\\d{0,3}&amp;pn=(?<grouppagenumer>\\d{0,5})" + '"';




             //ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt

             string totalurl = "https://www.zoopla.co.uk";
            
            
            Regex regexlastpagenumber = new Regex(pagepattern);

            int biggestnumber = 0;
            int pagenumber = 0;

            foreach (Match mymatchpage in regexlastpagenumber.Matches(htmlpage))
            {
                
                Response.Write("<br/><br/>Page Numbers That Match = " + mymatchpage.Groups["grouppagenumer"].Value + "<br/>");

                //pagenumber = mymatchpage.Groups["grouppagenumer"].Value.Max();

                pagenumber = int.Parse(mymatchpage.Groups["grouppagenumer"].Value);
                if (pagenumber > biggestnumber)
                {
                    biggestnumber = pagenumber;
                }
            }

            Response.Write("Maximum Page Number = " + biggestnumber.ToString());

            //return;


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




//qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq

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
            string fullurl;
            Downloadpage mydetailshtmlpage;
            string myhtmlreturned;
            bool savethefile;


            MyRegextraction Alldescriptions;
            MyRegextraction Theprice;
            MyRegextraction Thesummary;
            MyRegextraction Thebulletts;
            MyRegextraction Theimages;
            MyRegextraction Thesvgs;


            string fileName;
            string imageUrl;
            string myregeximages;

            Stream streamdata;

            WebClient client;
            Bitmap bitmap;

            int returnedrows;


            foreach (Match mymatchgroup in rgxgroup.Matches(htmlpage))
            {
                ListBox3.Items.Add("<a href=" + '"' + website + mymatchgroup.Groups["groupmario"].Value + '"' + ">" + " Hit Number = " + hitc + "</a>");
                hitc += 1;

                
                Response.Write("<br/><a href=" + '"' + website + mymatchgroup.Groups["groupmario"].Value + '"' + "target=" + '"' + "_blank" + '"' + ">" + website + mymatchgroup.Groups["groupmario"].Value + " Hit Number = " + hitc + "</a>");
                fullurl = website + mymatchgroup.Groups["groupmario"].Value;
                mydetailshtmlpage = new Downloadpage();
                myhtmlreturned = mydetailshtmlpage.Downloadhtmlpage(fullurl);


                string imageUrldownload;

                imageUrldownload = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";

                //Download SVG images without saving to disk place into database
                //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmSVGmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

                //string mysvgimages = "\\s{0,50}<li class=\"dp-features-list__item\">.*\\n\\s{0,100}.*\\n\\s{0,100}</li>";

                //s{0,150}\\.*\\"https://[a-zA-z].*.svg

                //string mysvgimages = "s{0,150}\\.*\\\"(?<groupclass>https://[a-zA-z].*.svg)";

                //"\\s{0,100}src=\\\"(?<mariogroup>).*svg",

                string mysvgimages = "(?<groupclass>\\s{0,100})src=\\\"(<?<groupclass>.*svg)";

                //string mysvgimages = "\\s{0,150}\\.*.src=\\"(?<groupclass>https://[a-zA-z].*.svg)";
                Thesvgs = new MyRegextraction();

                List<MyRegextraction> Gotsvg = Thesvgs.GetDescription(myhtmlreturned, mysvgimages);

                foreach (var showsvg in Gotsvg)
                {
                    Response.Write("<br/>Returned SVG Points = " + showsvg.PropertyDescription + "<br/>");
                }


                bool imstatus;

                Insertsvgtodatabase Insimagedb = new Insertsvgtodatabase();

                //imstatus = Insimagedb.Insimagetodb("https://r.zoocdn.com/assets/safari-pinned-tab.svg", false);

                imstatus = Insimagedb.Insimagetodb(Gotsvg, false);


                imageUrl = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";

                //client = new WebClient();
                //byte[] imagebytes = client.DownloadData(imageUrldownload);
                //filesizeKbytes = imagebytes.Length;

                //SVG for this property

                imageUrl = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";


//                fileName = "testjpg";

//                fileName = "C:\\Compress\\" + fileName + ".jpg";

//                streamdata = client.OpenRead(imageUrl);
//                bitmap = new Bitmap(streamdata);
//                bitmap.Save(fileName);
//                bitmap.Dispose();

                //Get Bullet Poimts
                string myregexbulletpoints = "\\s{0,50}<li class=\"dp-features-list__item\">.*\\n\\s{0,100}.*\\n\\s{0,100}</li>";

                Thebulletts = new MyRegextraction();
                List<MyRegextraction> Gotbulletts = Thebulletts.GetDescription(myhtmlreturned, myregexbulletpoints);

                foreach (var showbulletts in Gotbulletts)
                {
                    Response.Write("<br/>Returned Bullett Points = " + showbulletts.PropertyDescription + "<br/>");
                }

                //Get Post Code
//zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz


                //Get the features
                string myregexfeatures = "\\s{0,50}<span class=\"dp-features-list__text\">.*";

                Thesummary = new MyRegextraction();
                List<MyRegextraction> Gotfeatures = Thesummary.GetDescription(myhtmlreturned, myregexfeatures);

                foreach (var showfeatures in Gotfeatures)
                {
                    Response.Write("<br/>Returned features = " + showfeatures.PropertyDescription + "<br/>");
                }

                //Pick up the property summary
                //Put in the groups to extract the address

                //            string mypattern = "(?<groupclass><a class=)" + '"' + "(?<grouphover>photo-hover)" + '"' + "(?<grouphref> href=)" + '"' + "(?<groupmario>/for-sale/details/\\d{8})";


                string myregexsummary = "\\s{0,50}<h2 class=\"ui-property-summary__address\">" + "(?<groupaddress>.*)" + "," + "(?<grouppostcode>.*)</h2>";

                Thesummary = new MyRegextraction();
                List<MyRegextraction> Gotsummary = Thesummary.GetDescription(myhtmlreturned, myregexsummary);

                //Download svg https://r.zoocdn.com/assets/safari-pinned-tab.svg

            //    string Fileurl = "https://r.zoocdn.com/assets/safari-pinned-tab.svg";

            //    WebClient GetSvgFile = new WebClient();

            //    byte[] gotsvgdata = GetSvgFile.DownloadData(Fileurl);

           //     GetSvgFile.DownloadFile(Fileurl, "C:\\Users\\Public\\Documents\\guidsvgfilename.svg");


                //WebClient client.downloadfile

                //Get All SGV type images.




                //Get all the pictures
                myregeximages = "\\s{0,100}.*<img data-src=\"(?<groupimagesrc>.*.jpg)";

                Theimages = new MyRegextraction();
                List<MyRegextraction> Gotimages = Theimages.GetDescription(myhtmlreturned, myregeximages);

                int myindex = 0;
                bool insertsuccess;

                insertimagetodatabase Insertimagetodbase = new insertimagetodatabase();


                foreach (var showimages in Gotimages)
                {
                    myindex += 1;

                    if (myindex % 2 == 0)
                    {
                        Response.Write("Number is even");
                        //This is the List<T> item which contains the correct image path - download the image itself
                        //Then insert it into the database
                        Response.Write("<br/>Full Images Path = " + showimages.PropertyDescription);
                        insertsuccess = Insertimagetodbase.Insertimagetodbase(showimages.PropertyDescription, "stuff");
                        if (insertsuccess)
                        {
                            Response.Write("Successful Database Update");
                        }
                        else
                        {
                            Response.Write("Unsuccessful Database Update");

                        }
                    }
                    else
                    {
                        Response.Write("<br/>Number is odd");
                    }
                }








                foreach (var showsummary in Gotsummary)
                {
                    Response.Write("<br/>Returned Summary = " + showsummary.PropertyDescription + "<br/>");
                }

                //Get The Properties price
                string myregexprice = "\\s{0,50}<p class=\"ui-pricing__main-price ui-text-t4\">" + "Â£" + "\\d{0,10}" + "," + "\\d{0,10}" + "</p>";

                Theprice = new MyRegextraction();
                List<MyRegextraction> Gotprice = Theprice.GetDescription(myhtmlreturned, myregexprice);

                foreach (var showprice in Gotprice)
                {
                    Response.Write("<br/>Returned Price = " + showprice.PropertyDescription + "<br/>");
                }


                //Now pick up the description for each property
                string myregpat = "\\n\\s{0,50}<div class=\"dp-description__text\">.*\\n\\s{0,50" + "}.*\\n\\s{0,50}</div>";

                Alldescriptions = new MyRegextraction();
                List<MyRegextraction> Gotdes = Alldescriptions.GetDescription(myhtmlreturned, myregpat);

                foreach (var showdes in Gotdes)
                {
                    Response.Write("<br/>Returned Descriptions = " + showdes.PropertyDescription + "<br/>") ;
                }


                String[] myarrayurlimage = new String[4];

                myarrayurlimage[0] = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
                myarrayurlimage[1] = "https://lc.zoocdn.com/c2a8a5af5cec2db187ae1a37d4f8d3965e9d5b87.jpg";
                myarrayurlimage[2] = "https://media.rightmove.co.uk/dir/crop/10:9-16:9/78k/77900/73713541/77900_MAR190232_IMG_06_0000_max_476x317.jpg";
                myarrayurlimage[3] = "https://pbprodimages.azureedge.net/images/medium/2a00f1ab-a7cb-4315-b247-c3d40636f041.jpg";

                savethefile = true;
                string filename = "abc";


//ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc


                Savetodatabase additemtodatabase = new Savetodatabase();
                returnedrows = additemtodatabase.Savephototodatabase(myarrayurlimage, filename, savethefile);

            }

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

        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}