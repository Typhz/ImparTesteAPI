using Impar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Impar.Infra.Context
{
    public partial class EntityContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public EntityContext()
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("cars");
            modelBuilder.Entity<Car>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Car>().Property(p => p.PhotoId).HasColumnName("photo_id");
            modelBuilder.Entity<Car>().Property(p => p.Name).HasColumnName("name");
            modelBuilder.Entity<Car>().Property(p => p.Status).HasColumnName("status");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(c => c.Photo)
                    .WithOne(p => p.Car)
                    .HasForeignKey<Photo>(p => p.CarId)
                    .HasConstraintName("FK_cars_photos");
            });

            modelBuilder.Entity<Photo>().ToTable("photos");
            modelBuilder.Entity<Photo>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Photo>().Property(p => p.CarId).HasColumnName("car_id");
            modelBuilder.Entity<Photo>().Property(p => p.Base64).HasColumnName("base64");


            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(p => p.Car)
                    .WithOne(c => c.Photo)
                    .HasForeignKey<Photo>(p => p.CarId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Base64).HasMaxLength(2000000);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
