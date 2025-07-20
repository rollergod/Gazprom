using Gazprom.API.Domain;

namespace WebApplication1.Interfaces;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetPopularSuppliers();
    Task<Supplier> GetById(int id);
}