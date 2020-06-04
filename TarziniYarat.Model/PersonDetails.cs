using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class PersonDetails:BaseEntity
    {
        public int PersonDetailsID { get; set; }
        public int PersonID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        //NAvigation prop
        public Person Person { get; set; }
    }
}
