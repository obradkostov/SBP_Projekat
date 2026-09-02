using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class FiksnaTarifaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiFiksneTarife")]
    public IActionResult PreuzmiFiksneTarife()
    {
        (bool isError, var tarife, string? error) = DTOManager.VratiSveFiksneTarife();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(tarife);
    }

    [HttpGet]
    [Route("PreuzmiFiksnuTarifu/{id}")]
    public async Task<IActionResult> PreuzmiFiksnuTarifu(int id)
    {
        (bool isError, var tarifa, string? error) = await DTOManager.VratiFiksnuTarifuAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(tarifa);
    }

    [HttpPost]
    [Route("DodajFiksnuTarifu")]
    public async Task<IActionResult> DodajFiksnuTarifu([FromBody] FiksnaTarifaView p)
    {
        var data = await DTOManager.DodajFiksnuTarifuAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata fiksna tarifa. Interval: {p.NazivIntervala}");
    }

    [HttpPut]
    [Route("PromeniFiksnuTarifu")]
    public async Task<IActionResult> PromeniFiksnuTarifu([FromBody] FiksnaTarifaView p)
    {
        (bool isError, var tarifa, string? error) = await DTOManager.AzurirajFiksnuTarifuAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirana fiksna tarifa. ID: {tarifa.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiFiksnuTarifu/{id}")]
    public async Task<IActionResult> IzbrisiFiksnuTarifu(int id)
    {
        var data = await DTOManager.ObrisiFiksnuTarifuAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana fiksna tarifa. ID: {id}");
    }
}
