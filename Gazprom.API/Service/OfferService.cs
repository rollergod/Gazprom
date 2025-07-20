using Gazprom.API.Domain;
using Gazprom.API.DTO;
using WebApplication1.Interfaces;

namespace Gazprom.API.Service;

public class OfferService(IOfferRepository offerRepository, ISupplierRepository supplierRepository)
    : IOfferService
{
    public async Task<OfferDto> CreateOffer(CreateOfferDto createOfferDto)
    {
        var supplier = await supplierRepository.GetById(createOfferDto.SupplierId);

        var existingOffers = await offerRepository.GetOffer(
            mark: createOfferDto.Mark, model: createOfferDto.Model, supplierId: supplier.Id);

        if (existingOffers is not null)
            throw new InvalidOperationException("Offers already exist");

        var offer = new Offer
        {
            RegistrationDate = DateTime.Now,
            Model = createOfferDto.Model,
            Mark = createOfferDto.Mark,
            SupplierId = supplier.Id
        };
        var id = await offerRepository.AddOffer(offer);

        var newOfferDto = new OfferDto(Id: id,
            Mark: offer.Mark,
            Model: offer.Model,
            SupplierDto: new SupplierDto(
                Id: supplier.Id,
                Name: supplier.Name,
                CreatedDate: supplier.CreatedDate,
                TotalCount: supplier.Offers.Count));
        return newOfferDto;
    }

    public async Task<List<OfferDto>> FilterOffers(string? searchTerm)
    {
        var filteredData = await offerRepository.FilterOffers(searchTerm);
        return filteredData.Select(x => new OfferDto(
                Id: x.Id,
                Mark: x.Mark,
                Model: x.Model,
                SupplierDto: new SupplierDto(
                    Id: x.Supplier.Id,
                    Name: x.Supplier.Name,
                    CreatedDate: x.Supplier.CreatedDate)))
            .ToList();
    }
}