using CF.Public;
using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace CF.EntityManagers
{
    public class UploadFileManager : IUploadFile
    {
        public Models.Entities.File UploadFile(HttpPostedFileBase upload)
        {
            Models.Entities.File file = null;
            if (upload != null && upload.ContentLength > 0)
            {
                file = new Models.Entities.File
                {
                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetFileName(upload.FileName),
                    ContentType = upload.ContentType,
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }

                string pathForSaving = HostingEnvironment.MapPath("~/Images");
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    string uploadFilePathAndName = Path.Combine(pathForSaving, file.FileName);
                    upload.SaveAs(uploadFilePathAndName);
                }
            }

            return file;
        }

        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
    }
}
