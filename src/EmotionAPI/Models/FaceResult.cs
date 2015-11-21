#region
using Newtonsoft.Json;
#endregion

namespace EmotionAPI
{
    public class FaceRectangle
    {
        [JsonProperty("left")]
        public int Left { get; set; }
        [JsonProperty("top")]
        public int Top { get; set; }
        [JsonProperty("Width")]
        public int Width { get; set; }
        [JsonProperty("Height")]
        public int Height { get; set; }
    }

    public class Scores
    {
        [JsonProperty("anger")]
        public double Anger { get; set; }
        [JsonProperty("contempt")]
        public double Contempt { get; set; }
        [JsonProperty("disgust")]
        public double Disgust { get; set; }
        [JsonProperty("fear")]
        public double Fear { get; set; }
        [JsonProperty("happiness")]
        public double Happiness { get; set; }
        [JsonProperty("neutral")]
        public double Neutral { get; set; }
        [JsonProperty("sadness")]
        public double Sadness { get; set; }
        [JsonProperty("surprise")]
        public double Surprise { get; set; }
    }

    public class FaceResult
    {
        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
        [JsonProperty("scores")]
        public Scores Scores { get; set; }
    }
}
