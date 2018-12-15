using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class TrainingFGHistory
    {
        public int TrainingFGHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string TrainingID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingPeriod { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Rank { get; set; }
        public string Remark { get; set; }
        public string Location { get; set; }
        public string SupportingOrg { get; set; }
        public string CertificateName { get; set; }
    }
}
