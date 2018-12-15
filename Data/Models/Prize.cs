using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Prize
    {
        public int PrizeID { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public string Period { get; set; }
        public string Category { get; set; }
        public string Remark { get; set; }
    }
}
