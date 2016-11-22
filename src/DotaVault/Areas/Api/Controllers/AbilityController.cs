using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BusinessLogic;
using BusinessLogic.Models;

namespace DotaVault.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/ability")]
    public class AbilityController : Controller
    {
        private AbilityRepository abilityRepository;

        public AbilityController(AbilityRepository ap)
        {
            abilityRepository = ap;
        }

        [HttpGet]
        public async Task<IEnumerable<Ability>> Get([FromQuery]string hero_key)
        {
            List<Ability> abilityList = new List<Ability>();

            abilityList = await abilityRepository.getByHeroKey(hero_key);

            return abilityList;
            
        }
        
        [HttpGet("hero/{key}")]
        public async Task<IEnumerable<Ability>> GetByHeroKey(string heroKey)
        {
            List<Ability> abilityList = new List<Ability>();

            abilityList = await abilityRepository.getByHeroKey(heroKey);

            return abilityList;
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
