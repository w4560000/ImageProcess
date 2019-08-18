using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageProcess.helper
{
    public static class ConvertHelper
    {
        /// <summary>
        /// Stream轉Image
        /// </summary>
        /// <param name="stream">資料流</param>
        /// <returns>Image物件</returns>
        public static Image StreamToImage(Stream stream)
        {
            return ByteArrayToImage(StreamToBytes(stream));
        }

        /// <summary>
        /// Stream轉成Byte[]
        /// </summary>
        /// <param name="stream">資料流</param>
        /// <returns>資料位元</returns>
        private static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// byte[]轉換成Image
        /// </summary>
        /// <param name="byteArrayIn">資料位元</param>
        /// <returns>Image物件</returns>
        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;

            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }

        /// <summary>
        /// base64字串轉成Image物件
        /// </summary>
        /// <param name="base64String">base64字串</param>
        /// <returns>Image物件</returns>
        public static Image Base64ToImage(string base64String)
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
        /// base64字串轉成Bitmap物件
        /// </summary>
        /// <param name="base64String">base64字串</param>
        /// <returns>Bitmap物件</returns>
        public static Bitmap Base64ToBitmap(string base64String)
        {
            byte[] arr = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            ms.Close();

            return bmp;
        }
    }
}