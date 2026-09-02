using Microsoft.AspNetCore.Mvc;
using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.WebApiCore.Controllers;

[ApiController]
[Route("[controller]")]
public class DogadjajController : ControllerBase
{
    [HttpGet]
    [Route("PreuzmiDogadjaje")]
    public IActionResult PreuzmiDogadjaje()
    {
        (bool isError, var dogadjaji, string? error) = DTOManager.VratiSveDogadjaje();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(dogadjaji);
    }

    [HttpGet]
    [Route("PreuzmiDogadjaj/{id}")]
    public async Task<IActionResult> PreuzmiDogadjaj(int id)
    {
        (bool isError, var dogadjaj, string? error) = await DTOManager.VratiDogadjajAsync(id);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(dogadjaj);
    }

    [HttpPost]
    [Route("DodajDogadjaj")]
    public async Task<IActionResult> DodajDogadjaj([FromBody] DogadjajView p)
    {
        var data = await DTOManager.DodajDogadjajAsync(p);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodat događaj. Redni broj: {p.RedniBroj}");
    }

    [HttpPut]
    [Route("PromeniDogadjaj")]
    public async Task<IActionResult> PromeniDogadjaj([FromBody] DogadjajView p)
    {
        (bool isError, var dogadjaj, string? error) = await DTOManager.AzurirajDogadjajAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok($"Uspešno ažuriran događaj. Redni broj: {dogadjaj.RedniBroj}");
    }

    [HttpDelete]
    [Route("IzbrisiDogadjaj/{id}")]
    public async Task<IActionResult> IzbrisiDogadjaj(int id)
    {
        var data = await DTOManager.ObrisiDogadjajAsync(id);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisan događaj. ID: {id}");
    }
}
