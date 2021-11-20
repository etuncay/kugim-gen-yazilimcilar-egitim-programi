using Haber.Core.Interfaces.Services;
using Haber.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Services
{
    public class CacheService : ICacheService
    {
        public long CacheOffsetTime => 10000000000;
        private readonly HaberDbContext _haberDbContext;

        public CacheService(HaberDbContext haberDbContext)
        {
            _haberDbContext = haberDbContext;
        }

        public bool Add(string key, object obj)
        {
            if (Has(key))
            {
                Remove(key);
            }

            var entity = new CacheEntity()
            {
                Key = key,
                Value = JsonConvert.SerializeObject(obj),
                ExpirationTime = DateTime.Now.Ticks+ CacheOffsetTime,
                OlusturulmaTarihi = DateTime.Now
            };
            _haberDbContext.Add(entity);
            return _haberDbContext.SaveChanges() > 0 ? true : false;
        }

        public bool AddOrUpdate(string key, object obj)
        {
            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key && q.ExpirationTime > DateTime.Now.Ticks);

            if (query != null )
            {

                query.Value = JsonConvert.SerializeObject(obj);
                query.ExpirationTime = DateTime.Now.Ticks + CacheOffsetTime;

                return _haberDbContext.SaveChanges() > 0 ? true : false;
            }
            else
            {
                Remove(key);
                return Add(key, obj);
            }
        }

        public T Get<T>(string key) where T : class
        {
            var nowTicks =  DateTime.Now.Ticks;

            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key && q.ExpirationTime > nowTicks);

            if (query != null)
            {
                return JsonConvert.DeserializeObject<T>(query.Value);
            }

            return default;
        }

        public bool Has(string key)
        {
            var nowTicks = DateTime.Now.Ticks;


            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key);



            if (query!=null && query.ExpirationTime > nowTicks)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public bool Remove(string key)
        {
            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key);

            if (query != null)
            {
                _haberDbContext.Cache.Remove(query);
                return _haberDbContext.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return true;
            }

        }
    }
}
