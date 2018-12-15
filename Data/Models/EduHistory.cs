using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class EduHistory
    {
        public int EduHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string SchoolOrCollegueOrUniversity { get; set; }
        public string Education { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string SchoolAddress { get; set; }
        public string Rank { get; set; }
        public string LastSchool { get; set; }
        public string StudentLifeActivity { get; set; }
    }
}
