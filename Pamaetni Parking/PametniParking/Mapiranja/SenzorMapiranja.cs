using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class SenzorMapiranja : ClassMap<Senzor>
{
    public SenzorMapiranja()
    {
        Table("S19702.SENZOR");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.Proizvodjac, "PROIZVODJAC");
        Map(x => x.Model, "MODEL");
        Map(x => x.SerijskiBroj, "SERIJSKI_BROJ");
        Map(x => x.DatumInstalacije, "DATUM_INSTALACIJE");
        Map(x => x.Status, "STATUS");
        Map(x => x.TipSenzora, "TIP_SENZORA");

        References(x => x.ParkingMesto).Column("PARKING_MESTO_ID");
        HasMany(x => x.Dogadjaji).KeyColumn("SENZOR_ID").Cascade.All().Inverse();
    }
}