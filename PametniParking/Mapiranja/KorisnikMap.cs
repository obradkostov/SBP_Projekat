using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class KorisnikMap:ClassMap<Korisnik>
    {
        public KorisnikMap()
        {
            Table("KORISNIK");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Adresa).Column("ADRESA");
            Map(x => x.StatusNaloga).Column("STATUS_NALOGA");
            HasMany(x => x.Telefoni).KeyColumn("KORISNIK_ID").Cascade.All().Inverse();
            HasMany(x => x.Vozila).KeyColumn("KORISNIK_ID").Cascade.All().Inverse();
            HasMany(x => x.PretplatneKarte).KeyColumn("KORISNIK_ID").Cascade.All().Inverse();
        }
    }
}
