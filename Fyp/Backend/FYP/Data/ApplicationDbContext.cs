using FYP.Models;
using Microsoft.EntityFrameworkCore;
using FYP.Builder;

namespace FYP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var pipeline = new List<Action<ModelBuilder>>
            {
                UserBuilder.BuilderUser
            };
            pipeline.ForEach(build => build(modelBuilder));
        }
    }
}
