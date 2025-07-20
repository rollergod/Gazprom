using Gazprom.API.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace Gazprom.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController(ISupplierService supplierService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SupplierDto>>> GetPopularSuppliers()
    {
        var popularSuppliers = await supplierService.GetPopularSuppliers();
        return Ok(popularSuppliers);
    }
}