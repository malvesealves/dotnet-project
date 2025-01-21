using System.Security.Cryptography;
using System.Text;

namespace Restaurants.Domain.UnitTests.Basics.Units
{
    public class PropertyHash
    {
        public virtual string Hash<T>(T input, params Func<T, string>[] selectors)
        {
            StringBuilder builder = new();
            foreach (Func<T, string> selector in selectors)
            {
                builder.Append(selector(input));
            }

            return builder.ToString();
        }
    }

    public class AlgorithmPropertyHash : PropertyHash, IDisposable
    {
        private readonly HashAlgorithm _algorithm;

        public AlgorithmPropertyHash(string algorithm)
        {
            _algorithm = HashAlgorithm.Create(algorithm) ?? throw new ArgumentException(algorithm);
        }

        public override string Hash<T>(T input, params Func<T, string>[] selectors)
        {
            string seed = base.Hash(input, selectors);
            byte[] seedBytes = Encoding.UTF8.GetBytes(seed);
            byte[] hashBytes = _algorithm.ComputeHash(seedBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public void Dispose() => _algorithm.Dispose();
    }
}
