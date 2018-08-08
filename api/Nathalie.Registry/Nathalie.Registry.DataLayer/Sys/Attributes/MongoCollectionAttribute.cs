using System;

namespace Nathalie.Registry.DataLayer.Sys.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MongoCollectionAttribute : Attribute
    {
        public string CollectionName { get; }
        
        public MongoCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}