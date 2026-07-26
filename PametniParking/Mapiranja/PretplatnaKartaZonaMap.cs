using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PretplatnaKartaZonaMap : ClassMap<PretplatnaKartaZona>
    {
        public PretplatnaKartaZonaMap()
        {
            Table("S19702.PRETPLATNA_KARTA_ZONE");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            References(x => x.Karta).Column("KARTA_ID");
            References(x => x.Zona).Column("ZONA_ID");
        }
    }
}
