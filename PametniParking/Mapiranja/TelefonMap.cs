using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class TelefonMap:ClassMap<Telefon>
    {
        public TelefonMap()
        {
            Table("TELEFON");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.BrojTelefona).Column("BROJ_TELEFONA");
            References(x => x.Korisnik).Column("KORISNIK_ID").Cascade.All();
        }
    }
}
