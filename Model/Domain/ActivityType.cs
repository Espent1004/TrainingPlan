﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ActivityType
    {
        public int ActivtyTypeId { get; set; }
        public String ActivityTypeText { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
