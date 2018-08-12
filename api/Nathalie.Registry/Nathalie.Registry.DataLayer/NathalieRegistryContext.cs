using MongoDB.Driver;

namespace Nathalie.Registry.DataLayer
{
    public class NathalieRegistryContext
    {
        internal IMongoDatabase Database { get; set; }

        public NathalieRegistryContext(string connectionString, string database)
        {
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(database);
        }
    }
}