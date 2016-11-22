using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace DotaVault.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/hero-potrait")]
    public class HeroPotraitController : Controller
    {
        private IConfiguration config;

        public HeroPotraitController(IConfiguration _config)
        {
            config = _config;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient();

            var api = config["Steam:Api:Hero"];
            var key = config["Steam:Key"];

            HttpResponseMessage response = await client.GetAsync($"{api}?key={key}&language=en");
            string c = await response.Content.ReadAsStringAsync();

            JObject j = JObject.Parse(c);
            var k = j.SelectToken("result");
            foreach (var h in k["heroes"])
            {
                string name = (string)h["name"];
                h["key"] = name.Substring(14);
            }
            return k.ToString();
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
