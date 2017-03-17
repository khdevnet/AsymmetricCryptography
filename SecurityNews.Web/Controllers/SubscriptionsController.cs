using BankApi.Library;
using BankApi.Library.Models;
using log4net;
using SecurityNews.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SecurityNews.Web.Controllers
{
    public class SubscriptionsController : AsyncController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            Log.Info("test");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Subscribe(CreditCardViewModel creditCardViewModel)
        {

            var paymentResult = await new BankPaymentProcessor()
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