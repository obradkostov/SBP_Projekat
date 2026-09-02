using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class TelefonMapiranja : ClassMap<Telefon>
{
    public TelefonMapiranja()
    {
        Table("S19702.TELEFON");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.BrojTelefona, "BROJ_TELEFONA");

        References(x => x.Korisnik).Column("KORISNIK_ID");
    }
}
