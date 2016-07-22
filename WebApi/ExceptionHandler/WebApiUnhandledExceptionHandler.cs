using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http.ExceptionHandling;
using log4net;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.ExceptionHandler
{
    public class WebApiUnhandledExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Handle(ExceptionHandlerContext context)
        {
            var model = new ResponseMessageModel();

            var exception = context.Exception;

            while (exception != null)
            {
                Log.Error(exception.Message, exception);

                model.Messages.Add(exception.Message);
                
                exception = exception.InnerException;
            }

            model.Messages.Add("See error log for details.");

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(model, Formatting.Indented), Encoding.Default, "application/json")
            };
  
            context.Result = new ErrorMessageResult(context.Request, response);
        }
    }    
}