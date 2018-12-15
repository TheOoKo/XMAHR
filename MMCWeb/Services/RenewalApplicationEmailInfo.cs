using System;
using System.ComponentModel.DataAnnotations;

namespace MMCWeb.Services
{
    public class RenewalApplicationEmailInfo : EmailInfo
    {
        public string Name { get; set; }
        public Nullable<int> LicenseNo { get; set; }
        public string NRC { get; set; }
        public string Degree { get; set; }
        public string GraduationYear { get; set; }
        public string Occupation { get; set; }
        public string CurrentAddress { get; set; }
        public string StateDivision { get; set; }
        public string Township { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Nullable<int> CodeIndex { get; set; }
        public string Code { get; set; }
        public string PostalService { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }

    }
  
}