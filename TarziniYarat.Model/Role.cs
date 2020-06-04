using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Role:BaseEntity
    {
        public Role()
        {
            Members = new HashSet<Person>();
        }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        //Navigation prop
        public ICollection<Person> Members { get; set; }
    }
}
