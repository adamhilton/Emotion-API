
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            try
            {
                if (string.IsNullOrEmpty(url))
                    return new Result<FaceResult>(null, false, "Url to image must not be null or empty.");

                var response =
                    await ApiClient.GetResponse<FaceResult>(
                        OcpApimSubscriptionKey,
                        new StringContent("{\"url\":\"" + url + "\"}", Encoding.UTF8, "application/json"),
                        new MediaTypeHeaderValue("application/json"));

                return new Result<FaceResult>(response, true, "SILLY: " + response);

                //return Deserializer.GetResults(response);
            }
            catch (Exception ex)
            {
                return new Result<FaceResult>(null, false, ex.Message);
            }
        }
    }
}
