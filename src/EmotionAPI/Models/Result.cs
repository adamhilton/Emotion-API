
using System.Collections.Generic;

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

        public string Message { get; set; }

        public bool Success { get; set; }
    }

}
