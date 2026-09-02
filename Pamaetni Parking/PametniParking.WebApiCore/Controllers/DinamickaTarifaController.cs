using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class DinamickaTarifaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiDinamickeTarife")]
    public IActionResult PreuzmiDinamickeTarife()
    {
        (bool isError, var tarife, string? error) = DTOManager.VratiSveDinamickeTarife();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(tarife);
    }

    [HttpGet]
    [Route("PreuzmiDinamickuTarifu/{id}")]
    public async Task<IActionResult> PreuzmiDinamickuTarifu(int id)
    {
        (bool isError, var tarifa, string? error) = await DTOManager.VratiDinamickuTarifuAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(tarifa);
    }

    [HttpPost]
    [Route("DodajDinamickuTarifu")]
    public async Task<IActionResult> DodajDinamickuTarifu([FromBody] DinamickaTarifaView p)
    {
        var data = await DTOManager.DodajDinamickuTarifuAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata dinamička tarifa. Razlog: {p.RazlogPromene}");
    }

    [HttpPut]
    [Route("PromeniDinamickuTarifu")]
    public async Task<IActionResult> PromeniDinamickuTarifu([FromBody] DinamickaTarifaView p)
    {
        (bool isError, var tarifa, string? error) = await DTOManager.AzurirajDinamickuTarifuAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirana dinamička tarifa. ID: {tarifa.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiDinamickuTarifu/{id}")]
    public async Task<IActionResult> IzbrisiDinamickuTarifu(int id)
    {
        var data = await DTOManager.ObrisiDinamickuTarifuAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana dinamička tarifa. ID: {id}");
    }
}
