using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class TelefonMap : ClassMap<Telefon>
    {
        public TelefonMap()
        {
            Table("S19702.TELEFON");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.BrojTelefona).Column("BROJ_TELEFONA");
            References(x => x.Korisnik).Column("KORISNIK_ID").Not.LazyLoad();
        }
    }
}