using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Comment:BaseEntity
    {
        public int CommentID { get; set; }
        public DateTime CommentDate { get; set; }
        public int CombineID { get; set; }
    }
}
