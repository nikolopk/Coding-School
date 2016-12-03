using CF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CF.Public
{
    public interface IUploadFile
    {
        File UploadFile(HttpPostedFileBase upload);
    }
}
