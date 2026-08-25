using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PretplatnaKartaMap : ClassMap<PretplatnaKarta>
    {
        public PretplatnaKartaMap()
        {
            Table("S19702.PRETPLATNA_KARTA");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.TipPretplate).Column("TIP_PRETPLATE");
            Map(x => x.PocetakVazenja).Column("POCETAK_VAZENJA");
            Map(x => x.KrajVazenja).Column("KRAJ_VAZENJA");
            Map(x => x.Cena).Column("CENA");
            Map(x => x.MaksBrVozila).Column("MAKS_BR_VOZILA");
            References(x => x.Korisnik).Column("KORISNIK_ID").Not.LazyLoad();
            HasMany(x => x.Zone).KeyColumn("KARTA_ID").Cascade.All().Inverse();
        }
    }
}
