using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class Status
    {
        public int StatusId { get; set; }

        public String StatusText { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
