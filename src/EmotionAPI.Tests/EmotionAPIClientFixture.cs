using System;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientFixture : IDisposable
    {
        public EmotionAPIClient Sut { get; private set; }

        public string OcpApimSubscriptionKey { get; private set; } = "12345";


        public EmotionAPIClientFixture()
        {
            Sut = new EmotionAPIClient(OcpApimSubscriptionKey);
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }
}
