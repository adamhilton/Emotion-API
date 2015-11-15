using Xunit;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientTests
    {

        [Fact]
        public void EmotionAPIClientControllerTest()
        {
            var controller = new EmotionAPIClient("12345");
            Assert.NotEmpty(controller.OcpApimSubscriptionKey);
        }
    }
}
