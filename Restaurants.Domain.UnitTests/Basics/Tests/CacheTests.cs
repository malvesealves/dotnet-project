using Restaurants.Domain.UnitTests.Basics.Units;

namespace Restaurants.Domain.UnitTests.Basics.Tests
{
    public class CacheTests
    {
        [Fact]
        public void Contains_CachesItemWithinTimeSpan()
        {
            Cache cache = new(TimeSpan.FromDays(1));
            cache.Add(new("url", "content", DateTime.Now));

            bool contains = cache.Contains("url");

            Assert.True(contains);
        }

        [Fact]
        public void Contains_ReturnsFalse_WhenItemOutsideTimeSpan()
        {
            Cache cache = new(TimeSpan.FromDays(1));
            cache.Add(new("url", "content", DateTime.Now.AddDays(-2)));

            bool contains = cache.Contains("url");

            Assert.False(contains);
        }

        [Fact]
        public void Contains_ReturnsFalse_WhenDoesntContainsItem()
        {
            Cache cache = new(TimeSpan.FromDays(1));

            bool contains = cache.Contains("url");

            Assert.False(contains);
        }
    }
}
