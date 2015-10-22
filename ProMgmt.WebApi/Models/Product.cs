using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMgmt.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Server: Product Name is required")]
        [MaxLength(10, ErrorMessage="Server validation: product Name max length: 10")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate{ get; set; }
    }
}