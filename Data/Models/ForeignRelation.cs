using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ForeignRelation
    {
        public int ForeignRelationID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> RelativeTypeID { get; set; }
        public string Citizen { get; set; }
        public string Occupation { get; set; }
        public string CurrentCountry { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
    }
}
