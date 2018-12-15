using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MilitaryHistory
    {
        public int MilitaryHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> MilitaryIDNo { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string OfficerTrainingCourseNo { get; set; }
        public string MilitaryName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> GazettedDate { get; set; }
        public Nullable<System.DateTime> ResignedDate { get; set; }
        public string ReasonToLeave { get; set; }
        public Nullable<int> RetireSalary { get; set; }
    }
}
