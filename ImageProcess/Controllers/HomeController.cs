using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageProcess.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        //public void Capture()
        //{
        //    var stream = this.Request.InputStream;
        //    string dump;

        //    using (var reader = new StreamReader(stream))
        //        dump = reader.ReadToEnd();

        //    var path = this.Server.MapPath("~/test.jpg");
        //    System.IO.File.WriteAllBytes(path, this.String_To_Bytes2(dump));
        //}

        //private byte[] String_To_Bytes2(string strInput)
        //{
        //    int numBytes = (strInput.Length) / 2;
        //    byte[] bytes = new byte[numBytes];

        //    for (int x = 0; x < numBytes; ++x)
        //    {
        //        bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
        //    }

        //    return bytes;
        //}

        /// <summary>
        /// 儲存照片
        /// </summary>
        /// <param name="base64String">base64字串</param>
        /// <returns></returns>
        public ActionResult SaveImage(string base64String)
        {
            Image img = this.Base64ToImage(base64String);
            img.Save(@"D:\test.jpg");

            return this.View();
        }

        /// <summary>
        /// 把base64字串轉成Image物件
        /// </summary>
        /// <param name="base64String">base64字串</param>
        /// <returns>Image物件</returns>
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            return image;
        }

        /// <summary>
        /// 把base64字串轉成Bitmap物件
        /// </summary>
        /// <param name="base64String">base64字串</param>
        /// <returns>Bitmap物件</returns>
        public Bitmap Base64ToBitmap(string base64String)
        {
            byte[] arr = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            ms.Close();

            return bmp;
        }
    }
}