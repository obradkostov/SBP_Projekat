using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class FiksnaTarifaMapiranja : ClassMap<FiksnaTarifa>
{
    public FiksnaTarifaMapiranja()
    {
        Table("S19702.FIKSNA_TARIFA");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.TipDana, "TIP_DANA");
        Map(x => x.NazivIntervala, "NAZIV_INTERVALA");
        Map(x => x.VremeOd, "VREME_OD");
        Map(x => x.VremeDo, "VREME_DO");
        Map(x => x.IznosTarife, "IZNOS_TARIFE");

        References(x => x.Zona).Column("ZONA_ID");
    }
}