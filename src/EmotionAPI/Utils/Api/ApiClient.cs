
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionAPI
{
    internal class ApiClient
    {
        public static string BASE_API_URL{ get; } = "https://api.projectoxford.ai/emotion/v1.0/recognize";

        public static async Task<JObject> GetResponse(string ocpApimSubscriptionKey, MediaTypeHeaderValue contentType, string urlParams = "")
        {
            using (var client = new HttpClient())
            {
                Trace.WriteLine("<HTTP - GET - " + BASE_API_URL + urlParams + " >");

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, BASE_API_URL + urlParams);
                requestMessage.Content.Headers.ContentType = contentType;
                requestMessage.Content.Headers.Add("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);

                var response = await client.SendAsync(requestMessage);
                Trace.WriteLine("Response: " + response);

                return JObject.Parse(response.Content.ToString()); ;
            }
        }
    }
}
