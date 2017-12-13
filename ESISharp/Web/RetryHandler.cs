using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ESISharp.Web
{
    internal class RetryHandler : DelegatingHandler
    {
        internal List<TimeSpan> RetryDelays = new List<TimeSpan>()
        {
            TimeSpan.FromMilliseconds(100),
            TimeSpan.FromMilliseconds(500)
        };

        public RetryHandler() : base(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }) { }

        public void SetRetryStrategy(IEnumerable<TimeSpan> delays) => RetryDelays = delays.ToList();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var retries = 0;
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            while (retries < RetryDelays.Count && !cancellationToken.IsCancellationRequested
                && (response.StatusCode == HttpStatusCode.InternalServerError
                || response.StatusCode == HttpStatusCode.BadGateway
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.GatewayTimeout))
            {
                await Task.Delay(RetryDelays[retries++], cancellationToken).ConfigureAwait(false);
                response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }
    }
}
