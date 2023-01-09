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


        private int StageOfLife(int value)
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

        public async Task<List<HumanListDto>> CacheList(string key)
        {
            var cache = await _cacheService.GetAsync(key);
            return cache;
        }


        public async Task<Human> GetByAgifyName(string name)
        {
            var newName = await _agifyService.GetByName(name);         
                            
            return newName;
        }

        public async Task Create(Human entitiy)
        {
            entitiy.StageOfLife = StageOfLife(entitiy.Age);
            await _humanDal.Create(entitiy);
        } 

        public async Task<Human> GetByName(string name)
        {
            var humanValue = _humanDal.GetByName(name);                  
            return humanValue;
        }


    }
}
