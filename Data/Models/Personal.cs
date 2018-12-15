using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Personal
    {
        public int PersonalID { get; set; }
        public string Name { get; set; }
        public string ChildHoodName { get; set; }
        public string OtherName { get; set; }
        public string CurrentRank { get; set; }
        public Nullable<System.DateTime> StartDateofCurrentPosition { get; set; }
        public string HowYouGetJob { get; set; }
        public string SelectedOrDirectAppointment { get; set; }
        public string JobRecommendedBy { get; set; }
        public Nullable<System.DateTime> StartJoinDate { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<int> SalaryRange { get; set; }
        public Nullable<int> DivisionID { get; set; }
        public string DivisionName { get; set; }
        public Nullable<int> SectionID { get; set; }
        public string SectionName { get; set; }
        public string WorkAddress { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string NativeTown { get; set; }
        public string Religion { get; set; }
        public string Race { get; set; }
        public string NRCNo { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string DistinguishedMark { get; set; }
        public Nullable<int> SerivceYear { get; set; }
        public Nullable<System.DateTime> StartServiceDate { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PreviousAddress { get; set; }
        public string Education { get; set; }
        public Nullable<bool> ForeignTrip { get; set; }
        public string Hobby { get; set; }
        public string PreviousJobs { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
