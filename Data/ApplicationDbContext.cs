using Microsoft.EntityFrameworkCore;
using WorldCups.Models;

namespace WorldCups.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
       

       

      public  DbSet<Categories> categories { get; set; }  
      public  DbSet<CategorisTransportation> transportations { get; set; }

        public DbSet<Stadiums> stadiums { get; set; }

        public DbSet<TableFootbul> tableFootbuls { get; set; }

        public DbSet<Hotel> hotel { get; set; }

        public DbSet<Transport> transports { get; set; }   


        
    }
}
