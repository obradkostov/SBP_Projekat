using FluentNHibernate.Mapping;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class MestoSaPunjacemMap:ClassMap<MestoSaPunjacem>
    {
        public MestoSaPunjacemMap()
        {
            Table("MESTO_SA_PUNJACEM_ZA_EV");
            Id(x => x.ParkingMestoId).Column("PARKING_MESTO_ID").GeneratedBy.Foreign("ParkingMesto");
            Map(x => x.SnagaPunjaca).Column("SNAGA_PUNJACA");
            Map(x => x.TipKonektora).Column("TIP_KONEKTORA");
            Map(x => x.BrojPrikljucaka).Column("BROJ_PRIKLJUCAKA");
            Map(x => x.RezimiPunjenja).Column("REZIMI_PUNJENJA");
            HasOne(x => x.ParkingMesto).Constrained();
        }
    }
}
