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
    public DbSet<Catagory> catagories { get; set; }
    public DbSet<Expanse> expanses { get; set; }
    public DbSet<customer> customers { get; set; }
    public DbSet<auth> auths { get; set; }


  }
}
