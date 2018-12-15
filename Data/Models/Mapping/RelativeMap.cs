using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class RelativeMap : EntityTypeConfiguration<Relative>
    {
        public RelativeMap()
        {
            // Primary Key
            this.HasKey(t => t.RelativeID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Relative");
            this.Property(t => t.RelativeID).HasColumnName("RelativeID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.RelativeTypeID).HasColumnName("RelativeTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OtherName).HasColumnName("OtherName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Citizen).HasColumnName("Citizen");
            this.Property(t => t.Race).HasColumnName("Race");
            this.Property(t => t.Religion).HasColumnName("Religion");
            this.Property(t => t.NativeTown).HasColumnName("NativeTown");
            this.Property(t => t.Occupation).HasColumnName("Occupation");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.PoliticalPartyMember).HasColumnName("PoliticalPartyMember");
        }
    }
}
