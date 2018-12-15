using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class DivisionMap : EntityTypeConfiguration<Division>
    {
        public DivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.DivisionID);

            // Properties
            this.Property(t => t.DivisionName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Division");
            this.Property(t => t.DivisionID).HasColumnName("DivisionID");
            this.Property(t => t.DivisionName).HasColumnName("DivisionName");
        }
    }
}
