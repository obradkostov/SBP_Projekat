using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class DinamickaTarifaMap:ClassMap<DinamickaTarifa>
    {
        public DinamickaTarifaMap()
        {
            Table("DINAMICKA_TARIFA");
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.PocetakVazenja).Column("POCETAK_VAZENJA");
            Map(x => x.KrajVazenja).Column("KRAJ_VAZENJA");
            Map(x => x.RazlogPromene).Column("RAZLOG_PROMENE");
            Map(x => x.InicijatorPromene).Column("INICIJATOR_PROMENE");
            Map(x => x.PopunjenostZone).Column("POPUNJENOST_ZONE");
            Map(x => x.TrajanjeParkirana).Column("TRAJANJE_PARKIRANJA");
            Map(x => x.IznosTarife).Column("IZNOS_TARIFE");
            References(x => x.Zona).Column("ZONA_ID").Cascade.All();
        }
    }
}
