using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Task1.Forms
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            uploadFileURL(context);
        }


        public void uploadFileURL(HttpContext context)
        {
            context.Response.ContentType = "text/plain"; // what does it do ?
            context.Response.Expires = -1;

            try
            {
                HttpPostedFile uploadedFile = context.Request.Files["file"];
                
                string savePath = "";
                string fileName = "";
                string folderPath = "~/Files/";

                savePath = HostingEnvironment.MapPath(folderPath);
                //fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                fileName = Path.GetFileName(uploadedFile.FileName);

                //if (!Directory.Exists(savePath))
                //{
                //    Directory.CreateDirectory(savePath);
                //}

                uploadedFile.SaveAs(savePath + fileName);

                var resultPath = folderPath.Replace("~", "") + fileName;

                context.Response.Write(resultPath);
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                context.Response.Write("Error = " + ex.Message);
                context.Response.StatusCode = 200;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}