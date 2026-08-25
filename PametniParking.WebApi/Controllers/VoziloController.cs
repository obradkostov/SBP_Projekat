using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class VoziloController : ApiController
    {
        // GET api/Vozilo
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vozila = session.Query<Vozilo>().ToList();
                return Ok(vozila);
            }
        }

        // GET api/Vozilo/NI555ZZ
        [HttpGet]
        public IHttpActionResult GetPoOznaci(string id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var vozilo = session.Get<Vozilo>(id);
                if (vozilo == null)
                    return NotFound();

                return Ok(vozilo);
            }
        }

        // POST api/Vozilo
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] Vozilo vozilo)
        {
            if (vozilo == null || string.IsNullOrWhiteSpace(vozilo.RegistarskaOznaka))
                return BadRequest("Registarska oznaka je obavezna.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(vozilo);
                    transaction.Commit();
                }
                return Ok(vozilo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/Vozilo/NI555ZZ
        [HttpPut]
        public IHttpActionResult Izmeni(string id, [FromBody] Vozilo vozilo)
        {
            if (vozilo == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojece = session.Get<Vozilo>(id);
                    if (postojece == null)
                        return NotFound();

                    postojece.DrzavaRegistracije = vozilo.DrzavaRegistracije;
                    postojece.Marka = vozilo.Marka;
                    postojece.Model = vozilo.Model;
                    postojece.TipVozila = vozilo.TipVozila;
                    postojece.Dimenzije = vozilo.Dimenzije;
                    postojece.Pogon = vozilo.Pogon;

                    if (vozilo.Korisnik != null)
                    {
                        var korisnik = session.Get<Korisnik>(vozilo.Korisnik.Id);
                        postojece.Korisnik = korisnik;
                    }
                    else
                    {
                        postojece.Korisnik = null;
                    }

                    session.Update(postojece);
                    transaction.Commit();

                    return Ok(postojece);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/Vozilo/NI555ZZ
        [HttpDelete]
        public IHttpActionResult Obrisi(string id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var vozilo = session.Get<Vozilo>(id);
                    if (vozilo == null)
                        return NotFound();

                    session.Delete(vozilo);
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