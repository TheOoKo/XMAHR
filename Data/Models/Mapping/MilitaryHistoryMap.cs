using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MilitaryHistoryMap : EntityTypeConfiguration<MilitaryHistory>
    {
        public MilitaryHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MilitaryHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MilitaryHistory");
            this.Property(t => t.MilitaryHistoryID).HasColumnName("MilitaryHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.MilitaryIDNo).HasColumnName("MilitaryIDNo");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.OfficerTrainingCourseNo).HasColumnName("OfficerTrainingCourseNo");
            this.Property(t => t.MilitaryName).HasColumnName("MilitaryName");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.GazettedDate).HasColumnName("GazettedDate");
            this.Property(t => t.ResignedDate).HasColumnName("ResignedDate");
            this.Property(t => t.ReasonToLeave).HasColumnName("ReasonToLeave");
            this.Property(t => t.RetireSalary).HasColumnName("RetireSalary");
        }
    }
}
