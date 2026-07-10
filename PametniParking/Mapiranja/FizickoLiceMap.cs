using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class FizickoLiceMap:SubclassMap<FizickoLice>
    {
        public FizickoLiceMap()
        {
            Table("FIZICKO_LICE");
            KeyColumn("KORISNIK_ID");
            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.Jmbg).Column("JMBG");
        }

    }
}
