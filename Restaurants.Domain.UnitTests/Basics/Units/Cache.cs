namespace Restaurants.Domain.UnitTests.Basics.Units
{
    public class Cache(TimeSpan cacheTime)
    {
        public record Item(string Url, string Content, DateTime LastCollected);

        private readonly TimeSpan _cacheTime = cacheTime;
        private readonly Dictionary<string, Item> _cache = new();

        public bool Contains(string url)
        {
            if (_cache.TryGetValue(url, out Item? item))
            {
                return DateTime.UtcNow.Subtract(item.LastCollected) < _cacheTime;
            }

            return false;
        }

        public void Add(Item item) => _cache.Add(item.Url, item);
    }
}
