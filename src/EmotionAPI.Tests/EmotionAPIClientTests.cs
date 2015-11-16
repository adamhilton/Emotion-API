using Xunit;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientTests : EmotionAPITestsBase
    {
        [Fact]
        public void EmotionAPIClientControllerTest()
        {
            var controller = new EmotionAPIClient(mockOcpApimSubscriptionKey);
            Assert.NotNull(controller);
            Assert.NotEmpty(controller.OcpApimSubscriptionKey);
        }
    }
}
