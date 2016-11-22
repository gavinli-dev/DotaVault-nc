using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BusinessLogic
{
    public class HeroRepository
    {
        public IMongoDatabase Db { get; set; }
        public IMongoCollection<Hero> DbContext;

        public HeroRepository(MongoDbService dbs)
        {
            Db = dbs.Connection;
            DbContext = Db.GetCollection<Hero>("hero");
        }

        public async Task<List<Hero>> find(int page = 0, int pageSize = 10)
        {
            return await DbContext.Find<Hero>(new BsonDocument()).ToListAsync();
        }

        public async Task<Hero> findOneById(string id)
        {
            var filter = Builders<Hero>.Filter.Eq("_id", ObjectId.Parse(id));

            var heroCursor = await DbContext.Find(filter).ToListAsync();
            return heroCursor.FirstOrDefault();
        }

        public async Task<Hero> save(Hero h)
        {
            await DbContext.InsertOneAsync(h);
            
            return h;
        }

        public async Task<Hero> update(string id, Hero h)
        {
            var filter = Builders<Hero>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await DbContext.ReplaceOneAsync(filter, h);
            return h;
        }
    }
}
