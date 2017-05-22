using System.Web.Http.Filters;
using BankApi.Library.Common.Logging;

namespace Bank.WebApi.Filters
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            new Logger().Info(actionExecutedContext.Exception.Message);
        }
    }
}