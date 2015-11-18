
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionAPI
{
    internal class ApiClient
    {
        public static string BASE_API_URL { get; } = "https://api.projectoxford.ai/emotion/v1.0/recognize";

        public static async Task<List<T>> GetResponse<T>(string ocpApimSubscriptionKey, StringContent bodyContent, MediaTypeHeaderValue contentType, string urlParams = "")
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, BASE_API_URL + urlParams);

                // Set Body
                requestMessage.Content = bodyContent;

                // Set Headers
                requestMessage.Content.Headers.ContentType = contentType;
                requestMessage.Content.Headers.Add("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);

                // Send request
                var responseMessage = await client.SendAsync(requestMessage);
                responseMessage.EnsureSuccessStatusCode();

                string jsonMessage;
                using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync())
                {
                    jsonMessage = new StreamReader(responseStream).ReadToEnd();
                }

                var results = (List<T>)JsonConvert.DeserializeObject(jsonMessage, typeof(List<T>));

                return results;
            }
        }
    }
}
