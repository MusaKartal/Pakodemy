using Azure;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AgifyManager : IAgifyService
    {
       
        public async Task<Human> GetByName(string name)
        {
            var url = "https://api.agify.io/?name="+name;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
           

            return await response.Content.ReadFromJsonAsync<Human>() ;
        }

       
    }
}
