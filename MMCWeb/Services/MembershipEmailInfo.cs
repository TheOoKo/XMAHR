using System;
using System.ComponentModel.DataAnnotations;

namespace MMCWeb.Services
{
    public class IndividualMembershipEmailInfo : EmailInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd, MMM yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Accesstime { get; set; }
    }
    public class CorporateMembershipEmailInfo : EmailInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string LicenseNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd, MMM yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Accesstime { get; set; }
    }
}