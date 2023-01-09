using BusinessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections;
using System.Runtime;
using System.Text;

namespace PakodemyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;               
        public HumanController(IHumanService humanService)    
        {
            _humanService = humanService;                            
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<HumanDto>> AllProject(string name) 
        {
           var checkName = await _humanService.GetByName(name);
            if (checkName == null)
            {
                checkName = await _humanService.GetByAgifyName(name);
                
            }
            else
            {
                await _humanService.CacheList(name);              
               
            }

            return Ok(checkName);        
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponsetwoDto>>> GetAll()
        {
           var humanList = await _humanService.GetAllResponsetwo();

            return Ok(humanList);
        }
     
    }
}
