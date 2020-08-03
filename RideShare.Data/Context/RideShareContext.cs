using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace RideShare.Data.Context
{
    public partial class RideShareContext : DbContext
    {
        public RideShareContext()
        {
        }
        
        public RideShareContext(DbContextOptions<RideShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TravelPlan> TravelPlan { get; set; }
        public virtual DbSet<TravelPlanDetail> TravelPlanDetail { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost,1401;Database=RideShare;User Id=sa;Password=789qwe...;");
                var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelPlan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TravelDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TravelPlan)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_travelPlan_user");
            });

            modelBuilder.Entity<TravelPlanDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TravelPlanDetail)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_travelPlanDetail_user");

                entity.HasOne(d => d.TravelPlan)
                    .WithMany(p => p.TravelPlanDetail)
                    .HasForeignKey(d => d.TravelPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_travelPlanDetail_travelPlan");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
