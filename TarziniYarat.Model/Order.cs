using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Order:BaseEntity
    {
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        //public int ProductID { get; set; }
        public decimal TotalAmount { get; set; }

        //Navigation prop
    }
}
