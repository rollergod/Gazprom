using Gazprom.API.Domain;

namespace WebApplication1.Interfaces;

public interface IOfferRepository
{
    Task<int> AddOffer(Offer offer);
    Task<Offer?> GetOffer(string mark, string model, int supplierId);
    Task<List<Offer>> FilterOffers(string? searchTerm);
}