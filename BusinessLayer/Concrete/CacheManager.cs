using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.Dtos;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CacheManager : ICacheService
    {
        private readonly IHumanDal _humanDal;
        private readonly IDistributedCache _distributedCache;
        
        public CacheManager(IHumanDal humanDal,IDistributedCache distributedCache)
        {      
            _humanDal= humanDal;
            _distributedCache = distributedCache;
          
        }
        public async Task<List<CacheDto>> GetAsync(string key)
        {
            var cacheKey = key;
            string serializedHumanList;
            var humanList = new List<CacheDto>();
            
            var redisHumanList = await _distributedCache.GetAsync(cacheKey);
            if (redisHumanList != null)
            {
                serializedHumanList = Encoding.UTF8.GetString(redisHumanList);
                humanList = JsonConvert.DeserializeObject<List<CacheDto>>(serializedHumanList);
            }
            else
            {
                humanList = await _humanDal.GetAll();
                // yaş ortalaması çekilecek
                serializedHumanList = JsonConvert.SerializeObject(humanList);
                redisHumanList = Encoding.UTF8.GetBytes(serializedHumanList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisHumanList, options);
                
            }
            return humanList;
        }
    }
}
