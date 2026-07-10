using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PravnoLiceMap:SubclassMap<PravnoLice>
    {
        public PravnoLiceMap()
        {
            Table("PRAVNO_LICE");
            KeyColumn("KORISNIK_ID");
            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.Pib).Column("PIB");
            Map(x => x.MaticniBroj).Column("MATICNI_BROJ");
            Map(x => x.KontaktOsoba).Column("KONTAKT_OSOBA");
            Map(x => x.Sediste).Column("SEDISTE");
        }
    }
}
