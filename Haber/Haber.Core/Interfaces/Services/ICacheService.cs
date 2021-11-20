
namespace Haber.Core.Interfaces.Services
{
    public interface ICacheService
    {
        long CacheOffsetTime { get; }

        bool Has(string key);
        T Get<T>(string key) where T : class;
        bool Add(string key, object obj);
        bool AddOrUpdate(string key, object obj);
        bool Remove(string key);
    }
}
