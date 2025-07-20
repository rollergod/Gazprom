using Gazprom.API.Domain;
using Gazprom.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace Gazprom.API.Repositories;

public class SupplierRepository(AppDbContext context) : ISupplierRepository
{
    public async Task<List<Supplier>> GetPopularSuppliers()
    {
        var populars = await context.Supplier
            .Include(x => x.Offers)
            .OrderByDescending(x => x.Offers.Count)
            .Take(3)
            .AsNoTracking()
            .ToListAsync();

        return populars;
    }

    public async Task<Supplier> GetById(int id)
    {
        return await context.Supplier
            .Include(x => x.Offers)
            .FirstAsync(x => x.Id == id);
    }
}