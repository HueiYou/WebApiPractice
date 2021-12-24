using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetWebApiTest.Controllers
{
    public class FileApiController : ApiController
    {
        [Route("api/FileUploadApi")]
        [HttpPost]
        public IHttpActionResult Post(HttpPostedFileBase importFile)
        {
            try
            {
                //檢查是否上傳檔案
                if (importFile != null)
                {
                    #region 暫存檔案到fileTemp資料夾
                    var fileName = Path.GetFileName(importFile.FileName);
                    var physicalPath = Path.Combine(System.Web.HttpContext.Current
                                        .Server.MapPath("~/FileTemps"), fileName);
                    importFile.SaveAs(physicalPath);
                    #endregion

                    return Ok("匯入成功");
                }
                else
                {
                    return BadRequest("請匯入檔案");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
