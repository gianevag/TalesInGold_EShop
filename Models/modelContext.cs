using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TalesInGold_EShop.Models;

namespace TalesInGold_EShop.Models
{
    public class modelContext
    {
        private readonly IMongoDatabase _database = null;

        public modelContext(IOptions<Setting> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Jewelry> JewelriesLinq
        {
            get
            {
                return _database.GetCollection<Jewelry>("tig_jewelries");
            }

        }
    }
}
