using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class MestoOsobaSaInvaliditetomMap:ClassMap<MestoOsobaSaInvaliditetom>
    {
        public MestoOsobaSaInvaliditetomMap()
        {
            Table("MESTO_OSOBA_SA_INVALIDITETOM");
            Id(x=>x.ParkingMestoId).Column("PARKING_MESTO_ID").GeneratedBy.Assigned();
            //References(x => x.ParkingMesto).Column("PARKING_MESTO_ID").Cascade.All();
            Map(x => x.NivoPristupacnosti).Column("NIVO_PRISTUPACNOSTI");
        }
    }
}
