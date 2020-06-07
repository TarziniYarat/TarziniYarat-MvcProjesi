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
            OrderDetails = new HashSet<OrderDetails>();
            Comments = new HashSet<Comment>();
        }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int? ShipperID { get; set; }
        public string ProductName { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public string ProductTitle { get; set; }
        public Size BodySize { get; set; }
        public Color Color { get; set; }

        //Navigation prop
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Shipper Shipper { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public enum Color
    {
        Kırmızı,
        Sarı,
        Siyah,
        Kahverengi,
        Mavi,
        Mor,
        Yeşil,
        Turuncu
    }

    public enum Size
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL
    }
}
