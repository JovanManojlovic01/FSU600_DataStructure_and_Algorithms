using Microsoft.EntityFrameworkCore;
using System;

namespace TravelAgency
{
    public class TravelAgency_Repository
    {
        private IDbContextFactory<TravelAgencyDB> _travelAgencyFactory;

        public TravelAgency_Repository(IDbContextFactory<TravelAgencyDB> travelagencyFactory) 
        {
            _travelAgencyFactory = travelagencyFactory;
        }

        public async Task<Offer?> GetOffer (int id)
        {
            using var context = _travelAgencyFactory.CreateDbContext ();
            var offer = await context.Offer.FindAsync(id);
            return offer;
        }

    }

}
