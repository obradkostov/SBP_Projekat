using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class PretplatnaKartaMap:ClassMap<PretplatnaKarta>
    {
        public PretplatnaKartaMap()
        {
            Table("PRETPLATNA_KARTA");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.TipPretplate).Column("TIP_PRETPLATE");
            Map(x => x.PocetakVazenja).Column("POCETAK_VAZENJA");
            Map(x => x.KrajVazenja).Column("KRAJ_VAZENJA");
            Map(x => x.Cena).Column("CENA");
            Map(x => x.MaksBrVozila).Column("MAX_BR_VOZILA");
            References(x => x.Korisnik).Column("KORISNIK_ID").Cascade.All();
            HasMany(x => x.Zone).KeyColumn("KARTA_ID").Cascade.All().Inverse();
        }
    }
}
