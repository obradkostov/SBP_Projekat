using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class DogadjajController : ApiController
    {
        // GET api/Dogadjaj
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var dogadjaji = session.Query<Dogadjaj>().ToList();
                return Ok(dogadjaji);
            }
        }

        // GET api/Dogadjaj/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var dogadjaj = session.Get<Dogadjaj>(id);
                if (dogadjaj == null)
                    return NotFound();

                return Ok(dogadjaj);
            }
        }

        // POST api/Dogadjaj
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] Dogadjaj dogadjaj)
        {
            if (dogadjaj == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(dogadjaj);
                    transaction.Commit();
                }
                return Ok(dogadjaj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/Dogadjaj/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] Dogadjaj dogadjaj)
        {
            if (dogadjaj == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojeci = session.Get<Dogadjaj>(id);
                    if (postojeci == null)
                        return NotFound();

                    postojeci.RedniBroj = dogadjaj.RedniBroj;
                    postojeci.TipDogadjaja = dogadjaj.TipDogadjaja;
                    postojeci.VremeNastanka = dogadjaj.VremeNastanka;
                    postojeci.OcitanaVrednost = dogadjaj.OcitanaVrednost;
                    postojeci.NivoPouzdanosti = dogadjaj.NivoPouzdanosti;
                    postojeci.Potvrda = dogadjaj.Potvrda;

                    if (dogadjaj.Senzor != null)
                    {
                        var senzor = session.Get<Senzor>(dogadjaj.Senzor.Id);
                        postojeci.Senzor = senzor;
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

        // DELETE api/Dogadjaj/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var dogadjaj = session.Get<Dogadjaj>(id);
                    if (dogadjaj == null)
                        return NotFound();

                    session.Delete(dogadjaj);
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