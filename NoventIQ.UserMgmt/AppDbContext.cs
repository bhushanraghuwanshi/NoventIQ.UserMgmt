using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NoventIQ.UserMgmt.Models;

namespace NoventIQ.UserMgmt


{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(x => x.Roles).WithMany();
               

        }

    }
}
