using System;
using System.Collections.Generic;
using System.Linq;
using Dotnetcore_Webapi_MongoDB.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Dotnetcore_Webapi_MongoDB.Model;

namespace Dotnetcore_Webapi_MongoDB.Entities {
    public class ObjectContext {
       
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;

        public ObjectContext (IOptions<DbSettings> settings) {
            
            Configuration = settings.Value.IConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection ("MongoDB:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection ("MongoDB:Database").Value;
            var client = new MongoClient (settings.Value.ConnectionString);
            if (client != null) {
                _database = client.GetDatabase (settings.Value.Database);
            }
        }

        public IMongoCollection<Subscriber> Subscribers {
            get {
                return _database.GetCollection<Subscriber> ("Subscriber");
            }
        }

        // public MongoCollection<T> GetCollection<T>()
        // {
        //     return _database.GetCollection<T>(typeof(T).Name);
        // }

    }

}