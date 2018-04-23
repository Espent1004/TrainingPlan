using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
