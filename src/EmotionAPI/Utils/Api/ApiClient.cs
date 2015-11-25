#region
using Microsoft.AspNet.WebUtilities;
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
                    _apiHttpClient = (new HttpClient(new HttpClientHandler()));
                return _apiHttpClient;
            }
        }

        public List<FaceRectangle> FaceRectangles { get; set; }

        /// <summary>
        ///     ApiClient constructor.
        /// </summary>
        /// <param name="httpClient">HttpClient class that is used for posting to API</param>
        public ApiClient(HttpClient httpClient)
        {
            _apiHttpClient = httpClient;
        }

        /// <summary>
        ///     ApiClient constructor.
        /// </summary>
        /// <param name="httpClient">HttpClient class that is used for posting to API</param>
        /// <param name="faceRectangles">Api will only search for face in specified face rectangles provided</param>
        public ApiClient(HttpClient httpClient, List<FaceRectangle> faceRectangles = null)
        {
            _apiHttpClient = httpClient;
            FaceRectangles = faceRectangles;
        }

        /// <summary>
        ///     A static asynchronous method that posts to the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ocpApimSubscriptionKey">Ocp Api Subscription Key used to access the API</param>
        /// <param name="httpContent">Content of the http request</param>
        /// <param name="contentType">Content type of the http request</param>
        /// <returns>Returns the API's results.</returns>
        public async Task<Result<T>> GetResponse<T>(string ocpApimSubscriptionKey, HttpContent httpContent, MediaTypeHeaderValue contentType)
        {
            try
            {
                using (var client = ApiHttpClient)
                {
                    // Set request url with optional faceRectangles parameter
                    var parametersToAdd = new Dictionary<string, string> { { "faceRectangles", ConvertFaceRectangleListToString(FaceRectangles) } };
                    var requestUrl = QueryHelpers.AddQueryString(BASE_API_URL, parametersToAdd);

                    // Set Headers
                    httpContent.Headers.ContentType = contentType;
                    httpContent.Headers.Add("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);

                    // Send request
                    HttpResponseMessage responseMessage = await client.PostAsync(requestUrl, httpContent);

                    // Convert response to result
                    Result<T> result = await ConvertResponseMessageToResult<T>(responseMessage);
                    
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Result<T>(null, false, ex.ToString());
            }
        }

        /// <summary>
        ///     Converts the response message from the API call to a result object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseMessage">Response message from the API</param>
        /// <returns>Result of API call</returns>
        /// <seealso cref="EmotionAPI.Result{T}"/>
        private async Task<Result<T>> ConvertResponseMessageToResult<T>(HttpResponseMessage responseMessage)
        {
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

        /// <summary>
        ///     Converts a list of face rectangles into the correct string format for the API query.
        /// </summary>
        /// <param name="faceRectangles">List of face rectangle demensions.</param>
        /// <returns>A string with comma delimited face demension points and semi-colon delimited demension sets.</returns>
        private string ConvertFaceRectangleListToString(List<FaceRectangle> faceRectangles)
        {
            if (faceRectangles == null)
                return String.Empty;

            string faceRectanglesString = String.Empty;
            foreach (var item in faceRectangles)
            {
                faceRectanglesString += $"{item.Left},{item.Top},{item.Width},{item.Height}";
                if (faceRectangles.IndexOf(item) != faceRectangles.Count - 1)
                    faceRectanglesString += ";";
            }
            return faceRectanglesString;
        }
    }
}
