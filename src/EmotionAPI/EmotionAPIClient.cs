
using System;
using System.Threading.Tasks;

namespace EmotionAPI
{
    /// <summary>
    ///     EmotionAPIClient class.
    /// </summary>
    /// <seealso cref="EmotionAPI.IEmotionAPIClient"/>
    public class EmotionAPIClient : IEmotionAPIClient
    {
        /// <summary>
        ///     Gets or sets OcpApimSubscriptionKey.
        /// </summary>
        /// <seealso cref="EmotionAPI.IEmotionAPIClient.OcpApimSubscriptionKey"/>
        public string OcpApimSubscriptionKey { get; set; }

        /// <summary>
        ///     Initializes a new instance of the EmotionAPI.EmotionAPIClient class.
        /// </summary>
        /// <param name="ocpApimSubscriptionKey"></param>
        public EmotionAPIClient(string ocpApimSubscriptionKey)
        {
            this.OcpApimSubscriptionKey = ocpApimSubscriptionKey;
        }

        public async Task Post (byte[] bytes)
        {
            var request = new EmotionAPIRequest(OcpApimSubscriptionKey);
            await request.Post(bytes);
        }
    }
}
