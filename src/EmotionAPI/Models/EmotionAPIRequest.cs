using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmotionAPI
{
    internal class EmotionAPIRequest : IEmotionAPIRequest
    {
        public string Uri { get; } = "https://api.projectoxford.ai/emotion/v1.0/recognize&";

        public string OcpApimSubscriptionKey { get; }

        public EmotionAPIRequest(string ocpApimSubscriptionKey)
        {
            this.OcpApimSubscriptionKey = ocpApimSubscriptionKey;
        }

        public async Task Post(byte[] bytes)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", OcpApimSubscriptionKey);

            HttpResponseMessage response;
            
            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(Uri, content);
            }
        }
        
    }
}
