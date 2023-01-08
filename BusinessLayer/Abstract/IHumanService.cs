using EntitiesLayer;
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
        
        IList<Human> GetAll();
    }
}
