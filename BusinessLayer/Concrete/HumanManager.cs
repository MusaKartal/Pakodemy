using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.Dtos;
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
        private readonly ICacheService _cacheService;

        public HumanManager(IHumanDal humanDal, IAgifyService agifyService, ICacheService cacheService)
        {
            _humanDal = humanDal;
            _agifyService = agifyService;
            _cacheService = cacheService;
        }


        enum EStageOfLife
        {
            infantia = 1,
            pueritia = 2,
            adolescentia = 3,
            iuventus = 4,
            gravitas = 5,
            senectus = 6
        }


        private async Task<int> StageOfLife(int value)
        {
            if (value >= 0 && value <= 6)
            {
                int stageOfLife = (int)EStageOfLife.infantia;
                return stageOfLife;
            }
            if (value >= 7 && value <= 14)
            {
                int stageOfLife = (int)EStageOfLife.pueritia;
                return stageOfLife;
            }
            if (value >= 15 && value <= 28)
            {
                int stageOfLife = (int)EStageOfLife.adolescentia;
                return stageOfLife;
            }
            if (value >= 29 && value <= 50)
            {
                int stageOfLife = (int)EStageOfLife.iuventus;
                return stageOfLife;
            }
            if (value >= 51 && value <= 70)
            {
                int stageOfLife = (int)EStageOfLife.gravitas;
                return stageOfLife;
            }
            if (value > 71)
            {
                int stageOfLife = (int)EStageOfLife.senectus;
                return stageOfLife;
            }
            return value;
        }

        private async Task<string> StageOfLifeChangeString(int stageOfLifeValue)
        {
            var value = await StageOfLife(stageOfLifeValue);
            if (value == 1)
            {
                return "infantia";
            }
            if  (value == 2)
            {
                return "pueritia";
            }
            if (value == 3)
            {
                return "adolescentia";
            }
            if (value == 4)
            {
                return "iuventus";
            }
            if (value == 5)
            {
                return "gravitas";
            }
            if (value == 6)
            {
                return "senectus";
            }


            return "";
        }

        public async Task<List<CacheDto>> CacheList(string key)
        {
            var cache = await _cacheService.GetAsync(key);
            return cache;
        }


        public async Task<HumanDto> GetByAgifyName(string name)
        {
            var newName = await _agifyService.GetByName(name);
            newName.StageOfLife = await StageOfLifeChangeString(newName.Age);
            newName.IsSystemCheck = false;
            Human entitiy = new Human();
            entitiy.Name = newName.Name;
            entitiy.Age = newName.Age;
            entitiy.Count= newName.Count;
            entitiy.AverageAge = newName.AverageAge;
            await Create(entitiy);
            return newName;
        }

        public async Task Create(Human entitiy)
        {
            entitiy.StageOfLife = await StageOfLife(entitiy.Age);
            await _humanDal.Create(entitiy);
        } 

        public async Task<HumanDto> GetByName(string name)
        {          
            var humanValue = _humanDal.GetByName(name);
            if (humanValue != null)
            {
                humanValue.StageOfLife = await StageOfLifeChangeString(humanValue.Age);
                humanValue.IsSystemCheck = true;
            }
           
            return humanValue;
        }

        public async Task<List<ResponsetwoDto>> GetAllResponsetwo()
        {
            var getAll = await _humanDal.GetAllResponsetwo();
            List<ResponsetwoDto> values = new List<ResponsetwoDto>();
            foreach (var responsetwo in getAll)
            {
                responsetwo.StageOfLife = await StageOfLifeChangeString(responsetwo.Age);
                values.Add(responsetwo);
            }
            
            return values;
        }
    }
}
