using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class VoziloMap:ClassMap<Vozilo>
    {
        public VoziloMap()
        {
            Table("VOZILO");
            Id(x => x.RegistarskaOznaka).Column("REGISTARSKA_OZNAKA").GeneratedBy.Assigned().CustomType<string>();
            Map(x => x.DrzavaRegistracije).Column("DRZAVA_REGISTRACIJE");
            Map(x => x.Marka).Column("MARKA");
            Map(x => x.Model).Column("MODEL");
            Map(x => x.TipVozila).Column("TIP_VOZILA");
            Map(x => x.Dimenzije).Column("DIMENZIJE");
            Map(x => x.Pogon).Column("POGON");
            References(x => x.Korisnik).Column("KORISNIK_ID").Cascade.All();
        }
    }
}
