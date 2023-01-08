using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHumanDal 
    {
        Human GetByName(string name);
        Task Create(Human entity);
        IList<Human> GetAll();
    }
}
