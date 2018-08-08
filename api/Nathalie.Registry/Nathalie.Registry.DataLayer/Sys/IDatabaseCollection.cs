using MongoDB.Bson.Serialization.Attributes;

namespace Nathalie.Registry.DataLayer.Sys
{
    public interface IDatabaseCollection
    {
        [BsonId]
        long Id { get; set; }
    }
}