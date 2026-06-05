using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class DogadjajMap:ClassMap<Dogadjaj>
    {
        public DogadjajMap()
        {
            Table("DOGADJAJ");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.RedniBroj).Column("REDNI_BROJ");
            References(x => x.Senzor).Column("SENZOR_ID").Cascade.All();
            Map(x => x.TipDogadjaja).Column("TIP_DOGADJAJA");
            Map(x => x.VremeNastanka).Column("VREME_NASTANKA");
            Map(x => x.OcitanaVrednost).Column("OCITANA_VREDNOST");
            Map(x => x.NivoPouzdanosti).Column("NIVO_POUZDANOSTI");
            Map(x => x.Potvrda).Column("POTVRDA");
            References(x=>x.Senzor).Column("SENZOR_ID");
        }
    }
}
