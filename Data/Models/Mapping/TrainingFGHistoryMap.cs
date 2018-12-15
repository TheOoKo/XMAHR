using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class TrainingFGHistoryMap : EntityTypeConfiguration<TrainingFGHistory>
    {
        public TrainingFGHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.TrainingFGHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TrainingFGHistory");
            this.Property(t => t.TrainingFGHistoryID).HasColumnName("TrainingFGHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.TrainingID).HasColumnName("TrainingID");
            this.Property(t => t.TrainingName).HasColumnName("TrainingName");
            this.Property(t => t.TrainingPeriod).HasColumnName("TrainingPeriod");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.SupportingOrg).HasColumnName("SupportingOrg");
            this.Property(t => t.CertificateName).HasColumnName("CertificateName");
        }
    }
}
