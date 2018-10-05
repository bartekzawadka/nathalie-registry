﻿using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Nathalie.Registry.DataLayer.Models
{
    [BsonIgnoreExtraElements]
    public class RegistryEntity
    {
        [BsonIgnore]
        public DateTime? RegistryDate { get; set; }

        public Template Template { get; set; }
        
        public bool IsFilledIn { get; set; }

        [BsonIgnoreIfNull]
        public IEnumerable<string> DataIds { get; set; }
        
        [BsonIgnore]
        public IEnumerable<RegistryEntityRow> Data { get; set; }
    }
}
