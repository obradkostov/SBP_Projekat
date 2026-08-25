using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class ParkiranjeMap : ClassMap<Parkiranje>
    {
        public ParkiranjeMap()
        {
            Table("S19702.PARKIRANJE");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.DatumVremePocetka).Column("DATUM_VREME_POCETKA");
            Map(x => x.ObracunatiIznos).Column("OBRACUNATI_IZNOS");
            References(x => x.Vozilo).Column("REGISTARSKA_OZNAKA").Not.LazyLoad();
            References(x => x.ParkingMesto).Column("PARKING_MESTO_ID").Not.LazyLoad();
            References(x => x.Zona).Column("ZONA_ID").Not.LazyLoad();
            References(x => x.Karta).Column("KARTA_ID").Nullable().Not.LazyLoad();
        }
    }
}
