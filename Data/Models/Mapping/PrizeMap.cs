using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class PrizeMap : EntityTypeConfiguration<Prize>
    {
        public PrizeMap()
        {
            // Primary Key
            this.HasKey(t => t.PrizeID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Prize");
            this.Property(t => t.PrizeID).HasColumnName("PrizeID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.Period).HasColumnName("Period");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
