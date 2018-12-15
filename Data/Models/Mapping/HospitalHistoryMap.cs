using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class HospitalHistoryMap : EntityTypeConfiguration<HospitalHistory>
    {
        public HospitalHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.HispitalHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("HospitalHistory");
            this.Property(t => t.HispitalHistoryID).HasColumnName("HispitalHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.DiseaseName).HasColumnName("DiseaseName");
            this.Property(t => t.HospitalName).HasColumnName("HospitalName");
            this.Property(t => t.HospitalAddress).HasColumnName("HospitalAddress");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.Todate).HasColumnName("Todate");
        }
    }
}
