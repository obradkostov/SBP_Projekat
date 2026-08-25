using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class PretplatnaKartaController : ApiController
    {
        // GET api/PretplatnaKarta
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var karte = session.Query<PretplatnaKarta>().ToList();
                return Ok(karte);
            }
        }

        // GET api/PretplatnaKarta/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var karta = session.Get<PretplatnaKarta>(id);
                if (karta == null)
                    return NotFound();

                return Ok(karta);
            }
        }

        // POST api/PretplatnaKarta
        // Telo: { "karta": { "korisnik": {"id": 1}, "tipPretplate": "..", ... }, "zoneId": [1, 2, 3] }
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] PretplatnaKartaZahtev zahtev)
        {
            if (zahtev == null || zahtev.Karta == null || zahtev.Karta.Korisnik == null)
                return BadRequest("Podaci o pretplatnoj karti i korisniku su obavezni.");

            if (zahtev.ZoneId == null || zahtev.ZoneId.Count == 0)
                return BadRequest("Potrebno je izabrati bar jednu zonu.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var korisnik = session.Get<Korisnik>(zahtev.Karta.Korisnik.Id);
                    if (korisnik == null)
                        return BadRequest("Korisnik ne postoji.");

                    zahtev.Karta.Korisnik = korisnik;
                    session.Save(zahtev.Karta);

                    foreach (var zonaId in zahtev.ZoneId)
                    {
                        var zona = session.Get<ParkingZona>(zonaId);
                        if (zona == null) continue;

                        var veza = new PretplatnaKartaZona { Karta = zahtev.Karta, Zona = zona };
                        session.Save(veza);
                    }

                    transaction.Commit();
                }
                return Ok(zahtev.Karta);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/PretplatnaKarta/5
        // Telo: { "karta": { ... }, "zoneId": [1, 2] }
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] PretplatnaKartaZahtev zahtev)
        {
            if (zahtev == null || zahtev.Karta == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojeca = session.Get<PretplatnaKarta>(id);
                    if (postojeca == null)
                        return NotFound();

                    postojeca.TipPretplate = zahtev.Karta.TipPretplate;
                    postojeca.PocetakVazenja = zahtev.Karta.PocetakVazenja;
                    postojeca.KrajVazenja = zahtev.Karta.KrajVazenja;
                    postojeca.Cena = zahtev.Karta.Cena;
                    postojeca.MaksBrVozila = zahtev.Karta.MaksBrVozila;

                    if (zahtev.Karta.Korisnik != null)
                        postojeca.Korisnik = session.Get<Korisnik>(zahtev.Karta.Korisnik.Id);

                    session.Update(postojeca);

                    if (zahtev.ZoneId != null)
                    {
                        var stareVeze = session.Query<PretplatnaKartaZona>()
                            .Where(z => z.Karta.Id == postojeca.Id)
                            .ToList();
                        foreach (var stara in stareVeze)
                            session.Delete(stara);

                        foreach (var zonaId in zahtev.ZoneId)
                        {
                            var zona = session.Get<ParkingZona>(zonaId);
                            if (zona == null) continue;

                            var veza = new PretplatnaKartaZona { Karta = postojeca, Zona = zona };
                            session.Save(veza);
                        }
                    }

                    transaction.Commit();
                    return Ok(postojeca);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/PretplatnaKarta/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var stareVeze = session.Query<PretplatnaKartaZona>()
                        .Where(z => z.Karta.Id == id)
                        .ToList();
                    foreach (var stara in stareVeze)
                        session.Delete(stara);

                    var karta = session.Get<PretplatnaKarta>(id);
                    if (karta == null)
                        return NotFound();

                    session.Delete(karta);
                    transaction.Commit();

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

    // Pomocna DTO klasa za primanje karte zajedno sa listom izabranih zona
    public class PretplatnaKartaZahtev
    {
        public PretplatnaKarta Karta { get; set; }
        public List<int> ZoneId { get; set; }
    }
}