using Microsoft.EntityFrameworkCore;
using Mine.Domain.Entities.User;
using Mine.Domain.Entities.XMine;

namespace Mine.Infrastructure.Data
{
    public class MineDbContext : DbContext
    {
        public MineDbContext(DbContextOptions<MineDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<XItemEntity> XItems { get; set; }
        public DbSet<XMinerEntity> XMiners { get; set; }
        public DbSet<XMoveEntity> XMoves { get; set; }
        public DbSet<XPerkEntity> XPerks { get; set; }
        public DbSet<XRockEntity> XRocks { get; set; }
        public DbSet<XToolEntity> XTools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<XMinerEntity>()
            //    .HasOne(x => x.UserId)
            //    .WithMany(u => u.XMiners)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
