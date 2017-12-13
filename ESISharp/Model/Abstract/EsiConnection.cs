using ESISharp.Enumeration;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ESISharp.Model.Abstract
{
    public abstract class EsiConnection
    {
        internal DataSource DataSource = DataSource.Tranquility;
        internal ResponseType ResponseType = ResponseType.Json;
        internal Route Route = Route.Latest;

        internal RetryHandler ClientHandler = new RetryHandler();
        internal HttpClient QueryClient;
        internal string UserAgent = @"ESISharp (github.com/wranders/ESISharp)";

        internal Access Access;

        protected EsiConnection()
        {
            QueryClient = new HttpClient(ClientHandler);
            QueryClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            QueryClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            QueryClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            Access = Access.Public;
        }

        public void SetDataSource(DataSource datasource) => DataSource = datasource;

        public void SetResponseType(ResponseType responsetype) => ResponseType = responsetype;

        public void SetRetryStrategy(IEnumerable<TimeSpan> delays) => ClientHandler.SetRetryStrategy(delays);

        public void SetRoute(Route route) => Route = route;

        public void SetTimeout(TimeSpan timespan) => QueryClient.Timeout = timespan;

        public void SetUserAgent(string useragent)
        {
            UserAgent = useragent;
            QueryClient.DefaultRequestHeaders.UserAgent.Clear();
            QueryClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }
    }
}
