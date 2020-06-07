using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Concrete
{
    public class ProductService : IProductService
    {
        IProductDAL _productDAL;

        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public bool Add(Product entity)
        {
            return _productDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Product product = _productDAL.Get(a => a.ProductID == entityID);
            return _productDAL.Delete(product) > 0;
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll().ToList();
        }

        public List<Product> GetAllByShipper(int? shipperID)
        {
            return _productDAL.GetAll(a => a.ShipperID == shipperID).ToList();
        }

        public Product GetByID(int entityID)
        {
            return _productDAL.Get(a => a.ProductID == entityID);
        }

        public bool Update(Product entity)
        {
            return _productDAL.Update(entity) > 0;
        }
    }
}
