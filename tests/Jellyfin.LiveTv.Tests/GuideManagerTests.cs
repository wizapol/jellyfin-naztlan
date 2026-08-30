using System;
using Jellyfin.LiveTv.Guide;
using Xunit;

namespace Jellyfin.LiveTv.Tests
{
    public class GuideManagerTests
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("invalid", 0)]
        [InlineData("-2", 0)]
        [InlineData("7", 7)]
        [InlineData("31", 30)]
        public void GuidePastDays_ClampsEnvironmentValue(string? value, int expected)
        {
            const string Variable = "JELLYFIN_GUIDE_PAST_DAYS";
            var previous = Environment.GetEnvironmentVariable(Variable);
            try
            {
                Environment.SetEnvironmentVariable(Variable, value);
                Assert.Equal(expected, GuideManager.GuidePastDays);
            }
            finally
            {
                Environment.SetEnvironmentVariable(Variable, previous);
            }
        }
    }
}
