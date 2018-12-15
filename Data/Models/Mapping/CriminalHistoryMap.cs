using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CriminalHistoryMap : EntityTypeConfiguration<CriminalHistory>
    {
        public CriminalHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CriminalHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CriminalHistory");
            this.Property(t => t.CriminalHistoryID).HasColumnName("CriminalHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.DepartmentPurnishments).HasColumnName("DepartmentPurnishments");
            this.Property(t => t.GetPurnishment).HasColumnName("GetPurnishment");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Period).HasColumnName("Period");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.CourtPurnishment).HasColumnName("CourtPurnishment");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
