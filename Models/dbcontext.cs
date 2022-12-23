using Microsoft.EntityFrameworkCore;

namespace crudapi.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options):base(options) 
        { }
        public DbSet<user> users { get; set; }
    }
}
