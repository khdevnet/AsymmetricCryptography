using Common;
using Common.Models;
using System.Web.Http;

namespace WebServer.Controllers
{
    public class CheckoutController : ApiController
    {
        public CreditCard Post([FromBody]CreditCard creditCard)
        {
            return creditCard;
        }
    }
}