using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Models.Entities;

namespace AspnetCoreMvcFull.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<watch> watches { get; set; }
    public DbSet<branch> branches { get; set; }
    public DbSet<zone> zones { get; set; }

  }
}
