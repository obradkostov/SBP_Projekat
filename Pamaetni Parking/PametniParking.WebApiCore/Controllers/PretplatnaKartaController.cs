using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class PretplatnaKartaController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiKarte")]
    public IActionResult PreuzmiKarte()
    {
        (bool isError, var karte, string? error) = DTOManager.VratiSveKarte();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(karte);
    }

    [HttpGet]
    [Route("PreuzmiKartu/{id}")]
    public async Task<IActionResult> PreuzmiKartu(int id)
    {
        (bool isError, var karta, string? error) = await DTOManager.VratiKartuAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(karta);
    }

    // Telo: { "korisnikId": 1, "tipPretplate": "..", "pocetakVazenja": "..", "krajVazenja": "..",
    //         "cena": .., "maksBrVozila": .., "zoneId": [1, 2, 3] }
    [HttpPost]
    [Route("DodajKartu")]
    public async Task<IActionResult> DodajKartu([FromBody] PretplatnaKartaView p)
    {
        var data = await DTOManager.DodajKartuAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata pretplatna karta. Tip: {p.TipPretplate}");
    }

    [HttpPut]
    [Route("PromeniKartu")]
    public async Task<IActionResult> PromeniKartu([FromBody] PretplatnaKartaView p)
    {
        (bool isError, var karta, string? error) = await DTOManager.AzurirajKartuAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažurirana pretplatna karta. ID: {karta.Id}");
    }

    [HttpDelete]
    [Route("IzbrisiKartu/{id}")]
    public async Task<IActionResult> IzbrisiKartu(int id)
    {
        var data = await DTOManager.ObrisiKartuAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana pretplatna karta. ID: {id}");
    }
}