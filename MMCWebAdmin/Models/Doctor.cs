using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMAHR.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string MMCNo { get; set; }
        public int LicenseNo { get; set; }
        public string NRCNo { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Race { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string OtherQualification { get; set; }
        public string Contact { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsPractisingDoctor { get; set; }
        public Nullable<bool> IsPractisingInGovernmentService { get; set; }
        public string Gender { get; set; }
        public string Remark { get; set; }
        public string Nationality { get; set; }
        public string ClinicAddress { get; set; }

        public string AdState { get; set; }
        public string CState { get; set; }
        public string Image { get; set; }
        public Nullable<bool> Validity { get; set; }
        public int Createdby { get; set; }
        public Nullable<Boolean> IsDeleted { get; set; }
        public Nullable<DateTime> Accesstime { get; set; }
        public string AdTownship { get; set; }
        public string CTownship { get; set; }
        public string Religion { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string ServiceType { get; set; }

    }
}