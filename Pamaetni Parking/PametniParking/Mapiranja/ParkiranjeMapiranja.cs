using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class ParkiranjeMapiranja : ClassMap<Parkiranje>
{
    public ParkiranjeMapiranja()
    {
        Table("S19702.PARKIRANJE");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.DatumVremePocetka, "DATUM_VREME_POCETKA");
        Map(x => x.ObracunatiIznos, "OBRACUNATI_IZNOS");

        References(x => x.Vozilo).Column("REGISTARSKA_OZNAKA");
        References(x => x.ParkingMesto).Column("PARKING_MESTO_ID");
        References(x => x.Zona).Column("ZONA_ID");
        References(x => x.Karta).Column("KARTA_ID").Nullable();
    }
}
