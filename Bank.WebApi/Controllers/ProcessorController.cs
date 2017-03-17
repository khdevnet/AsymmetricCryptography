using BankApi.Library.Models;
using System.Web.Http;

namespace Bank.WebApi.Controllers
{
    public class ProcessorController : ApiController
    {
        public PaymentResult Post([FromBody]CreditCard creditCard)
        {
            return new PaymentResult { TransactionId = 1233344566, Message = "Success!!" };
        }
    }
}