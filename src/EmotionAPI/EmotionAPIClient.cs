
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionAPI
{
    public class EmotionAPIClient
    {
        public string OcpApimSubscriptionKey { get; }

        public EmotionAPIClient(string ocpApimSubscriptionKey)
        {
            OcpApimSubscriptionKey = ocpApimSubscriptionKey;
        }
        
        public async Task<Result<FaceResult>> Post(string url) 
        {
            try {
                if (string.IsNullOrEmpty(url))
                    return new Result<FaceResult>(null, false, "Url to image must not be null or empty.");

                var response =
                    await ApiClient.GetResponse(OcpApimSubscriptionKey, new MediaTypeHeaderValue("application/json"));

                return Deserializer.GetResults(response);
            }
            catch(Exception ex)
            {
                return new Result<FaceResult>(null, false, ex.Message);
            }
        }
    }
}
