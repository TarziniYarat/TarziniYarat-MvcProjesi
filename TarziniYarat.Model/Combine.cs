using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Combine:BaseEntity
    {
        public Combine()
        {
            Members = new HashSet<Member>();
            Comments = new HashSet<Comment>();
        }
        public int CombineID { get; set; }
        public string PhotoPath { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }

        //Navigation prop
        public ICollection<Member> Members { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
