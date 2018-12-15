using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Relative
    {
        public int RelativeID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> RelativeTypeID { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public string Citizen { get; set; }
        public string Race { get; set; }
        public string Religion { get; set; }
        public string NativeTown { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> PoliticalPartyMember { get; set; }
    }
}
