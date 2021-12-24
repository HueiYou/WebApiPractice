using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiTest.Controllers
{
    public class HttpStatusApiController : ApiController
    {
        // GET: api/HttpStatusApi/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                string result = "你傳入了" + id;

                switch (id)
                {
                    case 200:
                        return this.Ok(result);
                    case 400:
                        return this.BadRequest(result);
                    case 500:
                        throw new Exception("發生伺服器錯誤");
                    default:
                        return this.NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
    }
}
