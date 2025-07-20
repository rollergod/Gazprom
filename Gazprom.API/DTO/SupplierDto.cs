namespace Gazprom.API.DTO;

public record SupplierDto(int Id, string Name, DateTime CreatedDate, int? TotalCount = null);
