using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Models.Auth; 
using ReoNet.Api.Models;
namespace ReoNet.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SecUser> SecUsers { get; set; } = null!;
        public DbSet<ReonetOrderMaster> ReonetOrderMasters { get; set; } = null!;
        public DbSet<ReonetOrderDetail> ReonetOrderDetails { get; set; } = null!;
        public DbSet<ReonetServices> ReonetServices { get; set; } = null!;
        public DbSet<ReonetOrderStatus> ReonetOrderStatuses { get; set; } = null!;
        public DbSet<ReonetOrderImage> Reonet_OrderImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrderMaster
            modelBuilder.Entity<ReonetOrderMaster>(entity =>
            {
                entity.HasKey(e => e.Srl);
                entity.ToTable("reonet_ordermaster");

                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.OrderDate).HasColumnType("char(10)");
                entity.Property(e => e.DeliveryDate).HasColumnType("char(10)");
            });

            // OrderDetail
            modelBuilder.Entity<ReonetOrderDetail>(entity =>
            {
                base.OnModelCreating(modelBuilder);

        // Master-Detail relationship
                modelBuilder
                    .Entity<ReonetOrderDetail>()
                    .HasOne(d => d.ReonetMaster) // Navigation property در OrderDetail
                    .WithMany(m => m.OrderDetails) // Navigation property در OrderMaster
                    .HasForeignKey(d => d.SrlOrdermaster)
                    .OnDelete(DeleteBehavior.Cascade);

        // OrderDetail - Service relationship
            modelBuilder.Entity<ReonetOrderDetail>()
        .HasMany(d => d.Images)
        .WithOne(i => i.OrderDetail)
        .HasForeignKey(i => i.Srl_OrderDetail);

                modelBuilder
                    .Entity<ReonetOrderDetail>()
                    .HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.SrlSubservice)
                    .OnDelete(DeleteBehavior.Restrict);

                         modelBuilder.Entity<ReonetOrderDetail>()
                    .HasOne(d => d.Status)
                    .WithMany()
                    .HasForeignKey(d => d.SrlOrderstatus)
                    .OnDelete(DeleteBehavior.Restrict);
    });

            // SubService
            modelBuilder.Entity<ReonetServices>(entity =>
            {
                entity.HasKey(e => e.Srl);
                entity.ToTable("reonet_Services"); 
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
            modelBuilder.Entity<ReonetOrderStatus>(entity =>
            {
                entity.HasKey(e => e.Srl);
                entity.ToTable("reonet_orderstatus");
                entity.Property(e => e.Title).HasMaxLength(500);
                entity.Property(e => e.Code).HasMaxLength(50);
            });
             modelBuilder.Entity<ReonetOrderImage>(entity =>
        {
            entity.ToTable("reonet_orderImage");

            entity.HasKey(e => e.Srl);

            entity.Property(e => e.Srl)
                .HasColumnName("srl");

            entity.Property(e => e.Srl_OrderDetail)
                .HasColumnName("srl_orderdetail")
                .IsRequired();

            entity.Property(e => e.Media_Type)
                .HasColumnName("media_type")
                .HasMaxLength(10);

            entity.Property(e => e.File_Path)
                .HasColumnName("file_path")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Stage)
                .HasColumnName("stage")
                .HasMaxLength(20)
                .IsRequired();
            entity.Property(e => e.Public_id)
                .HasColumnName("public_id")
                .HasMaxLength(255)
                .IsRequired();
            entity.Property(e => e.Created_At)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");
        });
        }
    }
}
