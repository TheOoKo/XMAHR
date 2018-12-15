using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class LeaveHistory
    {
        public int LeaveHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> LeaveID { get; set; }
        public string LeaveName { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Order { get; set; }
        public string Remark { get; set; }
    }
}
