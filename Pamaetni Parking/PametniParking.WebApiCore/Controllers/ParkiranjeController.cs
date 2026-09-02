using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkiranjeController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiParkiranja")]
    public IActionResult PreuzmiParkiranja()
    {
        (bool isError, var parkiranja, string? error) = DTOManager.VratiSvaParkiranja();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(parkiranja);
    }

    [HttpGet]
    [Route("PreuzmiParkiranje/{id}")]
    public async Task<IActionResult> PreuzmiParkiranje(int id)
    {
        (bool isError, var parkiranje, string? error) = await DTOManager.VratiParkiranjeAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(parkiranje);
    }

    [HttpPost]
    [Route("DodajParkiranje")]
    public async Task<IActionResult> DodajParkiranje([FromBody] ParkiranjeView p)
    {
        var data = await DTOManager.DodajParkiranjeAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato parkiranje. Vozilo: {p.VoziloOznaka}");
    }

    [HttpPut]
    [Route("PromeniParkiranje")]
    public async Task<IActionResult> PromeniParkiranje([FromBody] ParkiranjeView p)
    {
        (bool isError, var parkiranje, string? error) = await DTOManager.AzurirajParkiranjeAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirano parkiranje. ID: {parkiranje.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiParkiranje/{id}")]
    public async Task<IActionResult> IzbrisiParkiranje(int id)
    {
        var data = await DTOManager.ObrisiParkiranjeAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisano parkiranje. ID: {id}");
    }
}
