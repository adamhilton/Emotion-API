
using System;
using Xunit.Abstractions;

namespace EmotionAPI.Tests
{
    public class EmotionAPITestsBase 
    {
        protected readonly ITestOutputHelper _testOutput;

        public EmotionAPITestsBase(ITestOutputHelper helper)
        {
            _testOutput = helper;
        }
    }
}
