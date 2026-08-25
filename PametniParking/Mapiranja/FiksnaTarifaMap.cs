using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class FiksnaTarifaMap : ClassMap<FiksnaTarifa>
    {
        public FiksnaTarifaMap()
        {
            Table("S19702.FIKSNA_TARIFA");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.TipDana).Column("TIP_DANA");
            Map(x => x.NazivIntervala).Column("NAZIV_INTERVALA");
            Map(x => x.VremeOd).Column("VREME_OD");
            Map(x => x.VremeDo).Column("VREME_DO");
            Map(x => x.IznosTarife).Column("IZNOS_TARIFE");
            References(x => x.Zona).Column("ZONA_ID").Not.LazyLoad();
        }
    }
}