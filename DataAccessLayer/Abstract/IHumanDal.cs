using EntitiesLayer;
using EntitiesLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHumanDal 
    {
        HumanDto GetByName(string name);   
        Human GetByAge(int age);
        Task Create(Human entity);
        Task<List<CacheDto>> GetAll();
        Task<List<ResponsetwoDto>> GetAllResponsetwo();
    }
}
