using Microsoft.EntityFrameworkCore;
using MyFirstApplication.Model;

namespace MyFirstApplication.Data
{
    public class MyFirstApplicationContext : DbContext
    {

        public MyFirstApplicationContext(DbContextOptions<MyFirstApplicationContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<People>(entity =>
            {
                entity.ToTable("PEOPLE");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired();

                entity.Property(p => p.Cpf)
               .HasColumnName("CPF")
               .IsRequired();

                entity.Property(p => p.Phone)
               .HasColumnName("PHONE")
               .IsRequired();

                entity.Property(p => p.Email)
               .HasColumnName("EMAIL")
               .IsRequired();

                entity.Property(p => p.Password)
               .HasColumnName("PASSWORD")
               .IsRequired();
            });
        }
    }
}
