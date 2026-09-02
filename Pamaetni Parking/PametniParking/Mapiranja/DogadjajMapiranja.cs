using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class DogadjajMapiranja : ClassMap<Dogadjaj>
{
    public DogadjajMapiranja()
    {
        Table("S19702.DOGADJAJ");
        Id(x => x.Id, "ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
        Map(x => x.RedniBroj, "REDNI_BROJ");
        Map(x => x.TipDogadjaja, "TIP_DOGADJAJA");
        Map(x => x.VremeNastanka, "VREME_NASTANKA");
        Map(x => x.OcitanaVrednost, "OCITANA_VREDNOST");
        Map(x => x.NivoPouzdanosti, "NIVO_POUZDANOSTI");
        Map(x => x.Potvrda, "POTVRDA");

        References(x => x.Senzor).Column("SENZOR_ID");
    }
}
