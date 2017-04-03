using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ESISharp.Web
{
    internal class RetryHandler : DelegatingHandler
    {
        internal List<TimeSpan> RetryDelays = new List<TimeSpan>() { TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(500) };

        public RetryHandler() : base(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
        { }

        public void SetRetryStrategy(IEnumerable<TimeSpan> Delays)
        {
            RetryDelays = Delays.ToList();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var Retries = 0;
            HttpResponseMessage Response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            while (Retries < RetryDelays.Count && !cancellationToken.IsCancellationRequested
                && (Response.StatusCode == HttpStatusCode.InternalServerError
                || Response.StatusCode == HttpStatusCode.BadGateway
                || Response.StatusCode == HttpStatusCode.ServiceUnavailable // This can indicate the server is offline, but it also happens randomly at other times.
                || Response.StatusCode == HttpStatusCode.GatewayTimeout))
            {
                await Task.Delay(RetryDelays[Retries++], cancellationToken).ConfigureAwait(false);
                Response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            return Response;
        }
    }
}
