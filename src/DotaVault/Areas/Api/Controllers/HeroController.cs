using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

using BusinessLogic;
using BusinessLogic.Models;

namespace DotaVault.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/hero")]
    public class HeroController : Controller
    {
        private HeroRepository heroRepository;
        private IConfiguration config;

        public HeroController(
            HeroRepository hr,
            IConfiguration c)
        {
            heroRepository = hr;
            config = c;
        }

        [HttpGet]
        public async Task<IEnumerable<Hero>> Get()
        {
            var heroes = await heroRepository.find();
            return heroes;
        }

        [HttpGet("{id}")]
        public async Task<Hero> Get(string id)
        {
            var hero = await heroRepository.findOneById(id);

            return hero;
        }

        [HttpPost]
        public async Task<Hero> Post([FromBody] Hero hero)
        {
            var h = await heroRepository.save(hero);

            return h;
        }

        [HttpPut("{id}")]
        public async Task<Hero> Put(string id, [FromBody] Hero hero)
        {
            var h = await heroRepository.update(id, hero);

            return h;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
