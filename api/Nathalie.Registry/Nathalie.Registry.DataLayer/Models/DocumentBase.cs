using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    public abstract class DocumentBase
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        protected DocumentBase()
        {
            if (!Attribute.IsDefined(GetType(), typeof(MongoCollectionAttribute)))
            {
                throw new TypeAccessException(
                    $"{nameof(DocumentBase)} derived types have to have {nameof(MongoCollectionAttribute)} defined");
            }
        }
    }
}