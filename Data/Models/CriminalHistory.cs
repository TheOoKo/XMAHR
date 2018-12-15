using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CriminalHistory
    {
        public int CriminalHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string DepartmentPurnishments { get; set; }
        public string GetPurnishment { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Period { get; set; }
        public string Reason { get; set; }
        public string CourtPurnishment { get; set; }
        public string Remark { get; set; }
    }
}
