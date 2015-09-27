﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProMgmt.WebApi.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate{ get; set; }
    }
}