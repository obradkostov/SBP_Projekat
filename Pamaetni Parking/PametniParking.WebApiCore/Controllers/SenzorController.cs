using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class SenzorController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiSenzore")]
    public IActionResult PreuzmiSenzore()
    {
        (bool isError, var senzori, string? error) = DTOManager.VratiSveSenzore();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(senzori);
    }

    [HttpGet]
    [Route("PreuzmiSenzor/{id}")]
    public async Task<IActionResult> PreuzmiSenzor(int id)
    {
        (bool isError, var senzor, string? error) = await DTOManager.VratiSenzorAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(senzor);
    }

    // Za tipove bez dodatnih atributa: magnetni, ultrazvucni, opticki, kombinovani
    [HttpPost]
    [Route("DodajSenzor")]
    public async Task<IActionResult> DodajSenzor([FromBody] SenzorView p)
    {
        var data = await DTOManager.DodajSenzorAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodat senzor. Serijski broj: {p.SerijskiBroj}");
    }

    [HttpPost]
    [Route("DodajVideoSenzor")]
    public async Task<IActionResult> DodajVideoSenzor([FromBody] SenzorView p)
    {
        var data = await DTOManager.DodajVideoSenzorAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodat video senzor. Serijski broj: {p.SerijskiBroj}");
    }

    [HttpPut]
    [Route("PromeniSenzor")]
    public async Task<IActionResult> PromeniSenzor([FromBody] SenzorView p)
    {
        (bool isError, var senzor, string? error) = await DTOManager.AzurirajSenzorAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažuriran senzor. Serijski broj: {senzor.SerijskiBroj}");
    }

    [HttpDelete]
    [Route("IzbrisiSenzor/{id}")]
    public async Task<IActionResult> IzbrisiSenzor(int id)
    {
        var data = await DTOManager.ObrisiSenzorAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan senzor. ID: {id}");
    }
}
