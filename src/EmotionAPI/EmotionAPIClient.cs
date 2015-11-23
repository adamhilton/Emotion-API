#region
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace EmotionAPI
{
    /// <summary>
    ///     EmotionAPIClient class.
    /// </summary>
    public class EmotionAPIClient : IDisposable
    {
        private HttpClient _apiHttpClient;

        public string OcpApimSubscriptionKey { get; }
        
        public HttpClient ApiHttpClient
        {
            get
            {
                if (_apiHttpClient == null)
                    _apiHttpClient = new HttpClient();
                return _apiHttpClient;
            }
        }

        /// <summary>
        ///     Constructor for the EmotionAPIClient class.
        /// </summary>
        /// <param name="ocpApimSubscriptionKey">Ocp Api Subscription Key used to access the API</param>
        public EmotionAPIClient(string ocpApimSubscriptionKey)
        {
            OcpApimSubscriptionKey = ocpApimSubscriptionKey;
        }

        /// <summary>
        ///     Constructor for the EmotionAPIClient class.
        /// </summary>
        /// <param name="ocpApimSubscriptionKey">Ocp Api Subscription Key used to access the API</param>
        /// <param name="httpClient">Pass in an HttpClient class to replace the one used here</param>
        public EmotionAPIClient(string ocpApimSubscriptionKey, HttpClient httpClient)
        {
            OcpApimSubscriptionKey = ocpApimSubscriptionKey;
            _apiHttpClient = httpClient;
        }

        /// <summary>
        ///     Asynchronous method that posts to the API.
        /// </summary>
        /// <param name="url">Url of the image that shall be analyzed</param>
        /// <returns>Returns the results of the analyzed faces.</returns>
        public async Task<Result<FaceResult>> PostAsync(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return new Result<FaceResult>(null, false, "Url to image must not be null or empty.");

                var response =
                    await new ApiClient(ApiHttpClient).GetResponse<FaceResult>(
                        OcpApimSubscriptionKey,
                        new StringContent("{\"url\":\"" + url + "\"}", Encoding.UTF8, "application/json"),
                        new MediaTypeHeaderValue("application/json"));

                return response;

            }
            catch (Exception ex)
            {
                return new Result<FaceResult>(null, false, ex.Message);
            }
        }

        /// <summary>
        ///     Asynchronous method that posts to the API.
        /// </summary>
        /// <param name="bytes">Bytes of the image that shall be analyzed</param>
        /// <returns>Returns the results of the analyzed faces.</returns>
        public async Task<Result<FaceResult>> PostAsync(byte[] bytes)
        {
            try
            {
                if (bytes == null)
                    return new Result<FaceResult>(null, false, "Image bytes must not be null.");

                var response =
                    await new ApiClient(ApiHttpClient).GetResponse<FaceResult>(
                        OcpApimSubscriptionKey,
                        new ByteArrayContent(bytes),
                        new MediaTypeHeaderValue("application/octet-stream"));

                return response;

            }
            catch (Exception ex)
            {
                return new Result<FaceResult>(null, false, ex.Message);
            }
        }

        public void Dispose()
        {
        }
    }
}
