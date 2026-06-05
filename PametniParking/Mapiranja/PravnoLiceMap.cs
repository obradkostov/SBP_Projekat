using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PravnoLiceMap:ClassMap<PravnoLice>
    {
        public PravnoLiceMap()
        {
            Table("PRAVNO_LICE");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.Pib).Column("PIB");
            Map(x => x.MaticniBroj).Column("MATICNI_BROJ");
            Map(x => x.KontaktOsoba).Column("KONTAKT_OSOBA");
            Map(x => x.Sediste).Column("SEDISTE");
        }
    }
}
