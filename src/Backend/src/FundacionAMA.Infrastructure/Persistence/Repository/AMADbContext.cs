using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Shared.Extensions.DataExtension;

using Microsoft.EntityFrameworkCore;

namespace FundacionAMA.Infrastructure.Persistence.Repository
{
    public class AMADbContext : DbContext
    {
        public AMADbContext(DbContextOptions<AMADbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }

        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

        public virtual DbSet<BeneficiaryType> BeneficiaryTypes { get; set; }

        public virtual DbSet<Brigade> Brigades { get; set; }

        public virtual DbSet<BrigadeBeneficiary> BrigadeBeneficiaries { get; set; }

        public virtual DbSet<BrigadeVoluntareer> BrigadeVoluntareers { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<CompanyUser> CompanyUsers { get; set; }

        public virtual DbSet<ConsultVolunteer> ConsultVolunteers { get; set; }

        public virtual DbSet<Donation> Donations { get; set; }

        public virtual DbSet<DonationType> DonationTypes { get; set; }

        public virtual DbSet<Donor> Donors { get; set; }

        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<RegistrationVolunteer> RegistrationVolunteers { get; set; }

        public virtual DbSet<SmtpConfiguration> SmtpConfiguration { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Volunteer> Volunteers { get; set; }

        public override int SaveChanges()
        {
            SetAuditoria();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditoria();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditoria()
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    _ = entry.SetProperty("UpdatedAt", DateTime.UtcNow)

                        .SetProperty("Status", "A");

                }

                if (entry.State == EntityState.Added)
                {
                    _ = entry.SetProperty("CreatedAt", DateTime.UtcNow)

                    .SetProperty("Active", true)
                    .SetProperty("Status", "A");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(AMADbContext).Assembly);


            base.OnModelCreating(modelBuilder);
        }

    }
}