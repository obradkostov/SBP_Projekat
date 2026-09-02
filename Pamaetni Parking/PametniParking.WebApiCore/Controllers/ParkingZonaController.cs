using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingZonaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiZone")]
    public IActionResult PreuzmiZone()
    {
        (bool isError, var zone, string? error) = DTOManager.VratiSveZone();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zone);
    }

    [HttpGet]
    [Route("PreuzmiZonu/{id}")]
    public async Task<IActionResult> PreuzmiZonu(int id)
    {
        (bool isError, var zona, string? error) = await DTOManager.VratiZonuAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(zona);
    }

    [HttpPost]
    [Route("DodajZonu")]
    public async Task<IActionResult> DodajZonu([FromBody] ParkingZonaView p)
    {
        var data = await DTOManager.DodajZonuAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata zona. Naziv: {p.Naziv}");
    }

    [HttpPut]
    [Route("PromeniZonu")]
    public async Task<IActionResult> PromeniZonu([FromBody] ParkingZonaView p)
    {
        (bool isError, var zona, string? error) = await DTOManager.AzurirajZonuAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirana zona. Naziv: {zona.Naziv}");
    }

    [HttpDelete]
    [Route("IzbrisiZonu/{id}")]
    public async Task<IActionResult> IzbrisiZonu(int id)
    {
        var data = await DTOManager.ObrisiZonuAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana zona. ID: {id}");
    }
}
