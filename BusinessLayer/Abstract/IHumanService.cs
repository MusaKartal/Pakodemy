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

        Task<Human> GetByName(string name);
        Task<List<HumanListDto>> CacheList(string key);
        Task<Human> GetByAgifyName(string name);
        Task Create(Human entitiy);
    }
}
