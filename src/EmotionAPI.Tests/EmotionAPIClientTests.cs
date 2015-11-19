using Xunit;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientTests : EmotionAPITestsBase
    {
        [Fact]
        public void Can_Create_EmotionAPIClient_Class()
        {
            var sut = new EmotionAPIClient(mockOcpApimSubscriptionKey);
            
            Assert.NotNull(sut);
        }

        [Fact]
        public void OcpApimSubscriptionKey_Is_Being_Set()
        {
            var sut = new EmotionAPIClient(mockOcpApimSubscriptionKey);

            Assert.NotEmpty(sut.OcpApimSubscriptionKey);
        }
    }
}
