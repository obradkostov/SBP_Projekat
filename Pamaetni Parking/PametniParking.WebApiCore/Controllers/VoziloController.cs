using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class VoziloController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiVozila")]
    public IActionResult PreuzmiVozila()
    {
        (bool isError, var vozila, string? error) = DTOManager.VratiSvaVozila();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(vozila);
    }

    [HttpGet]
    [Route("PreuzmiVozilo/{registarskaOznaka}")]
    public async Task<IActionResult> PreuzmiVozilo(string registarskaOznaka)
    {
        (bool isError, var vozilo, string? error) = await DTOManager.VratiVoziloAsync(registarskaOznaka);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(vozilo);
    }

    [HttpPost]
    [Route("DodajVozilo")]
    public async Task<IActionResult> DodajVozilo([FromBody] VoziloView p)
    {
        var data = await DTOManager.DodajVoziloAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato vozilo. Oznaka: {p.RegistarskaOznaka}");
    }

    [HttpPut]
    [Route("PromeniVozilo")]
    public async Task<IActionResult> PromeniVozilo([FromBody] VoziloView p)
    {
        (bool isError, var vozilo, string? error) = await DTOManager.AzurirajVoziloAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirano vozilo. Oznaka: {vozilo.RegistarskaOznaka}");
    }

    [HttpDelete]
    [Route("IzbrisiVozilo/{registarskaOznaka}")]
    public async Task<IActionResult> IzbrisiVozilo(string registarskaOznaka)
    {
        var data = await DTOManager.ObrisiVoziloAsync(registarskaOznaka);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisano vozilo. Oznaka: {registarskaOznaka}");
    }
}
