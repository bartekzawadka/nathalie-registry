using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    public class Registry : DocumentBase
    {       
        [BsonDateTimeOptions]
        public DateTime RegistryDate { get; set; }

        public IEnumerable<RegistryRow> Data { get; set; }
    }
}