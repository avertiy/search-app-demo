using System.Text.Json.Serialization;

namespace SearchApp.Api.Models
{
    public abstract class Response
    {
        public string Error { get; set; }

        [JsonIgnore]
        public bool Success => string.IsNullOrEmpty(Error);

        internal bool ShouldSerializeError() => !Success;
    }
}