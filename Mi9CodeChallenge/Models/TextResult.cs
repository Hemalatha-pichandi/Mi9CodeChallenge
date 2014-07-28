using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Text;

namespace Mi9CodeChallenge.Models
{
    public class ErrorResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public ErrorResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value, Encoding.UTF8,"application/json"),
                RequestMessage = _request,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
            return Task.FromResult(response);
        }
    }
}