using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class MestoOsobaSaInvaliditetomMapiranja : ClassMap<MestoOsobaSaInvaliditetom>
{
    public MestoOsobaSaInvaliditetomMapiranja()
    {
        Table("S19702.MESTO_OSOBE_SA_INVALIDITETOM");
        Id(x => x.Id, "PARKING_MESTO_ID").GeneratedBy.Foreign("ParkingMesto");
        Map(x => x.NivoPristupacnosti, "NIVO_PRISTUPACNOSTI");

        HasOne(x => x.ParkingMesto).Constrained();
    }
}
