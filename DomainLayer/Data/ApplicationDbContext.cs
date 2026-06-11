using Microsoft.EntityFrameworkCore;
using Petrol_Pump_Web_API.DomainLayer.Models;

namespace Petrol_Pump_Web_API.DomainLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DispensingRecord> DispensingRecords { get; set; }
    }
}
