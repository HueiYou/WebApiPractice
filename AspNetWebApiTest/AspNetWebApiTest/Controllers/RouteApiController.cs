using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiTest.Controllers
{
    [RoutePrefix("Test/RouteApi")]
    public class RouteApiController : ApiController
    {
        [Route("Get")]
        // GET: Test/RouteApi/Get
        public IEnumerable<string> Get()
        {
            return new string[] { "value11", "value12" };
        }

        // 沒自訂Route的話就會採用預設路由
        // GET: api/RouteApi
        public IEnumerable<string> Get2()
        {
            return new string[] { "value21", "value22" };
        }

        [Route("Get/{id}")]
        // GET: Test/RouteApi/5
        public string Get(int id)
        {
            return "Get id=" + id;
        }

        [Route("Post")]
        // POST: Test/RouteApi
        public string Post([FromBody]string value)
        {
            return "Post value=" + value;
        }

        [Route("Put/{id}")]
        // PUT: Test/RouteApi/5
        public string Put(int id, [FromBody]string value)
        {
            return "Get id=" + id + ", Post value=" + value;
        }

        [Route("Delete/{id}")]
        // DELETE: Test/RouteApi/5
        public void Delete(int id)
        {
        }
    }
}
