using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class SenzorController : ApiController
    {
        // GET api/Senzor
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var senzori = session.Query<Senzor>().ToList();
                return Ok(senzori);
            }
        }

        // GET api/Senzor/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var senzor = session.Get<Senzor>(id);
                if (senzor == null)
                    return NotFound();

                return Ok(senzor);
            }
        }

        // POST api/Senzor
        // Koristi se za tipove bez dodatnih atributa: magnetni, ultrazvucni, opticki, kombinovani
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] Senzor senzor)
        {
            if (senzor == null || string.IsNullOrWhiteSpace(senzor.SerijskiBroj))
                return BadRequest("Serijski broj je obavezan.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(senzor);
                    transaction.Commit();
                }
                return Ok(senzor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/Senzor/Video
        // Telo: { "senzor": { ... }, "rezolucija": "..", "ugaoPokrivanja": .., "prepRegOznaka": 'D' }
        [HttpPost]
        [Route("api/Senzor/Video")]
        public IHttpActionResult DodajVideo([FromBody] VideoSenzorZahtev zahtev)
        {
            if (zahtev == null || zahtev.Senzor == null || string.IsNullOrWhiteSpace(zahtev.Senzor.SerijskiBroj))
                return BadRequest("Podaci o senzoru su obavezni.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(zahtev.Senzor);

                    var video = new VideoSenzor
                    {
                        Senzor = zahtev.Senzor,
                        Rezolucija = zahtev.Rezolucija,
                        UgaoPokrivanja = zahtev.UgaoPokrivanja,
                        PrepRegOznaka = zahtev.PrepRegOznaka
                    };
                    session.Save(video);

                    transaction.Commit();
                }
                return Ok(zahtev.Senzor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/Senzor/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] Senzor senzor)
        {
            if (senzor == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojeci = session.Get<Senzor>(id);
                    if (postojeci == null)
                        return NotFound();

                    postojeci.Proizvodjac = senzor.Proizvodjac;
                    postojeci.Model = senzor.Model;
                    postojeci.SerijskiBroj = senzor.SerijskiBroj;
                    postojeci.DatumInstalacije = senzor.DatumInstalacije;
                    postojeci.Status = senzor.Status;
                    postojeci.TipSenzora = senzor.TipSenzora;

                    if (senzor.ParkingMesto != null)
                    {
                        var mesto = session.Get<ParkingMesto>(senzor.ParkingMesto.Id);
                        postojeci.ParkingMesto = mesto;
                    }

                    session.Update(postojeci);
                    transaction.Commit();

                    return Ok(postojeci);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/Senzor/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var senzor = session.Get<Senzor>(id);
                    if (senzor == null)
                        return NotFound();

                    session.Delete(senzor);
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

    // Pomocna DTO klasa samo za primanje kombinovanog JSON tela (senzor + video atributi)
    public class VideoSenzorZahtev
    {
        public Senzor Senzor { get; set; }
        public string Rezolucija { get; set; }
        public decimal UgaoPokrivanja { get; set; }
        public char PrepRegOznaka { get; set; }
    }
}