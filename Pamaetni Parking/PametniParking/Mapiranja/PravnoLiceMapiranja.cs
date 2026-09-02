using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class PravnoLiceMapiranja : SubclassMap<PravnoLice>
{
    public PravnoLiceMapiranja()
    {
        Table("S19702.PRAVNO_LICE");
        KeyColumn("KORISNIK_ID");
        Map(x => x.Naziv, "NAZIV");
        Map(x => x.Pib, "PIB");
        Map(x => x.MaticniBroj, "MATICNI_BROJ");
        Map(x => x.KontaktOsoba, "KONTAKT_OSOBA");
        Map(x => x.Sediste, "SEDISTE");
    }
}
