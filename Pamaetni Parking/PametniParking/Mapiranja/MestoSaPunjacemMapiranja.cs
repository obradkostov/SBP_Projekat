using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class MestoSaPunjacemMapiranja : ClassMap<MestoSaPunjacem>
{
    public MestoSaPunjacemMapiranja()
    {
        Table("S19702.MESTO_SA_PUNJACEM_ZA_EV");
        Id(x => x.Id, "PARKING_MESTO_ID").GeneratedBy.Foreign("ParkingMesto");
        Map(x => x.SnagaPunjaca, "SNAGA_PUNJACA");
        Map(x => x.TipKonektora, "TIP_KONEKTORA");
        Map(x => x.BrojPrikljucaka, "BROJ_PRIKLJUCAKA");
        Map(x => x.RezimiPunjenja, "REZIMI_PUNJENJA");

        HasOne(x => x.ParkingMesto).Constrained();
    }
}
