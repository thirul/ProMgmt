using ProMgmt.WebApi.Models;
using ProMgmt.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
 

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

       [ResponseType(typeof(Product))]
       public IHttpActionResult Get()
       {
           try{
           
            return Ok( productRepository.Retrieve());
           }
           catch(Exception ex)
           {
               return InternalServerError();
           }
       }

       [ResponseType(typeof(Product))]
       public IHttpActionResult Get(string search)
       {
           try{
           if (string.IsNullOrEmpty(search))
               return Get();

           return Ok(productRepository.Retrieve().Where(x => x.Code.Contains(search)));


              }
           catch(Exception ex)
           {
               return InternalServerError();
           }
       }

       [ResponseType(typeof(Product))]
       public IHttpActionResult Get(int id)
       {
           try{
           var product= productRepository.Retrieve().Where(x => x.Id == id).SingleOrDefault();

           if(product==null)
           {
               return NotFound();
           }
        
           return Ok(product);

              }
           catch(Exception ex)
           {
               return InternalServerError();
           }
       }

       [ResponseType(typeof(Product))]
       public IHttpActionResult Post([FromBody] Product product)
       {
           try{
           // arguments empty
           if(product==null)
           {
               return BadRequest("Product cannot be null");
           }

            // server side validations
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var newProduct = productRepository.Save(product);
           // save failed
           if(newProduct==null)
           {
               return Conflict();
           }

           // success
           return Created<Product>(Request.RequestUri + newProduct.Id.ToString(), newProduct);


              }
           catch(Exception ex)
           {
               return InternalServerError();
           }

       }
       
       
       public IHttpActionResult Put(int id, [FromBody] Product product)
       {       
           try{
           // arguments empty
           if (product == null)
           {
               return BadRequest("Product cannot be null");
           }
           // server side validations
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }

               var updateProduct = productRepository.Save(id, product);
               // save failed
               if (updateProduct == null)
               {
                   return NotFound();
               }

               return Ok();
              }
           catch(Exception ex)
           {
               return InternalServerError();
           }

       }
      
    }
}
