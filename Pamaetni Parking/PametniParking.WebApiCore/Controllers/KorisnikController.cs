using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class KorisnikController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiKorisnike")]
    public IActionResult PreuzmiKorisnike()
    {
        (bool isError, var korisnici, string? error) = DTOManager.VratiSveKorisnike();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(korisnici);
    }

    [HttpGet]
    [Route("PreuzmiKorisnika/{id}")]
    public async Task<IActionResult> PreuzmiKorisnika(int id)
    {
        (bool isError, var korisnik, string? error) = await DTOManager.VratiKorisnikaAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(korisnik);
    }

    [HttpPost]
    [Route("DodajFizickoLice")]
    public async Task<IActionResult> DodajFizickoLice([FromBody] KorisnikView p)
    {
        var data = await DTOManager.DodajFizickoLiceAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato fizičko lice. Email: {p.Email}");
    }

    [HttpPost]
    [Route("DodajPravnoLice")]
    public async Task<IActionResult> DodajPravnoLice([FromBody] KorisnikView p)
    {
        var data = await DTOManager.DodajPravnoLiceAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodato pravno lice. Email: {p.Email}");
    }

    [HttpPut]
    [Route("PromeniKorisnika")]
    public async Task<IActionResult> PromeniKorisnika([FromBody] KorisnikView p)
    {
        (bool isError, var korisnik, string? error) = await DTOManager.AzurirajKorisnikaAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažuriran korisnik. Email: {korisnik.Email}");
    }

    [HttpDelete]
    [Route("IzbrisiKorisnika/{id}")]
    public async Task<IActionResult> IzbrisiKorisnika(int id)
    {
        var data = await DTOManager.ObrisiKorisnikaAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan korisnik. ID: {id}");
    }
}
