using IrongridConsumer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridConsumer.Maping
{
    public class IronGridDbContext : DbContext
    {
        public IronGridDbContext(DbContextOptions<IronGridDbContext> options) : base(options) { }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetLiveInStatus> AssetLiveStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Unit>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Asset>()
                .HasKey(A => A.Id);

           
                
                
           
                
            
                
                
                


                
                



        }


    }
}
