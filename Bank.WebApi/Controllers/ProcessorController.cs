using BankApi.Library.Models;
using System;
using System.Web.Http;

namespace Bank.WebApi.Controllers
{
    public class ProcessorController : ApiController
    {
        private const string ValidCreditCardNumber = "4111111111111111";

        public PaymentResult Post([FromBody]CreditCard creditCard)
        {
            return creditCard.Number == ValidCreditCardNumber
                ? new PaymentResult { TransactionId = GetTransactionId(), Message = "Success!!" }
                : new PaymentResult { Message = "Error!!" };
        }

        private int GetTransactionId()
        {
            return new Random().Next(0, 1233344566);
        }
    }
}