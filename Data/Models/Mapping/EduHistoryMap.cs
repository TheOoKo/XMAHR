using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class EduHistoryMap : EntityTypeConfiguration<EduHistory>
    {
        public EduHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.EduHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("EduHistory");
            this.Property(t => t.EduHistoryID).HasColumnName("EduHistoryID");
            this.Property(t => t.PersonalID).HasColumnName("PersonalID");
            this.Property(t => t.SchoolOrCollegueOrUniversity).HasColumnName("SchoolOrCollegueOrUniversity");
            this.Property(t => t.Education).HasColumnName("Education");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.SchoolAddress).HasColumnName("SchoolAddress");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.LastSchool).HasColumnName("LastSchool");
            this.Property(t => t.StudentLifeActivity).HasColumnName("StudentLifeActivity");
        }
    }
}
