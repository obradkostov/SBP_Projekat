using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class SenzorMap : ClassMap<Senzor>
    {
        public SenzorMap()
        {
            Table("S19702.SENZOR");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.Proizvodjac).Column("PROIZVODJAC");
            Map(x => x.Model).Column("MODEL");
            Map(x => x.SerijskiBroj).Column("SERIJSKI_BROJ");
            Map(x => x.DatumInstalacije).Column("DATUM_INSTALACIJE");
            Map(x => x.Status).Column("STATUS");
            Map(x => x.TipSenzora).Column("TIP_SENZORA");
            References(x => x.ParkingMesto).Column("PARKING_MESTO_ID");
            HasMany(x => x.Dogadjaji).KeyColumn("SENZOR_ID").Cascade.All().Inverse();
        }
    }
}
