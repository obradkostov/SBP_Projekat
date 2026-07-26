using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class MestoOsobaSaInvaliditetomMap : ClassMap<MestoOsobaSaInvaliditetom>
    {
        public MestoOsobaSaInvaliditetomMap()
        {
            Table("S19702.MESTO_OSOBE_SA_INVALIDITETOM");
            Id(x => x.ParkingMestoId).Column("PARKING_MESTO_ID").GeneratedBy.Foreign("ParkingMesto");
            HasOne(x => x.ParkingMesto).Constrained();
            Map(x => x.NivoPristupacnosti).Column("NIVO_PRISTUPACNOSTI");
        }
    }
}
