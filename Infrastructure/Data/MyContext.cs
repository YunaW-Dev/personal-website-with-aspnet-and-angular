using Microsoft.EntityFrameworkCore;
using Core.Entities;
namespace Infrastructure.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectYear> ProjectYears { get; set; }
    }
}