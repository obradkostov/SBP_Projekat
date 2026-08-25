using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class ParkiranjeController : ApiController
    {
        // GET api/Parkiranje
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var parkiranja = session.Query<Parkiranje>().ToList();
                return Ok(parkiranja);
            }
        }

        // GET api/Parkiranje/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var parkiranje = session.Get<Parkiranje>(id);
                if (parkiranje == null)
                    return NotFound();

                return Ok(parkiranje);
            }
        }

        // POST api/Parkiranje
        // Telo: { "vozilo": { "registarskaOznaka": "NI555ZZ" }, "parkingMesto": { "id": 1 }, "zona": { "id": 1 }, "datumVremePocetka": "...", "obracunatiIznos": .., "karta": null ili { "id": .. } }
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] Parkiranje parkiranje)
        {
            if (parkiranje == null || parkiranje.Vozilo == null || parkiranje.ParkingMesto == null || parkiranje.Zona == null)
                return BadRequest("Vozilo, parking mesto i zona su obavezni.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var vozilo = session.Get<Vozilo>(parkiranje.Vozilo.RegistarskaOznaka);
                    var mesto = session.Get<ParkingMesto>(parkiranje.ParkingMesto.Id);
                    var zona = session.Get<ParkingZona>(parkiranje.Zona.Id);

                    if (vozilo == null || mesto == null || zona == null)
                        return BadRequest("Vozilo, parking mesto ili zona ne postoje.");

                    parkiranje.Vozilo = vozilo;
                    parkiranje.ParkingMesto = mesto;
                    parkiranje.Zona = zona;

                    if (parkiranje.Karta != null)
                    {
                        var karta = session.Get<PretplatnaKarta>(parkiranje.Karta.Id);
                        parkiranje.Karta = karta;
                    }

                    session.Save(parkiranje);
                    transaction.Commit();
                }
                return Ok(parkiranje);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/Parkiranje/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] Parkiranje parkiranje)
        {
            if (parkiranje == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojece = session.Get<Parkiranje>(id);
                    if (postojece == null)
                        return NotFound();

                    postojece.DatumVremePocetka = parkiranje.DatumVremePocetka;
                    postojece.ObracunatiIznos = parkiranje.ObracunatiIznos;

                    if (parkiranje.Vozilo != null)
                        postojece.Vozilo = session.Get<Vozilo>(parkiranje.Vozilo.RegistarskaOznaka);

                    if (parkiranje.ParkingMesto != null)
                        postojece.ParkingMesto = session.Get<ParkingMesto>(parkiranje.ParkingMesto.Id);

                    if (parkiranje.Zona != null)
                        postojece.Zona = session.Get<ParkingZona>(parkiranje.Zona.Id);

                    postojece.Karta = parkiranje.Karta != null
                        ? session.Get<PretplatnaKarta>(parkiranje.Karta.Id)
                        : null;

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

        // DELETE api/Parkiranje/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var parkiranje = session.Get<Parkiranje>(id);
                    if (parkiranje == null)
                        return NotFound();

                    session.Delete(parkiranje);
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