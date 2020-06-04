using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Approve:BaseEntity
    {
        public Approve()
        {
            Members = new HashSet<Person>();
            Combines = new HashSet<Combine>();
        }
        public int MemberID { get; set; }
        public int CombineID { get; set; }
        public DateTime ApproveDate { get; set; }

        //Navigation prop
        public ICollection<Person> Members { get; set; }
        public ICollection<Combine> Combines { get; set; }
    }
}
