using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class HospitalHistory
    {
        public int HispitalHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string DiseaseName { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> Todate { get; set; }
    }
}
