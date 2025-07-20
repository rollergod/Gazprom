using Gazprom.API.Domain;
using Gazprom.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace Gazprom.API.Repositories;

public class OfferRepository(AppDbContext context) : IOfferRepository
{
    public async Task<int> AddOffer(Offer offer)
    {
        await context.Offers.AddAsync(offer);
        await context.SaveChangesAsync();
        return offer.Id;
    }

    public async Task<Offer?> GetOffer(string mark, string model, int supplierId)
    {
        var offer = await context.Offers
            .Include(x => x.Supplier)
            .FirstOrDefaultAsync(x =>
                x.Mark.ToLower() == mark.ToLower() && 
                x.Model.ToLower() == model.ToLower() &&
                x.SupplierId == supplierId);

        return offer;
    }

    public async Task<List<Offer>> FilterOffers(string? searchTerm)
    {
        var query = context.Offers
            .Include(o => o.Supplier)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(o =>
                o.Mark.ToLower().Contains(searchTerm) ||
                o.Model.ToLower().Contains(searchTerm) ||
                o.Supplier.Name.ToLower().Contains(searchTerm));
        }

        var items = await query
            .ToListAsync();

        return items;
    }
}