using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String CommentText { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
