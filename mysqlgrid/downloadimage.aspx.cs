using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Drawing;
//using System.Drawing.Imaging;
using System.Web.UI.WebControls;
//using System.Drawing.Image;

namespace mysqlgrid
{
    public partial class downloadimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string imageUrl = "https://lc.zoocdn.com/32d3e36d37e1b758b4fa096e9078fd3bd1742ade.jpg";
            string fileName = "C:\\Compress\\h.jpg";
            string iconPath = "";
            string uri = "";

            WebClient client = new WebClient();
                byte[] pic = client.DownloadData(iconPath);
                //string checkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\1.png";
                //File.WriteAllBytes(checkPath, pic);
//                return pic;

            Stream stream = client.OpenRead(imageUrl);

            Bitmap bitmap = new Bitmap(stream); // Error : Parameter is not valid.
            stream.Flush();
            stream.Close();
            client.Dispose();

            if (bitmap != null)
            {
                bitmap.Save("D:\\Images\\" + fileName + ".jpg");
            }

           WebRequest requestPic = WebRequest.Create(imageUrl);
           WebResponse responsePic = requestPic.GetResponse();
           Image webImage = System.Web.UI.WebControls.Image.FromStream(responsePic.GetResponseStream()); // Error
           webImage.Save("D:\\Images\\Book\\" + fileName + ".jpg");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }
    }
}