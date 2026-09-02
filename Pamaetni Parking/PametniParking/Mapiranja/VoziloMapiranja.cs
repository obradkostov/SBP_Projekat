using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class VoziloMapiranja : ClassMap<Vozilo>
{
    public VoziloMapiranja()
    {
        Table("S19702.VOZILO");
        Id(x => x.RegistarskaOznaka, "REGISTARSKA_OZNAKA").GeneratedBy.Assigned();
        Map(x => x.DrzavaRegistracije, "DRZAVA_REGISTRACIJE");
        Map(x => x.Marka, "MARKA");
        Map(x => x.Model, "MODEL");
        Map(x => x.TipVozila, "TIP_VOZILA");
        Map(x => x.Dimenzije, "DIMENZIJE");
        Map(x => x.Pogon, "POGON");

        References(x => x.Korisnik).Column("KORISNIK_ID").Nullable();
    }
}
