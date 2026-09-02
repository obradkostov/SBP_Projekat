using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class ParkingMestoMapiranja : ClassMap<ParkingMesto>
{
    public ParkingMestoMapiranja()
    {
        Table("S19702.PARKING_MESTO");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.OznakaMesta, "OZNAKA_MESTA");
        Map(x => x.GeografskaLokacija, "GEOGRAFSKA_LOKACIJA");
        Map(x => x.Status, "STATUS");
        Map(x => x.TipMesta, "TIP_MESTA");
        Map(x => x.DozDuzina, "DOZ_DUZINA");
        Map(x => x.Natkrivenost, "NATKRIVENOST");
        Map(x => x.KameraSenzor, "KAMERA_SENZOR");

        References(x => x.Zona).Column("ZONA_ID");
        HasMany(x => x.Senzori).KeyColumn("PARKING_MESTO_ID").Cascade.All();
    }
}
