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
        public long CacheOffsetTime => 120;
        private readonly HaberDbContext _haberDbContext;
        private long nowTicks=0;
        public CacheService(HaberDbContext haberDbContext)
        {
            _haberDbContext = haberDbContext;
            nowTicks = DateTime.Now.Ticks;
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
                ExpirationTime = DateTime.Now.AddMinutes(CacheOffsetTime).Ticks,
                OlusturulmaTarihi = DateTime.Now
            };
            _haberDbContext.Add(entity);
            return _haberDbContext.SaveChanges() > 0 ? true : false;
        }

        public bool AddOrUpdate(string key, object obj)
        {
            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key);

            if (query != null )
            {

                if(query.ExpirationTime> nowTicks)
                {
                    query.Value = JsonConvert.SerializeObject(obj);
                    query.ExpirationTime = DateTime.Now.AddMinutes(CacheOffsetTime).Ticks;
                    return _haberDbContext.SaveChanges() > 0 ? true : false;
                }
                else
                {
                    Remove(key);
                }
            }

            return Add(key, obj);

        }

        public T Get<T>(string key) where T : class
        {

            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key);

            if (query != null)
            {
                if(query.ExpirationTime> nowTicks)
                {
                    return JsonConvert.DeserializeObject<T>(query.Value);
                }
                else
                {
                    Remove(key);
                }

            }

            return default;
        }

        public bool Has(string key)
        {


            var query = _haberDbContext.Cache.FirstOrDefault(q => q.Key == key);



            if (query!=null)
            {
                if(query.ExpirationTime > nowTicks)
                {
                    return true;

                }
                else {
                    Remove(key);
                }

            }
            return false;

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
