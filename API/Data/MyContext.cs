using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    public DbSet<Project> Projects { get; set; }

    }
}