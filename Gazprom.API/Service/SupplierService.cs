using Gazprom.API.DTO;
using WebApplication1.Interfaces;

namespace WebApplication1.Service;

public class SupplierService(ISupplierRepository supplierRepository) : ISupplierService
{
    public async Task<List<SupplierDto>> GetPopularSuppliers()
    {
        var suppliers = await supplierRepository.GetPopularSuppliers();

        var supplierDto = suppliers.Select(x =>
                new SupplierDto(x.Id, x.Name, x.CreatedDate, x.Offers.Count))
            .ToList();

        return supplierDto;
    }

    public async Task<SupplierDto> GetSupplierById(int id)
    {
        if (id <= 0)
            throw new InvalidOperationException("bad id");
        var supplier = await supplierRepository.GetById(id);
        return new SupplierDto(supplier.Id, supplier.Name, supplier.CreatedDate, supplier.Offers.Count);
    }
}