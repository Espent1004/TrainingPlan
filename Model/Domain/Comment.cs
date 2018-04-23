using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String CommentText { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
