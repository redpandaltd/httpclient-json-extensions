using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Redpanda.Http
{
    /// <summary>
    /// Provides HTTP content based on a string containing JSON.
    /// </summary>
    public class JsonContent : StringContent
    {
        /// <summary>
        /// Creates a new instance of the JsonContent class.
        /// </summary>
        /// <param name="content">The content used to initialize the JsonContent</param>
        public JsonContent( string content )
            : base( content, Encoding.UTF8, "application/json" )
        { }

        /// <summary>
        /// Serializes the specified object to a JSON string and into a new instance of the JsonContent class
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <param name="settings">The Newtonsoft.Json.JsonSerializerSettings used to serialize the object. If this is null, default serialization settings will be used.</param>
        /// <returns>A JSonContent instance with the representation of the object.</returns>
        public static JsonContent Serialize( object obj, JsonSerializerSettings settings = null )
        {
            return ( new JsonContent( JsonConvert.SerializeObject( obj, settings ) ) );
        }
    }
}
