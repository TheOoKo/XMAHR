using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class JobHistory
    {
        public int JobHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string JobName { get; set; }
        public string OfficialPosition { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Section { get; set; }
        public string Region { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Order { get; set; }
        public string Remark { get; set; }
    }
}
