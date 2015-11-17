using Xunit;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientTests : EmotionAPITestsBase
    {
        [Fact]
        public void Can_Create_EmotionAPIClient_Controller()
        {
            var controller = new EmotionAPIClient(mockOcpApimSubscriptionKey);
            
            Assert.NotNull(controller);
            Assert.NotEmpty(controller.OcpApimSubscriptionKey);
        }
        
    }
}
