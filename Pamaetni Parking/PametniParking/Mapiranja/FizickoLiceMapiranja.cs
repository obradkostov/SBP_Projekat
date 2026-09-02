using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class FizickoLiceMapiranja : SubclassMap<FizickoLice>
{
    public FizickoLiceMapiranja()
    {
        Table("S19702.FIZICKO_LICE");
        KeyColumn("KORISNIK_ID");
        Map(x => x.Ime, "IME");
        Map(x => x.Prezime, "PREZIME");
        Map(x => x.Jmbg, "JMBG");
    }
}