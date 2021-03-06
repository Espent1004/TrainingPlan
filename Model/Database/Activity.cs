﻿using System;
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
        public Users User { get; set; }
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }
        public int StatusId { get; set; }
        public  Status Status { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
