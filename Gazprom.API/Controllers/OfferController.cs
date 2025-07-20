using Gazprom.API.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace Gazprom.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferController(IOfferService offerService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<OfferDto>> Post([FromBody] CreateOfferDto createOfferDto)
    {
        if (string.IsNullOrWhiteSpace(createOfferDto.Mark))
            throw new ArgumentException("Mark cannot be empty");

        if (string.IsNullOrWhiteSpace(createOfferDto.Model))
            throw new ArgumentException("Model cannot be empty");

        var offer = await offerService.CreateOffer(createOfferDto);
        return Ok(offer);
    }

    [HttpGet]
    public async Task<ActionResult<List<OfferDto>>> FilterOffers([FromQuery] string? searchTerm = null)
    {
        var filteredData = await offerService.FilterOffers(searchTerm);
        return Ok(filteredData);
    }

    [Route("poi")]
    [HttpGet]
    public ActionResult<int> Test()
    {
        return Ok(1);
    }
}