using IronApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IronApi.Maping
{
    public class IronApiDbContext : DbContext
    {
        public IronApiDbContext(DbContextOptions<IronApiDbContext> options) : base(options) { }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetLiveInStatus> AssetLiveStatus { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Unit>()
        //        .HasKey(a => a.Id);
        //    modelBuilder.Entity<Asset>()
        //        .HasKey(A => A.Id);
        //    modelBuilder.Entity<Unit>()
        //        .Property(u => u.UnitName)
        //        .HasDefaultValue("Unknown Unit");
        //    modelBuilder.Entity<Unit>()
        //        .Property(u => u.Sector)
        //        .HasDefaultValue("General");
        //    modelBuilder.Entity<Asset>()
        //        .Property(a => a.AssetType)
        //        .HasDefaultValue("GenericAsset");
        //    modelBuilder.Entity<Asset>()
        //        .HasOne<Unit>()
        //        .WithMany()
        //        .HasForeignKey(a => a.UnitId);
        //    modelBuilder.Entity<AssetLiveInStatus>()
        //        .HasOne<Asset>()
        //        .WithMany()
        //        .HasForeignKey(b => b.AssetId);
        //}
    }
}
