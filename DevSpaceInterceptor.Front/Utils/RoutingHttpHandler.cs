using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DevSpaceInterceptor.Front.Utils
{
    public class RoutingHttpHandler : DelegatingHandler
    {
      private readonly IHttpContextAccessor httpContextAccessor;

      public RoutingHttpHandler(IHttpContextAccessor httpContextAccessor)
      {
        this.httpContextAccessor = httpContextAccessor;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage outgoingRequest, CancellationToken cancellationToken)
      {
        var incomingRequest = httpContextAccessor.HttpContext.Request;

        // Propagate the dev space routing header
        if (incomingRequest.Headers.ContainsKey("azds-route-as"))
        {
          outgoingRequest.Headers.Add("azds-route-as", incomingRequest.Headers["azds-route-as"] as IEnumerable<string>);
        }
        return base.SendAsync(outgoingRequest, cancellationToken);
      }
    }
}
