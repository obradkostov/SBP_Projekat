using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingMestoController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiParkingMesta")]
    public IActionResult PreuzmiParkingMesta()
    {
        (bool isError, var mesta, string? error) = DTOManager.VratiSvaPM();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(mesta);
    }

    [HttpGet]
    [Route("PreuzmiParkingMesto/{id}")]
    public async Task<IActionResult> PreuzmiParkingMesto(int id)
    {
        (bool isError, var mesto, string? error) = await DTOManager.VratiPMAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(mesto);
    }

    // Za tipove bez dodatnih atributa: standardna, rezervisana, stanari, dostavna_vozila, taxi
    [HttpPost]
    [Route("DodajParkingMesto")]
    public async Task<IActionResult> DodajParkingMesto([FromBody] ParkingMestoView p)
    {
        var data = await DTOManager.DodajPMAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato parking mesto. Oznaka: {p.OznakaMesta}");
    }

    [HttpPost]
    [Route("DodajParkingMestoInvaliditet")]
    public async Task<IActionResult> DodajParkingMestoInvaliditet([FromBody] ParkingMestoView p)
    {
        var data = await DTOManager.DodajPMInvaliditetAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato parking mesto za osobe sa invaliditetom. Oznaka: {p.OznakaMesta}");
    }

    [HttpPost]
    [Route("DodajParkingMestoPunjac")]
    public async Task<IActionResult> DodajParkingMestoPunjac([FromBody] ParkingMestoView p)
    {
        var data = await DTOManager.DodajPMPunjacAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato parking mesto sa punjačem. Oznaka: {p.OznakaMesta}");
    }

    [HttpPut]
    [Route("PromeniParkingMesto")]
    public async Task<IActionResult> PromeniParkingMesto([FromBody] ParkingMestoView p)
    {
        (bool isError, var mesto, string? error) = await DTOManager.AzurirajPMAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirano parking mesto. Oznaka: {mesto.OznakaMesta}");
    }

    [HttpDelete]
    [Route("IzbrisiParkingMesto/{id}")]
    public async Task<IActionResult> IzbrisiParkingMesto(int id)
    {
        var data = await DTOManager.ObrisiPMAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisano parking mesto. ID: {id}");
    }
}
