using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Models;
using MongoDB.Driver;

namespace BusinessLogic
{
    public class AbilityRepository
    {
        public IMongoDatabase Db { get; set; }
        public IMongoCollection<Ability> DbContext;

        public AbilityRepository(MongoDbService dbs)
        {
            Db = dbs.Connection;
            DbContext = Db.GetCollection<Ability>("ability");
        }

        public async Task<List<Ability>> getByHeroKey(string heroKey)
        {
            var abilityList = await DbContext.Find(a => a.HeroKey == heroKey).ToListAsync();
            return abilityList;
        }

        public async Task<Ability> save(Ability a)
        {
            await DbContext.InsertOneAsync(a);
            return a;
        }
    }
}
