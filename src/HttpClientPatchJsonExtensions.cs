
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redpanda.Http;

namespace System.Net.Http
{
    public static class HttpClientPatchJsonExtensions
    {
        /// <summary>
        /// Sends a PATCH request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PatchAsync<T>( this HttpClient httpClient, string requestUri, T obj, CancellationToken cancellationToken = default )
        {
            return PatchAsync( httpClient, requestUri, obj, null, cancellationToken );
        }

        /// <summary>
        /// Sends a PATCH request with the content serialized as JSON
        /// </summary>
        public static Task<HttpResponseMessage> PatchAsync<T>( this HttpClient httpClient, string requestUri, T obj, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken = default )
        {
            var request = new HttpRequestMessage( new HttpMethod( "PATCH" ), requestUri )
            {
                Content = JsonContent.Serialize( obj, jsonSerializerSettings )                
            };

            return httpClient.SendAsync( request, cancellationToken );
        }
    }
}
