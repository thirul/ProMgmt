using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using ProMgmt.Entities;
using ProMgmt.Data.Repository;
namespace ProMgmt.Data.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        ICategoryRepositoy categoryRepository;

        [SetUp]
        public void Setup()
        {
            categoryRepository = new CategoryRepositoy();
        }



        [Test]
        public void GetCategoriesTest()
        {
            // drop all docs
            RemoveAllCategoriesTest();

            // insert new category
            InsertCategoryTest();

            // get test 
            var categories = categoryRepository.Get();
          
          Assert.Greater(categories.Count(), 1);
            
        }

        [Test]
        public void InsertCategoryTest()
        {
            var category = BuildCategory();            
            categoryRepository.Insert(category);

        }

        [Test]
        public void UpdateCategoryTest()
        {
            var category = BuildCategory();            
            categoryRepository.Insert(category);

            // update 
            category.Name = category.Name + " modified";
            categoryRepository.Update(category);

        }

        [Test]
        public void UpdateCategoryNameTest()
        {
            var category = BuildCategory();            
            categoryRepository.Insert(category);

            // update 
            category.Name = category.Name + " name only update";
            categoryRepository.UpdateName(category);

        }


        [Test]
        public void RemoveAllCategoriesTest()
        {
            var category = BuildCategory();
            
            categoryRepository.RemoveAll();

        }

        [Test]
        public void RemoveSingleCategoryTest()
        {
            var category = BuildCategory();            
            categoryRepository.Insert(category);

            // remove one            
            categoryRepository.Remove(category);

        }

        private Category BuildCategory()
        {
            return new Category { Id = ObjectId.GenerateNewId(), Name = string.Format("Category :{0}", Guid.NewGuid()) };
        }
      
    }

  
}
