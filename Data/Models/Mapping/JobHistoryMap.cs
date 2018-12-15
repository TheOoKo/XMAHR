using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class JobHistoryMap : EntityTypeConfiguration<JobHistory>
    {
        public JobHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.JobHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("JobHistory");
            this.Property(t => t.JobHistoryID).HasColumnName("JobHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.JobName).HasColumnName("JobName");
            this.Property(t => t.OfficialPosition).HasColumnName("OfficialPosition");
            this.Property(t => t.Salary).HasColumnName("Salary");
            this.Property(t => t.Department).HasColumnName("Department");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Section).HasColumnName("Section");
            this.Property(t => t.Region).HasColumnName("Region");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
