using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Member:BaseEntity
    {
        public int MemberID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKN { get; set; }
        public string BirthDate { get; set; }
        public string Password { get; set; }

        //Navigation prop
        public Role Role { get; set; }
    }
}
