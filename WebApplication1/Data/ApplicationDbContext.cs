using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mVehAuction.Models;

namespace mVehAuction.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<mVehAuction.Models.Vehicle> Vehicle { get; set; }
        public DbSet<mVehAuction.Models.LotLocation> LotLocation { get; set; }
    }
}