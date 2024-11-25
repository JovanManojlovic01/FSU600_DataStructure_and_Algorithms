using Microsoft.EntityFrameworkCore;

namespace TravelAgency
{
    public class TravelAgencyDB : DbContext
    {
        public DbSet<Offer> Offer { get; set; }
        public TravelAgencyDB(DbContextOptions<TravelAgencyDB> options) : base(options)
        {
            
        }
    }
}
