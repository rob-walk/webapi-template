using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.ActionResults
{
    public class HttpActionResult : IHttpActionResult
    {
        private readonly StringContent _message;
        private readonly HttpStatusCode _statusCode;

        public HttpActionResult(HttpStatusCode statusCode, StringContent content)
        {
            _statusCode = statusCode;
            _message = content;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = _message
            };
            return Task.FromResult(response);
        }
    }
}