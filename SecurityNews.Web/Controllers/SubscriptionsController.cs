using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

using BankApi.Library;
using BankApi.Library.Models;
using SecurityNews.Web.Models;

namespace SecurityNews.Web.Controllers
{
    public class SubscriptionsController : AsyncController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Subscribe(CreditCardViewModel creditCardViewModel)
        {
            HttpResponseMessage paymentResult = await new BankPaymentProcessor()
                .PayNowAsync(new CreditCard
                {
                    Number = creditCardViewModel.Number,
                    Date = creditCardViewModel.Date,
                    Cvv = creditCardViewModel.Cvv
                });
            return Json(paymentResult.Content.ReadAsAsync<PaymentResult>().Result);
        }
    }
}