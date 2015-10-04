using MongoDB.Bson;
using MongoDB.Driver;
using ProMgmt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMgmt.Data.Repository
{
    public class Repository<T>:IRepository<T>
        where T : EntityBase
    {
        IMongoDatabase _database = null;
        IMongoCollection<T> _collections = null;
        string _docuemntName = string.Empty;

        public IMongoCollection<T> DocumentCollection {
            get {
                    return _collections;
                } 
        }


        public Repository(string documentName)
        {
            _docuemntName = documentName;
            var context = new MongoContext();
            _database = context.GetDatabase();
            _collections = GetCollections();
        }
 

        public IEnumerable<T> Get()
        { 
            var filter = new BsonDocument();
            var task = _collections.Find(filter).ToListAsync();
            task.Wait();
            return task.Result;
        }

        public void Insert(T entity)
        {
            var task = _collections.InsertOneAsync(entity);
            task.Wait();
        }

        public void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);            
            var task =   _collections.ReplaceOneAsync(filter, entity);
            task.Wait();
        }

        public void RemoveAll()
        {            
            var task = _collections.DeleteManyAsync(new BsonDocument());
            task.Wait();
        }

        public void Remove(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
            var task = _collections.DeleteOneAsync(filter);
            task.Wait();
        }


        private IMongoCollection<T> GetCollections()
        {
            if (string.IsNullOrEmpty(_docuemntName))
            {
                throw new ArgumentException("document name is not supplied");
            }

            return _database.GetCollection<T>(_docuemntName);

           
        }
    }
}
