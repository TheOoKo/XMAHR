using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class PoliticalHistoryMap : EntityTypeConfiguration<PoliticalHistory>
    {
        public PoliticalHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.PoliticsHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PoliticalHistory");
            this.Property(t => t.PoliticsHistoryID).HasColumnName("PoliticsHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.PoliticalOrganization).HasColumnName("PoliticalOrganization");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Rank).HasColumnName("Rank");
        }
    }
}
