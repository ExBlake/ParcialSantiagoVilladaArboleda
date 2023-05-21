using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TicketSystem_WebAPI.DAL.Entities;

namespace TicketSystem_WebAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){}
        public DbSet<Tickets> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tickets>().HasIndex(t => t.Id).IsUnique();
        }
    }
}
