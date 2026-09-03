using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class ParkingZonaMapiranja : ClassMap<ParkingZona>
{
    public ParkingZonaMapiranja()
    {
        Table("S19702.PARKING_ZONA");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.Naziv, "NAZIV");
        Map(x => x.GeografskoPodrucje, "GEOGRAFSKO_PODRUCJE");
        Map(x => x.TipZone, "TIP_ZONE");
        Map(x => x.OsnovnaTarifa, "OSNOVNA_TARIFA");
        Map(x => x.MaxVremeZadrzavanja, "MAX_VREME_ZADRZAVANJA");
        Map(x => x.PravilaNaplate, "PRAVILA_NAPLATE");

        HasMany(x => x.FiksneTarife).KeyColumn("ZONA_ID").Cascade.All().Inverse();
        HasMany(x => x.DinamickeTarife).KeyColumn("ZONA_ID").Cascade.All().Inverse();
        HasMany(x => x.ParkingMesta).KeyColumn("ZONA_ID").Cascade.All().Inverse();
    }
}
