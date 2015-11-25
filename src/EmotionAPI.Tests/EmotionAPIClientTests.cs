using Xunit;
using Xunit.Abstractions;

namespace EmotionAPI.Tests
{
    public class EmotionAPIClientTests : EmotionAPITestsBase, IClassFixture<EmotionAPIClientFixture>
    {
        private readonly EmotionAPIClientFixture _fixture;

        public EmotionAPIClientTests(ITestOutputHelper helper, EmotionAPIClientFixture fixture)
            :base(helper)
        {
            _fixture = fixture;
        }
        
        [Fact]
        [Trait("Category", "Null Checking")]
        public void ShouldNotBeNullEmotionAPIClient()
        {
            _testOutput.WriteLine("Executing ShouldNotBeNullEmotionAPIClient");
            Assert.NotNull(_fixture);
        }
        
        [Fact]
        [Trait("Category", "Null Checking")]
        public void ShouldNotBeNullOcpApimSubscriptionKey()
        {
            _testOutput.WriteLine("Executing ShouldNotBeNullOcpApimSubscriptionKey");
            Assert.NotNull(_fixture.OcpApimSubscriptionKey);
        }
  
        [Fact]
        [Trait("Category", "Value Checking")]
        public async void ShouldPostAsyncAndReturnFaceResultItems()
        {
            _testOutput.WriteLine("Executing ShouldPostAsyncAndReturnCorrectResults");
            var result = await _fixture.Sut.PostAsync("cleverUrl");

            //Correct number of face results is 2
            Assert.NotEqual(1, result.Items.Count);
            Assert.Equal(2, result.Items.Count);
            Assert.NotEqual(3, result.Items.Count);
        }
    }
}
