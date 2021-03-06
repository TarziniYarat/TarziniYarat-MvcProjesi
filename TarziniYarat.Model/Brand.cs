﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        public int BrandID { get; set; }
        public string CompanyName { get; set; }

        //Navigation prop
        public ICollection<Product> Products { get; set; }
    }
}
