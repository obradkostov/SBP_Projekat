using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class KorisnikController : ApiController
    {
        // GET api/Korisnik
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var korisnici = session.Query<Korisnik>().ToList();
                return Ok(korisnici);
            }
        }

        // GET api/Korisnik/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var korisnik = session.Get<Korisnik>(id);
                if (korisnik == null)
                    return NotFound();

                return Ok(korisnik);
            }
        }

        // POST api/Korisnik/FizickoLice
        [HttpPost]
        [Route("api/Korisnik/FizickoLice")]
        public IHttpActionResult DodajFizickoLice([FromBody] FizickoLice fizickoLice)
        {
            if (fizickoLice == null || string.IsNullOrWhiteSpace(fizickoLice.Email))
                return BadRequest("Email je obavezan.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(fizickoLice);
                    transaction.Commit();
                }
                return Ok(fizickoLice);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/Korisnik/PravnoLice
        [HttpPost]
        [Route("api/Korisnik/PravnoLice")]
        public IHttpActionResult DodajPravnoLice([FromBody] PravnoLice pravnoLice)
        {
            if (pravnoLice == null || string.IsNullOrWhiteSpace(pravnoLice.Email))
                return BadRequest("Email je obavezan.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(pravnoLice);
                    transaction.Commit();
                }
                return Ok(pravnoLice);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/Korisnik/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] Korisnik korisnik)
        {
            if (korisnik == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojeci = session.Get<Korisnik>(id);
                    if (postojeci == null)
                        return NotFound();

                    postojeci.Email = korisnik.Email;
                    postojeci.Adresa = korisnik.Adresa;
                    postojeci.StatusNaloga = korisnik.StatusNaloga;

                    if (postojeci is FizickoLice fl && korisnik is FizickoLice flNovo)
                    {
                        fl.Ime = flNovo.Ime;
                        fl.Prezime = flNovo.Prezime;
                        fl.Jmbg = flNovo.Jmbg;
                    }
                    else if (postojeci is PravnoLice pl && korisnik is PravnoLice plNovo)
                    {
                        pl.Naziv = plNovo.Naziv;
                        pl.Pib = plNovo.Pib;
                        pl.MaticniBroj = plNovo.MaticniBroj;
                        pl.KontaktOsoba = plNovo.KontaktOsoba;
                        pl.Sediste = plNovo.Sediste;
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

        // DELETE api/Korisnik/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var korisnik = session.Get<Korisnik>(id);
                    if (korisnik == null)
                        return NotFound();

                    session.Delete(korisnik);
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
}