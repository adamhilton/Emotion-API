#region
using Newtonsoft.Json;
using System.Collections.Generic;
#endregion

namespace EmotionAPI
{
    public struct Result<T>
    {
        public Result(List<T> items, bool success, string message)
            : this()
        {
            Items = items;
            Success = success;
            Message = message;
        }

        public List<T> Items { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("statusCode")]
        public int statusCode { get; set; }

        public bool Success { get; set; }
    }

}
