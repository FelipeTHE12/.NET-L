using System;
using API_MONGO.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace API_MONGO.Data
{

    public class MongoDB
    {

        public IMongoDatabase DB {get;}

        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }

            catch(Exception ex)
            {
                throw new MongoException("Connection Failed!", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
            {
                BsonClassMap.RegisterClassMap<Infected>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}