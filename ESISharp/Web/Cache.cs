using ESISharp.Model.Abstract;
using ESISharp.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Web
{
    internal class Cache
    {
        internal string HashRequest(params string[] reqs)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var a = sha1.ComputeHash(Encoding.UTF8.GetBytes(string.Join(" ", reqs)));
                return string.Join("", a.Select(b => b.ToString("x2")).ToArray());
            }
        }

        internal string GetETag(EsiConnection connection, string hash)
            => (string)connection.EsiCache.Get(hash);

        internal void SetCacheItem(EsiConnection connection, string hash, HttpResponseMessage httpresponse, EsiResponse esiresponse)
        {
            var cp = new CacheItemPolicy() { AbsoluteExpiration = httpresponse.Content.Headers.Expires.Value };
            connection.EsiCache.Set(hash, httpresponse.Headers.ETag.Tag, cp);
            connection.EsiCache.Set(httpresponse.Headers.ETag.Tag, esiresponse, cp);
        }

        internal async Task<EsiResponse> GetCacheItem(EsiConnection connection, string etag, HttpResponseMessage httpresponse)
        {
            if (httpresponse.StatusCode == HttpStatusCode.NotModified)
            {
                var cachedresponse = (EsiResponse)connection.EsiCache.Get(etag);
                cachedresponse.IsCached = true;
                return cachedresponse;
            }
            else
            {
                var responsebody = await httpresponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new EsiResponse(responsebody, httpresponse.StatusCode, new EsiContentHeaders(httpresponse.Content.Headers), new EsiResponseHeaders(httpresponse.Headers));
            }
        }
    }
}
