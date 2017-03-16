using System.Collections.Generic;
using System.Web.Http;

namespace WebSslSecure.Controllers
{
    public class BikesController : ApiController
    {
        // GET: api/Bikes
        public IEnumerable<string> Get()
        {
            return new string[] { "Fokus", "Kellys" };
        }

        // GET: api/Bikes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bikes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bikes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bikes/5
        public void Delete(int id)
        {
        }
    }
}