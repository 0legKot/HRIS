using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public DbSet<ScientificTitle> ScientificTitles { get; set; } = null!;
        public DbSet<ScientificDegree> ScientificDegrees { get; set; } = null!;
        public DbSet<UnitsGroup> UnitsGroups { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<StaffSchedule> StaffSchedules { get; set; } = null!;
        public DbSet<VnzList> VnzLists { get; set; } = null!;
        public DbSet<Faculty> Faculties { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmploymentOrder> EmploymentOrders { get; set; } = null!;
        public DbSet<DismissalOrder> DismissalOrders { get; set; } = null!;
        public DbSet<JobChangeOrder> JobChangeOrders { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobChangeOrder>()
                .HasOne(j => j.NewPosition)
                .WithMany()
                .HasForeignKey(j => j.NewPositionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobChangeOrder>()
                .HasOne(j => j.NewUnit)
                .WithMany()
                .HasForeignKey(j => j.NewUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobChangeOrder>()
                .HasOne(j => j.Employee)
                .WithMany(e => e.JobChangeOrders)
                .HasForeignKey(j => j.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
