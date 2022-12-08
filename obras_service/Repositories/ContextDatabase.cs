using Microsoft.EntityFrameworkCore;
using obras_service.Models;

namespace obras_service.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }
        public DbSet<Obras> Obras { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Obras>().ToTable("Obras");
        }
            
    }
}
