using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class ParkingMestoMap:ClassMap<ParkingMesto>
    {
        public ParkingMestoMap()
        {
            Table("PARKING_MESTO");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.OznakaMesta).Column("OZNAKA_MESTA");
            Map(x => x.GeografakaLokacija).Column("GEOGRAFSKA_LOKACIJA");
            Map(x => x.Status).Column("STATUS");
            Map(x => x.TipMesta).Column("TIP_MESTA");
            Map(x => x.DozDuzina).Column("DOZ_DUZINA");
            Map(x => x.Natkrivenost).Column("NATKRIVENOST");
            Map(x => x.KameraSenzor).Column("KAMERA_SENZOR");
            References(x => x.Zona).Column("ZONA_ID").Cascade.All();
            HasMany(x => x.Senzori).KeyColumn("PARKING_MESTO_ID").Cascade.All().Inverse();
        }
    }
}
