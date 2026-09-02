using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class PretplatnaKartaZonaMapiranja : ClassMap<PretplatnaKartaZona>
{
    public PretplatnaKartaZonaMapiranja()
    {
        Table("S19702.PRETPLATNA_KARTA_ZONE");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");

        References(x => x.Karta).Column("KARTA_ID");
        References(x => x.Zona).Column("ZONA_ID");
    }
}
