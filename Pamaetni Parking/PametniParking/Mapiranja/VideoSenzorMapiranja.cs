using FluentNHibernate.Mapping;

namespace PametniParkingLibrary.Mapiranja;

internal class VideoSenzorMapiranja : ClassMap<VideoSenzor>
{
    public VideoSenzorMapiranja()
    {
        Table("S19702.VIDEO_SENZOR");
        Id(x => x.Id, "SENZOR_ID").GeneratedBy.Foreign("Senzor");
        Map(x => x.Rezolucija, "REZOLUCIJA");
        Map(x => x.UgaoPokrivanja, "UGAO_POKRIVANJA");
        Map(x => x.PrepRegOznaka, "PREP_REG_OZNAKA");

        HasOne(x => x.Senzor).Constrained();
    }
}
