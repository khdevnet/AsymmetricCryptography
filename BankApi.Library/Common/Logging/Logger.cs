using System.Reflection;
using log4net;

namespace BankApi.Library.Common.Logging
{
    public class Logger
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Info(object message)
        {
            Log.Info(message);
        }
    }
}