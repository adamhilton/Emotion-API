
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmotionAPI
{
    internal class Deserializer
    {
        public static Result<FaceResult> GetResults(JObject response)
        {
            //TODO: check for errors

            var faceResults = new List<FaceResult>();

            var responseItems = JArray.Parse(response["list"].ToString());

            foreach (var item in responseItems)
            {
                var faceResult = new FaceResult();
                if (response["faceRectangle"] != null)
                {
                    faceResult.faceRectangle.left = Convert.ToInt32(item["faceRectangle"]["left"]);
                    faceResult.faceRectangle.top = Convert.ToInt32(item["faceRectangle"]["top"]);
                    faceResult.faceRectangle.width = Convert.ToInt32(item["faceRectangle"]["width"]);
                    faceResult.faceRectangle.left = Convert.ToInt32(item["faceRectangle"]["height"]);
                }
                if(response["scores"] != null)
                {
                    faceResult.scores.anger = Convert.ToInt32(item["scores"]["anger"]);
                    faceResult.scores.contempt = Convert.ToInt32(item["scores"]["contempt"]);
                    faceResult.scores.disgust = Convert.ToInt32(item["scores"]["disgust"]);
                    faceResult.scores.fear = Convert.ToInt32(item["scores"]["fear"]);
                    faceResult.scores.happiness = Convert.ToInt32(item["scores"]["happiness"]);
                    faceResult.scores.neutral = Convert.ToInt32(item["scores"]["neutral"]);
                    faceResult.scores.sadness = Convert.ToInt32(item["scores"]["sadness"]);
                    faceResult.scores.surprise = Convert.ToInt32(item["scores"]["surprise"]);
                }

                faceResults.Add(faceResult);
            }

            return new Result<FaceResult>(faceResults, true, "Success");
        }

        public static string GetServerErrorFromResponse(JObject response)
        {
            if (response["code"].ToString() == "200")
                return null;

            var errorMessage = "Server error " + response["code"];
            if (!String.IsNullOrEmpty(response["message"].ToString()))
                errorMessage += ". " + response["message"];
            return errorMessage;
        }
    }
}
