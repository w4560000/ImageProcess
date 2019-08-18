using ImageProcess.helper;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ImageProcess.Controllers
{
    public class HomeController : Controller
    {
        private readonly string basePath = AppDomain.CurrentDomain.BaseDirectory + "uploads";

        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// 儲存照片
        /// </summary>
        /// <returns>檔名</returns>
        public ActionResult SaveImage()
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd_hhmmssfff") + ".jpg";
            HttpPostedFileBase file = this.Request.Files[0]; 
            file.SaveAs(Path.Combine(this.basePath, fileName));

            return this.Json(fileName);
        }

        /// <summary>
        /// 儲存影片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostRecordedAudioVideo()
        {
            foreach (string upload in this.Request.Files)
            {
                var file = this.Request.Files[upload];
                if (file == null)
                    continue;

                file.SaveAs(Path.Combine(this.basePath, this.Request.Form[0]));
            }

            return this.Json(this.Request.Form[0]);
        }

        /// <summary>
        /// 刪除影片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteFile()
        {
            new FileInfo(Path.Combine(this.basePath, this.Request.Form["delete-file"])).Delete();

            return this.Json(true);
        }
    }
}