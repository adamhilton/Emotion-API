#region
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace EmotionAPI
{
    /// <summary>
    ///     ApiClient class.
    /// </summary>
    internal class ApiClient
    {
        public static string BASE_API_URL { get; } = "https://api.projectoxford.ai/emotion/v1.0/recognize";

        private HttpClient _apiHttpClient;

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
        ///     ApiClient constructor.
        /// </summary>
        /// <param name="httpClient">HttpClient class that is used for posting to API</param>
        public ApiClient(HttpClient httpClient)
        {
            _apiHttpClient = httpClient;
        }

        /// <summary>
        ///     A static asynchronous method that posts to the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ocpApimSubscriptionKey">Ocp Api Subscription Key used to access the API</param>
        /// <param name="bodyContent">Content of the http request</param>
        /// <param name="contentType">Content type of the http request</param>
        /// <param name="urlParams">Url parameters of the http request *NOT YET IMPLEMENTED*</param>
        /// <returns>Returns the API's results.</returns>
        public async Task<Result<T>> GetResponse<T>(string ocpApimSubscriptionKey, HttpContent bodyContent, MediaTypeHeaderValue contentType, string urlParams = "")
        {
            try {
                using (var client = ApiHttpClient)
                {
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, BASE_API_URL + urlParams);

                    // Set Body
                    requestMessage.Content = bodyContent;

                    // Set Headers
                    requestMessage.Content.Headers.ContentType = contentType;
                    requestMessage.Content.Headers.Add("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);

                    // Send request
                    var responseMessage = await client.SendAsync(requestMessage, new CancellationToken());

                    var result = new Result<T>();

                    string jsonMessage;
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    
                    if (responseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        result.Items = (List<T>)JsonConvert.DeserializeObject(jsonMessage, typeof(List<T>));
                        result.Success = true;
                        result.Message = "OK";
                        result.statusCode = 200;
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<Result<T>>(jsonMessage);
                        result.Success = false;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Result<T>(null, false, ex.ToString());
            }
        }
    }
}
