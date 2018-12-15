using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class FGHistoryMap : EntityTypeConfiguration<FGHistory>
    {
        public FGHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.FGHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("FGHistory");
            this.Property(t => t.FGHistoryID).HasColumnName("FGHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.MeetingOrg).HasColumnName("MeetingOrg");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.SupportingOrganization).HasColumnName("SupportingOrganization");
        }
    }
}
