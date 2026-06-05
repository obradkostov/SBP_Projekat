using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class ParkiranjeMap:ClassMap<Parkiranje>
    {
        public ParkiranjeMap()
        {
            Table("PARKIRANJE");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.DatumVremePocetka).Column("DATUM_VREME_POCETKA");
            Map(x => x.ObracunatiIznos).Column("OBRACUNATI_IZNOS");
            References(x => x.Vozilo).Column("VOZILO_ID").Cascade.All();
            References(x => x.ParkingMesto).Column("PARKING_MESTO_ID").Cascade.All();
            References(x => x.Zona).Column("ZONA_ID").Cascade.All();
            References(x => x.Karta).Column("KARTA_ID").Cascade.All();
        }
    }
}
