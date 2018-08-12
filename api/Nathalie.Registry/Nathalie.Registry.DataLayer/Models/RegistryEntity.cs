using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("registryEntities")]
    public class RegistryEntity : DocumentBase
    {
        public string Name { get; set; }

        [BsonDateTimeOptions]
        public DateTime RegistryDate { get; set; }

        public IEnumerable<RegistryEntityRow> Data { get; set; }
    }
}
