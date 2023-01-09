using EntitiesLayer;
using EntitiesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHumanService
    {

        Task<HumanDto> GetByName(string name);
        Task<List<CacheDto>> CacheList(string key);
        Task<HumanDto> GetByAgifyName(string name);
        Task Create(Human entitiy);
        Task<List<ResponsetwoDto>> GetAllResponsetwo();
    }
}
