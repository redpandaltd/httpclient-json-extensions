
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpContentJsonExtensions
    {
        /// <summary>
        /// Reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static Task<T> DeserializeAsync<T>( this HttpContent httpContent, CancellationToken cancellationToken = default )
        {
            return DeserializeAsync<T>( httpContent, null, cancellationToken );
        }

        /// <summary>
        /// Reads the HTTP content to a JSON string and attempts to deserialize it to the specified .NET type.
        /// </summary>
        public static async Task<T> DeserializeAsync<T>( this HttpContent httpContent, JsonSerializerSettings jsonSerializerSettings, CancellationToken cancellationToken = default )
        {
            var json = await httpContent.ReadAsStringAsync();

            if ( string.IsNullOrEmpty( json ) )
            {
                return default( T );
            }

            return JsonConvert.DeserializeObject<T>( json, jsonSerializerSettings );
        }
    }
}
