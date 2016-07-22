using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.ActionResults;

namespace WebApi.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        public IHttpActionResult CreateResponse(HttpStatusCode statusCode, string messageFormat, params object[] args)
        {
            var model = new ResponseMessageModel();

            model.Messages.Add(string.Format(messageFormat, args));

            var content = new StringContent(JsonConvert.SerializeObject(model, Formatting.Indented), Encoding.Default,
                "application/json");

            return new HttpActionResult(statusCode, content);
        }
    }
}