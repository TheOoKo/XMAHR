using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    public partial class GovernmentDbContext : DbContext
    {
        static GovernmentDbContext()
        {
            Database.SetInitializer<GovernmentDbContext>(null);
        }

        public GovernmentDbContext()
            : base("Name=GovernmentDbContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CriminalHistory> CriminalHistories { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<EduHistory> EduHistories { get; set; }
        public DbSet<FGHistory> FGHistories { get; set; }
        public DbSet<ForeignRelation> ForeignRelations { get; set; }
        public DbSet<HospitalHistory> HospitalHistories { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<MilitaryHistory> MilitaryHistories { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<PoliticalHistory> PoliticalHistories { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<RelativeType> RelativeTypes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<TrainingFGHistory> TrainingFGHistories { get; set; }
        public DbSet<TrainingHistory> TrainingHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new CriminalHistoryMap());
            modelBuilder.Configurations.Add(new DivisionMap());
            modelBuilder.Configurations.Add(new EduHistoryMap());
            modelBuilder.Configurations.Add(new FGHistoryMap());
            modelBuilder.Configurations.Add(new ForeignRelationMap());
            modelBuilder.Configurations.Add(new HospitalHistoryMap());
            modelBuilder.Configurations.Add(new JobHistoryMap());
            modelBuilder.Configurations.Add(new LeaveHistoryMap());
            modelBuilder.Configurations.Add(new MilitaryHistoryMap());
            modelBuilder.Configurations.Add(new PersonalMap());
            modelBuilder.Configurations.Add(new PoliticalHistoryMap());
            modelBuilder.Configurations.Add(new PrizeMap());
            modelBuilder.Configurations.Add(new RelativeMap());
            modelBuilder.Configurations.Add(new RelativeTypeMap());
            modelBuilder.Configurations.Add(new SectionMap());
            modelBuilder.Configurations.Add(new TrainingFGHistoryMap());
            modelBuilder.Configurations.Add(new TrainingHistoryMap());
        }
    }
}
