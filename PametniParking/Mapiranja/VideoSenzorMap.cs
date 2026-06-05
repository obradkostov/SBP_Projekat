using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class VideoSenzorMap:ClassMap<VideoSenzor>
    {
        public VideoSenzorMap()
        {
            Table("VIDEO_SENZOR");
            Id(x => x.SenzorId).Column("SENZOR_ID").GeneratedBy.Identity();
            Map(x => x.Rezolucija).Column("REZOLUCIJA");
            Map(x => x.UgaoPokrivanja).Column("UGAO_POKRIVANJA");
            Map(x => x.PrepRegOznaka).Column("PREP_REG_OZNAKA");
            References(x => x.Senzor).Column("SENZOR_ID").Cascade.All();
        }
    }
}
