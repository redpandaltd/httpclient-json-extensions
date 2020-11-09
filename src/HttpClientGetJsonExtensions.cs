
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpClientGetJsonExtensions
    {
        /// <summary>
        /// Sends a GET request and reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static Task<T> GetAsync<T>( this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default )
        {
            return GetAsync<T>( httpClient, requestUri, null, null, cancellationToken );
        }

        /// <summary>
        /// Sends a GET request and reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static Task<T> GetAsync<T>( this HttpClient httpClient, string requestUri, Action<HttpResponseMessage> errorAction, CancellationToken cancellationToken = default )
        {
            return GetAsync<T>( httpClient, requestUri, null, errorAction, cancellationToken );
        }

        /// <summary>
        /// Sends a GET request and reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static Task<T> GetAsync<T>( this HttpClient httpClient, string requestUri, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken = default )
        {
            return GetAsync<T>( httpClient, requestUri, jsonSerializerSettings, null, cancellationToken);
        }

        /// <summary>
        /// Sends a GET request and reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static async Task<T> GetAsync<T>( this HttpClient httpClient, string requestUri, JsonSerializerSettings jsonSerializerSettings, Action<HttpResponseMessage> errorAction, CancellationToken cancellationToken = default )
        {
            var response = await httpClient.GetAsync( requestUri, cancellationToken );

            if ( !response.IsSuccessStatusCode )
            {
                errorAction?.Invoke( response );
            }

            if ( response.StatusCode != System.Net.HttpStatusCode.OK )
            {
                // will not attempt to deserialize if the status code is not 200 (OK)
                return ( default( T ) );
            }

            var obj = await response.Content.DeserializeAsync<T>( jsonSerializerSettings, cancellationToken );

            return ( obj );
        }
    }
}
