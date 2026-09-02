using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class DinamickaTarifaMapiranja : ClassMap<DinamickaTarifa>
{
    public DinamickaTarifaMapiranja()
    {
        Table("S19702.DINAMICKA_TARIFA");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.PocetakVazenja, "POCETAK_VAZENJA");
        Map(x => x.KrajVazenja, "KRAJ_VAZENJA");
        Map(x => x.RazlogPromene, "RAZLOG_PROMENE");
        Map(x => x.InicijatorPromene, "INICIJATOR_PROMENE");
        Map(x => x.PopunjenostZone, "POPUNJENOST_ZONE");
        Map(x => x.TrajanjeParkiranja, "TRAJANJE_PARKIRANJA");
        Map(x => x.IznosTarife, "IZNOS_TARIFE");

        References(x => x.Zona).Column("ZONA_ID");
    }
}
