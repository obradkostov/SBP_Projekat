using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class KorisnikMapiranja : ClassMap<Korisnik>
{
    public KorisnikMapiranja()
    {
        Table("S19702.KORISNIK");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.Email, "EMAIL");
        Map(x => x.Adresa, "ADRESA");
        Map(x => x.StatusNaloga, "STATUS_NALOGA");

        HasMany(x => x.Telefoni).KeyColumn("KORISNIK_ID").Cascade.All();
        HasMany(x => x.Vozila).KeyColumn("KORISNIK_ID").Cascade.All();
        HasMany(x => x.PretplatneKarte).KeyColumn("KORISNIK_ID").Cascade.All();
    }
}