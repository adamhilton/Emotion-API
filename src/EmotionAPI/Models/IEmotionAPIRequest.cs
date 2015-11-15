
using System.Threading.Tasks;

namespace EmotionAPI
{
    internal interface IEmotionAPIRequest
    {
        /// <summary>
        ///     Subscription key which provides access to this API. 
        /// </summary>
        string OcpApimSubscriptionKey { get; }

        /// <summary>
        ///     A method that posts to the Emotion API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task Post(byte[] bytes); 
    }
}
