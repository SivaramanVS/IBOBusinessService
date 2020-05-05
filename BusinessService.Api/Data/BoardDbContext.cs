using Microsoft.EntityFrameworkCore;

namespace BusinessService.Api.Data
{
    public sealed class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> dbContextOptions) : base(dbContextOptions)
        {
            // Create the database if it doesn't exist
            Database.EnsureCreated();
        }
        public DbSet<BoardDbModel> BoardDbModels { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}