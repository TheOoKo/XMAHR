using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class RelativeTypeMap : EntityTypeConfiguration<RelativeType>
    {
        public RelativeTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.RelativeTypeID);

            // Properties
            // Table & Column Mappings
            this.ToTable("RelativeType");
            this.Property(t => t.RelativeTypeID).HasColumnName("RelativeTypeID");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
        }
    }
}
