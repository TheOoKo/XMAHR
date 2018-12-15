using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class ForeignRelationMap : EntityTypeConfiguration<ForeignRelation>
    {
        public ForeignRelationMap()
        {
            // Primary Key
            this.HasKey(t => t.ForeignRelationID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ForeignRelation");
            this.Property(t => t.ForeignRelationID).HasColumnName("ForeignRelationID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.RelativeTypeID).HasColumnName("RelativeTypeID");
            this.Property(t => t.Citizen).HasColumnName("Citizen");
            this.Property(t => t.Occupation).HasColumnName("Occupation");
            this.Property(t => t.CurrentCountry).HasColumnName("CurrentCountry");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.ArrivalTime).HasColumnName("ArrivalTime");
        }
    }
}
