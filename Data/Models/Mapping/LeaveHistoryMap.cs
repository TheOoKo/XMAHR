using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class LeaveHistoryMap : EntityTypeConfiguration<LeaveHistory>
    {
        public LeaveHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.LeaveHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("LeaveHistory");
            this.Property(t => t.LeaveHistoryID).HasColumnName("LeaveHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.LeaveID).HasColumnName("LeaveID");
            this.Property(t => t.LeaveName).HasColumnName("LeaveName");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
