using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class TelefonController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiTelefone")]
    public IActionResult PreuzmiTelefone()
    {
        (bool isError, var telefoni, string? error) = DTOManager.VratiSveTelefone();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(telefoni);
    }

    [HttpGet]
    [Route("PreuzmiTelefon/{id}")]
    public async Task<IActionResult> PreuzmiTelefon(int id)
    {
        (bool isError, var telefon, string? error) = await DTOManager.VratiTelefonAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(telefon);
    }

    [HttpPost]
    [Route("DodajTelefon")]
    public async Task<IActionResult> DodajTelefon([FromBody] TelefonView p)
    {
        var data = await DTOManager.DodajTelefonAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodat telefon. Broj: {p.BrojTelefona}");
    }

    [HttpPut]
    [Route("PromeniTelefon")]
    public async Task<IActionResult> PromeniTelefon([FromBody] TelefonView p)
    {
        (bool isError, var telefon, string? error) = await DTOManager.AzurirajTelefonAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažuriran telefon. Broj: {telefon.BrojTelefona}");
    }

    [HttpDelete]
    [Route("IzbrisiTelefon/{id}")]
    public async Task<IActionResult> IzbrisiTelefon(int id)
    {
        var data = await DTOManager.ObrisiTelefonAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan telefon. ID: {id}");
    }
}
