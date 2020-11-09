using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redpanda.Http;

namespace System.Net.Http
{
    public static class HttpClientPutJsonExtensions
    {
        /// <summary>
        /// Sends a PUT request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PutAsync<T>( this HttpClient httpClient, string requestUri, T obj, CancellationToken cancellationToken = default )
        {
            return PutAsync( httpClient, requestUri, obj, null, cancellationToken );
        }

        /// <summary>
        /// Sends a PUT request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PutAsync<T>( this HttpClient httpClient, string requestUri, T obj, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken = default )
        {
            var content = JsonContent.Serialize( obj, jsonSerializerSettings );

            return httpClient.PutAsync( requestUri, content, cancellationToken );
        }
    }
}
