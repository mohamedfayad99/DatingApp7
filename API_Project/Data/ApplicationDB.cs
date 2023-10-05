using API_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Data
{
    public class ApplicationDB :DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options):base(options) 
        {
                
        }
        public DbSet<AppUser> users { get; set; }
    }
}
