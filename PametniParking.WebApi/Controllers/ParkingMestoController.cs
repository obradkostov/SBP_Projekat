using NHibernate;
using NHibernate.Linq;
using PametniParking;
using PametniParking.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PametniParking.WebApi.Controllers
{
    public class ParkingMestoController : ApiController
    {
        // GET api/ParkingMesto
        [HttpGet]
        public IHttpActionResult GetSve()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var mesta = session.Query<ParkingMesto>().ToList();
                return Ok(mesta);
            }
        }

        // GET api/ParkingMesto/5
        [HttpGet]
        public IHttpActionResult GetPoId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var mesto = session.Get<ParkingMesto>(id);
                if (mesto == null)
                    return NotFound();

                return Ok(mesto);
            }
        }

        // POST api/ParkingMesto
        // Koristi se za tipove bez dodatnih atributa: standardna, rezervisana, stanari, dostavna_vozila, taxi
        [HttpPost]
        public IHttpActionResult Dodaj([FromBody] ParkingMesto mesto)
        {
            if (mesto == null || string.IsNullOrWhiteSpace(mesto.OznakaMesta))
                return BadRequest("Oznaka mesta je obavezna.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(mesto);
                    transaction.Commit();
                }
                return Ok(mesto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/ParkingMesto/Invaliditet
        // Telo: { "mesto": { ... }, "nivoPristupacnosti": "..." }
        [HttpPost]
        [Route("api/ParkingMesto/Invaliditet")]
        public IHttpActionResult DodajInvaliditet([FromBody] MestoOsobaSaInvaliditetomZahtev zahtev)
        {
            if (zahtev == null || zahtev.Mesto == null || string.IsNullOrWhiteSpace(zahtev.Mesto.OznakaMesta))
                return BadRequest("Podaci o parking mestu su obavezni.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(zahtev.Mesto);

                    var prosireno = new MestoOsobaSaInvaliditetom
                    {
                        ParkingMesto = zahtev.Mesto,
                        NivoPristupacnosti = zahtev.NivoPristupacnosti
                    };
                    session.Save(prosireno);

                    transaction.Commit();
                }
                return Ok(zahtev.Mesto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/ParkingMesto/Punjac
        // Telo: { "mesto": { ... }, "snagaPunjaca": .., "tipKonektora": "..", "brojPrikljucaka": .., "rezimiPunjenja": ".." }
        [HttpPost]
        [Route("api/ParkingMesto/Punjac")]
        public IHttpActionResult DodajPunjac([FromBody] MestoSaPunjacemZahtev zahtev)
        {
            if (zahtev == null || zahtev.Mesto == null || string.IsNullOrWhiteSpace(zahtev.Mesto.OznakaMesta))
                return BadRequest("Podaci o parking mestu su obavezni.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(zahtev.Mesto);

                    var prosireno = new MestoSaPunjacem
                    {
                        ParkingMesto = zahtev.Mesto,
                        SnagaPunjaca = zahtev.SnagaPunjaca,
                        TipKonektora = zahtev.TipKonektora,
                        BrojPrikljucaka = zahtev.BrojPrikljucaka,
                        RezimiPunjenja = zahtev.RezimiPunjenja
                    };
                    session.Save(prosireno);

                    transaction.Commit();
                }
                return Ok(zahtev.Mesto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/ParkingMesto/5
        [HttpPut]
        public IHttpActionResult Izmeni(int id, [FromBody] ParkingMesto mesto)
        {
            if (mesto == null)
                return BadRequest("Telo zahteva ne sme biti prazno.");

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var postojece = session.Get<ParkingMesto>(id);
                    if (postojece == null)
                        return NotFound();

                    postojece.OznakaMesta = mesto.OznakaMesta;
                    postojece.GeografakaLokacija = mesto.GeografakaLokacija;
                    postojece.Status = mesto.Status;
                    postojece.TipMesta = mesto.TipMesta;
                    postojece.DozDuzina = mesto.DozDuzina;
                    postojece.Natkrivenost = mesto.Natkrivenost;
                    postojece.KameraSenzor = mesto.KameraSenzor;

                    if (mesto.Zona != null)
                    {
                        var zona = session.Get<ParkingZona>(mesto.Zona.Id);
                        postojece.Zona = zona;
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

        // DELETE api/ParkingMesto/5
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var mesto = session.Get<ParkingMesto>(id);
                    if (mesto == null)
                        return NotFound();

                    session.Delete(mesto);
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

    // Pomocne DTO klase samo za primanje kombinovanog JSON tela (mesto + dodatni atributi)
    public class MestoOsobaSaInvaliditetomZahtev
    {
        public ParkingMesto Mesto { get; set; }
        public string NivoPristupacnosti { get; set; }
    }

    public class MestoSaPunjacemZahtev
    {
        public ParkingMesto Mesto { get; set; }
        public decimal SnagaPunjaca { get; set; }
        public string TipKonektora { get; set; }
        public int BrojPrikljucaka { get; set; }
        public string RezimiPunjenja { get; set; }
    }
}