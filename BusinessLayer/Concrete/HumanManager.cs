using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HumanManager : IHumanService
    {
        private readonly IHumanDal _humanDal;
        private readonly IAgifyService _agifyService;
        public HumanManager(IHumanDal humanDal, IAgifyService agifyService)
        {
            _humanDal = humanDal;
            _agifyService = agifyService;
        }


        public IList<Human> GetAll()
        {
            return _humanDal.GetAll();
        }

        
       
        
        public async Task<Human> GetByName(string name)
        {
            var humanName = _humanDal.GetByName(name);
            
            if (humanName == null)
            {
                var newName = await _agifyService.GetByName(name);
                // StageOfLife eklenecek -enum olarak tasarlanacak
                // AverageAge ekelenecek
                await _humanDal.Create(newName);
                //database kayıt edilecek
               
                return newName;
            }
            else
            {
                //rediste ortalama yaş verisi güncellenecek
            }

            return humanName;
        }


    }
}
