
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redpanda.Http;

namespace System.Net.Http
{
    public static class HttpClientPostJsonExtensions
    {

        /// <summary>
        /// Sends a POST request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PostAsync<T>( this HttpClient httpClient, string requestUri, T obj, CancellationToken cancellationToken = default )
        {
            return PostAsync( httpClient, requestUri, obj, null, cancellationToken );
        }

        /// <summary>
        /// Sends a POST request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PostAsync<T>( this HttpClient httpClient, string requestUri, T obj, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken = default )
        {
            var content = JsonContent.Serialize( obj, jsonSerializerSettings );

            return httpClient.PostAsync( requestUri, content, cancellationToken );
        }
    }
}
