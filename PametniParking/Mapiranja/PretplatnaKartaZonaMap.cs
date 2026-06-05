using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PretplatnaKartaZonaMap:ClassMap<PretplatnaKartaZona>
    {
        public PretplatnaKartaZonaMap()
        {
            Table("PRETPLATNA_KARTA_ZONA");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            References(x => x.Karta).Column("KARTA_ID").Cascade.All();
            References(x => x.Zona).Column("ZONA_ID").Cascade.All();
        }
    }
}
