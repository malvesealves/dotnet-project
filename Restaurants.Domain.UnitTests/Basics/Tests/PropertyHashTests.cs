using Restaurants.Domain.UnitTests.Basics.Units;

namespace Restaurants.Domain.UnitTests.Basics.Tests
{
    public class PropertyHashTests
    {
        [Fact]
        public void PropertyHash_ConcatenatesSelectedFieldsInOrder()
        {
            PropertyHash hasher = new();
            Cache.Item item = new("url", "content", DateTime.Now);

            string hash1 = hasher.Hash(item, i => i.Url);
            string hash2 = hasher.Hash(item, i => i.Url, i => i.Content);

            Assert.Equal("url", hash1);
            Assert.Equal("urlcontent", hash2);
        }

        [Fact]
        public void AlgorithmPropertyHash_AppliesHashingAlgorithmToSeed()
        {
            AlgorithmPropertyHash hasher = new("sha256");
            Cache.Item item = new("url", "content", DateTime.Now);

            string hash = hasher.Hash(item, i => i.Url, i => i.Content);

            Assert.Equal("9FyLxk+9z73XO8xhZ15emMaK+oa8aDg6LWiY6y40KyQ=", hash);
        }
    }
}
