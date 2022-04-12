using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudUsingReact.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> lst = new List<string>
        {
            "Value1", "Value2"
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return lst;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return lst[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
