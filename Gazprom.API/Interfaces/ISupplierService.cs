using Gazprom.API.DTO;

namespace WebApplication1.Interfaces;

public interface ISupplierService
{
    Task<List<SupplierDto>> GetPopularSuppliers();
    Task<SupplierDto> GetSupplierById(int id);
}