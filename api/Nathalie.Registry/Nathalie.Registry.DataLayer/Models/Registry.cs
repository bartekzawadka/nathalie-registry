using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("registries")]
    public class Registry : DocumentBase
    {
        [BsonDateTimeOptions]
        public DateTime RegistryDate { get; set; }
        
        public List<RegistryEntity> RegistryEntities { get; set; }
    }
}