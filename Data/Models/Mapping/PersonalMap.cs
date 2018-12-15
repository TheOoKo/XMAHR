using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class PersonalMap : EntityTypeConfiguration<Personal>
    {
        public PersonalMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonalID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Personal");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ChildHoodName).HasColumnName("ChildHoodName");
            this.Property(t => t.OtherName).HasColumnName("OtherName");
            this.Property(t => t.CurrentRank).HasColumnName("CurrentRank");
            this.Property(t => t.StartDateofCurrentPosition).HasColumnName("StartDateofCurrentPosition");
            this.Property(t => t.HowYouGetJob).HasColumnName("HowYouGetJob");
            this.Property(t => t.SelectedOrDirectAppointment).HasColumnName("SelectedOrDirectAppointment");
            this.Property(t => t.JobRecommendedBy).HasColumnName("JobRecommendedBy");
            this.Property(t => t.StartJoinDate).HasColumnName("StartJoinDate");
            this.Property(t => t.Salary).HasColumnName("Salary");
            this.Property(t => t.SalaryRange).HasColumnName("SalaryRange");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.DivisionName).HasColumnName("DivisionName");
            this.Property(t => t.SectionID).HasColumnName("SectionID");
            this.Property(t => t.SectionName).HasColumnName("SectionName");
            this.Property(t => t.WorkAddress).HasColumnName("WorkAddress");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.NativeTown).HasColumnName("NativeTown");
            this.Property(t => t.Religion).HasColumnName("Religion");
            this.Property(t => t.Race).HasColumnName("Race");
            this.Property(t => t.NRCNo).HasColumnName("NRCNo");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.HairColor).HasColumnName("HairColor");
            this.Property(t => t.EyeColor).HasColumnName("EyeColor");
            this.Property(t => t.DistinguishedMark).HasColumnName("DistinguishedMark");
            this.Property(t => t.SerivceYear).HasColumnName("SerivceYear");
            this.Property(t => t.StartServiceDate).HasColumnName("StartServiceDate");
            this.Property(t => t.CurrentAddress).HasColumnName("CurrentAddress");
            this.Property(t => t.PermanentAddress).HasColumnName("PermanentAddress");
            this.Property(t => t.PreviousAddress).HasColumnName("PreviousAddress");
            this.Property(t => t.Education).HasColumnName("Education");
            this.Property(t => t.ForeignTrip).HasColumnName("ForeignTrip");
            this.Property(t => t.Hobby).HasColumnName("Hobby");
            this.Property(t => t.PreviousJobs).HasColumnName("PreviousJobs");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
