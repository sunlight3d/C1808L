using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiChat.Controllers
{
    internal class HttpActionResult : IHttpActionResult
    {
        private HttpStatusCode internalServerError;
        private string v;

        public HttpActionResult(HttpStatusCode internalServerError, string v)
        {
            this.internalServerError = internalServerError;
            this.v = v;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}