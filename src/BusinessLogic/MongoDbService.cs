using MongoDB.Driver;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic
{
    public class MongoDbService
    {
        private IConfiguration config;

        public MongoDbService(IConfiguration _config)
        {
            config = _config;
        }

        public IMongoDatabase Connection
        {
            get
            {
                string connectionString = @config["MongoConnection:AzureConnection"];
                MongoClientSettings settings =
                    MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                settings.SslSettings =
                    new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                var db = mongoClient.GetDatabase("dota-vault");
                
                return db;
            }
        }
    }
}
