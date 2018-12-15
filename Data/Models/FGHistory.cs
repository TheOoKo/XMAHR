using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class FGHistory
    {
        public int FGHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string Country { get; set; }
        public string Reason { get; set; }
        public string MeetingOrg { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string SupportingOrganization { get; set; }
    }
}
