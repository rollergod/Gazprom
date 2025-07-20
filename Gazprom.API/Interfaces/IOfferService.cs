using Gazprom.API.DTO;

namespace WebApplication1.Interfaces;

public interface IOfferService
{
    Task<OfferDto> CreateOffer(CreateOfferDto createOfferDto);
    Task<List<OfferDto>> FilterOffers(string searchTerm);
}