using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMgmt.Data
{
   public  class MongoContext
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;


        public MongoContext ()
        {
            String uri = "mongodb://localhost:27017/test";
            _client = new MongoClient(uri);
            _database = _client.GetDatabase("test");
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }



    }
}
