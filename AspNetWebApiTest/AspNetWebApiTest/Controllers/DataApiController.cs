using AspNetWebApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiTest.Controllers
{
    public class DataApiController : ApiController
    {
        // GET: api/DataApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DataApi/5
        public string Get(int id)
        {
            return "value";
        }

        //不建議寫法
        // POST api/DataApi
        public string Post(string value, string value2)
        {
            return "value=" + value + ", value2=" + value2;
        }

        //// 建議寫法
        //public string Post([FromBody]ValuesPostVM model)
        //{
        //    return "value=" + model.value + ", value2=" + model.value2;
        //}

        // PUT: api/DataApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DataApi/5
        public void Delete(int id)
        {
        }

        // dataApi/{Test*}
        [HttpGet]
        public string Test(int id)
        {
            return "value";
        }
    }
}
