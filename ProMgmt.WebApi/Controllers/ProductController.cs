using ProMgmt.WebApi.Models;
using ProMgmt.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 

namespace ProMgmt.WebApi.Controllers
{
   [System.Web.Http.Cors.EnableCors("http://localhost:53784", "*", "*")]
    public class ProductController : ApiController
    {
       ProductRepository productRepository;

       public ProductController()
       {
           productRepository = new ProductRepository();
       }

       public IEnumerable<Product> Get()
       {
           return productRepository.Retrieve();
       }

       public IEnumerable<Product> Get(string search)
       {
           if (string.IsNullOrEmpty(search))
               return Get();

           return productRepository.Retrieve().Where(x => x.Code.Contains(search));
       }

       public Product Get(int id)
       {
           return productRepository.Retrieve().Where(x => x.Id == id).SingleOrDefault();
       }

       public void Post([FromBody] Product product)
       {
           productRepository.Save(product);
       }
       public void Put(int id, [FromBody] Product product)
       {
           productRepository.Save(id, product);
       }


      
    }
}
