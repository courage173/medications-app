using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<PharmaceuticalForm> PharmaceuticalForms { get; set; }
        public DbSet<ATCCodes> ATCCodes { get; set; }
        public DbSet<TherapeuticClass> TherapeuticClasses { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<MedicationActiveIngredients> MedicationActiveIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Medication>()
                .HasOne(m => m.PharmaceuticalForm)
                .WithMany()
                .HasForeignKey(m => m.PharmaceuticalFormId);

            modelBuilder.Entity<Medication>()
                .HasOne(m => m.ATCCodes)
                .WithMany()
                .HasForeignKey(m => m.ATCCodeId);

            modelBuilder.Entity<Medication>()
                .HasOne(m => m.TherapeuticClass)
                .WithMany()
                .HasForeignKey(m => m.TherapeuticClassId);

            modelBuilder.Entity<Medication>()
                .HasOne(m => m.Classification)
                .WithMany()
                .HasForeignKey(m => m.ClassificationId);

            modelBuilder.Entity<Medication>()
                .HasMany(m => m.MedicationActiveIngredients)
                .WithOne(mai => mai.Medication)
                .HasForeignKey(mai => mai.MedicationId);

            modelBuilder.Entity<MedicationActiveIngredients>()
                   .HasOne(mai => mai.ActiveIngredient)
                   .WithMany()
                   .HasForeignKey(mai => mai.ActiveIngredientId);

            modelBuilder.Entity<ATCCodes>().HasIndex(u => u.Code).IsUnique();
            modelBuilder.Entity<Classification>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<PharmaceuticalForm>().HasIndex(u => u.Form).IsUnique();
            modelBuilder.Entity<TherapeuticClass>().HasIndex(u => u.Name).IsUnique();
        }
    }
}
