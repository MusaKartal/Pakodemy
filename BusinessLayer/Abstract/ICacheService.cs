using EntitiesLayer;
using EntitiesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICacheService
    {
        Task<List<CacheDto>> GetAsync(string key); 
    }
}
