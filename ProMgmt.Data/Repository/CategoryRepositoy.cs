using MongoDB.Driver;
using ProMgmt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMgmt.Data.Repository
{
    public class CategoryRepositoy: Repository<Category>,ICategoryRepositoy
    {
        public CategoryRepositoy():base("category")
        {
        }

        public void UpdateName(Category category)
        {
            var filter = Builders<Category>.Filter.Eq(s => s.Id, category.Id);
            var update = Builders<Category>.Update.Set(c => c.Name, category.Name);
            var task = DocumentCollection.UpdateOneAsync(filter, update);
            task.Wait();
        }
    }
}
