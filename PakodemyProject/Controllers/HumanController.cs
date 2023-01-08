using BusinessLayer.Abstract;
using EntitiesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime;

namespace PakodemyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IAgifyService _agifyService;
     
        public HumanController(IHumanService humanService, IAgifyService agifyService)
        {

            _humanService = humanService;
            _agifyService = agifyService;
           
        }


        [HttpGet]
        [Route("Agify")]
        public async Task<ActionResult<string>> AgifyGetByName(string name)
        {
            var newName = await _agifyService.GetByName(name);

            return Ok(newName);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Human>> GetByName(string name) 
        {
           var checkName = await _humanService.GetByName(name);
           
            return Ok(checkName);        
        }


       
    }
}
