using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class SectionMap : EntityTypeConfiguration<Section>
    {
        public SectionMap()
        {
            // Primary Key
            this.HasKey(t => t.SectionID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Section");
            this.Property(t => t.SectionID).HasColumnName("SectionID");
            this.Property(t => t.SectionName).HasColumnName("SectionName");
        }
    }
}
