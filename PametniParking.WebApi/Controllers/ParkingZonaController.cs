using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class ParkingZonaController : ApiController
    {
        // GET api/ParkingZona
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var zone = session.Query<ParkingZona>().ToList();
                return Ok(zone);
            }
        }

        // GET api/ParkingZona/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var zona = session.Get<ParkingZona>(id);
                if (zona == null)
                    return NotFound();

                return Ok(zona);
            }
        }

        // POST api/ParkingZona
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] ParkingZona zona)
        {
            if (zona == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(zona);
                    transaction.Commit();
                }
                return Ok(zona);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/ParkingZona/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] ParkingZona zona)
        {
            if (zona == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojeca = session.Get<ParkingZona>(id);
                    if (postojeca == null)
                        return NotFound();

                    postojeca.Naziv = zona.Naziv;
                    postojeca.GeografskoPodrucje = zona.GeografskoPodrucje;
                    postojeca.TipZone = zona.TipZone;
                    postojeca.OsnovnaTarifa = zona.OsnovnaTarifa;
                    postojeca.MaxVremeZadrzavanja = zona.MaxVremeZadrzavanja;
                    postojeca.PravilaNaplate = zona.PravilaNaplate;

                    session.Update(postojeca);
                    transaction.Commit();

                    return Ok(postojeca);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/ParkingZona/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var zona = session.Get<ParkingZona>(id);
                    if (zona == null)
                        return NotFound();

                    session.Delete(zona);
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