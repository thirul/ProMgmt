using ProMgmt.WebApi.Models;
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
        public IEnumerable<Product> Get()
        {
            return new List<Product>{
                new Product{
                     Name="Geeta",
                     Code ="BG001",
                     Price =12.12,
                     PublishDate=DateTime.Now
                },
                  new Product{
                     Name="Ishavasyam",
                     Code ="BG002",
                     Price =13.12,
                     PublishDate=DateTime.Now
                },
                  new Product{
                     Name="Bramhma Sutra",
                     Code ="BG003",
                     Price =32.12,
                     PublishDate=DateTime.Now
                }
            };
        }
    }
}
