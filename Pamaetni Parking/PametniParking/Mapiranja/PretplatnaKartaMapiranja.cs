using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class PretplatnaKartaMapiranja : ClassMap<PretplatnaKarta>
{
    public PretplatnaKartaMapiranja()
    {
        Table("S19702.PRETPLATNA_KARTA");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.TipPretplate, "TIP_PRETPLATE");
        Map(x => x.PocetakVazenja, "POCETAK_VAZENJA");
        Map(x => x.KrajVazenja, "KRAJ_VAZENJA");
        Map(x => x.Cena, "CENA");
        Map(x => x.MaksBrVozila, "MAKS_BR_VOZILA");

        References(x => x.Korisnik).Column("KORISNIK_ID");
        HasMany(x => x.Zone).KeyColumn("KARTA_ID").Cascade.All();
    }
}
