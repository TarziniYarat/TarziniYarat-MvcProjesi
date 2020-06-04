using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Combines = new HashSet<Combine>();
        }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int CombineID { get; set; }
        public int BrandID { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public string ProductTitle { get; set; }
        public string BodySize { get; set; }
        public string Color { get; set; }

        //Navigation prop
        public Shipper Shipper { get; set; }
        public ICollection<Combine> Combines { get; set; }
        public Brand Brand { get; set; }
    }
}
