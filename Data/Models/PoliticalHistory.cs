using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class PoliticalHistory
    {
        public int PoliticsHistoryID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string PoliticalOrganization { get; set; }
        public string Location { get; set; }
        public string Year { get; set; }
        public string Rank { get; set; }
    }
}
