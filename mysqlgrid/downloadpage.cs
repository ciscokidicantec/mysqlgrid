using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
//using System.Text.RegularExpressions;




namespace mysqlgrid
{
    public class Downloadpage
    {
        string htmlpage;
        WebClient mywebClient;


        public string Downloadhtmlpage(string wholeurl)
        {
            mywebClient = new CustomWebClient();
            mywebClient.Headers[HttpRequestHeader.Authorization] = "Basic "; //+ base64String;
            htmlpage = mywebClient.DownloadString(wholeurl);


            return htmlpage;
        }



    }
}