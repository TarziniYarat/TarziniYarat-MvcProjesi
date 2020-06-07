﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Abstract
{
    public interface IProductService:IBaseService<Product>
    {
        List<Product> GetAllByShipper(int? shipperID);
    }
}
