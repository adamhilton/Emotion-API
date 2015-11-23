#region
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientFixture : IDisposable
    {
        public EmotionAPIClient Sut { get; private set; }

        public string OcpApimSubscriptionKey { get; private set; } = "12345";

        public EmotionAPIClientFixture()
        {
            Sut = new EmotionAPIClient(OcpApimSubscriptionKey, new MockHttpClient());
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    public class MockHttpClient : HttpClient
    {
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            var mockResponseMessage = new HttpResponseMessage()
            {
                //Mock content contains json of two face results
                Content = new StringContent("[\n {\n \"faceRectangle\": {\n \"left\": 68,\n \"top\": 97,\n \"width\": 64,\n \"height\": 97\n },\n \"scores\": {\n \"anger\": 0.00300731952,\n \"contempt\": 5.14648448E-08,\n \"disgust\": 9.180124E-06,\n \"fear\": 0.0001912825,\n \"happiness\": 0.9875571,\n \"neutral\": 0.0009861537,\n \"sadness\": 1.889955E-05,\n \"surprise\": 0.008229999\n }\n },\n{\n \"faceRectangle\": {\n \"left\": 68,\n \"top\": 97,\n \"width\": 64,\n \"height\": 97\n },\n \"scores\": {\n \"anger\": 0.00300731952,\n \"contempt\": 5.14648448E-08,\n \"disgust\": 9.180124E-06,\n \"fear\": 0.0001912825,\n \"happiness\": 0.9875571,\n \"neutral\": 0.0009861537,\n \"sadness\": 1.889955E-05,\n \"surprise\": 0.008229999\n }\n }\n]"),
                StatusCode = HttpStatusCode.OK
            };

            return Task.FromResult(mockResponseMessage);
        }
    }
}
