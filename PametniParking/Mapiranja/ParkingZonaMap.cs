using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Impl;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Mapiranja
{
    public class ParkingZonaMap : ClassMap<ParkingZona>
    {
        public ParkingZonaMap()
        {
            Table("S19702.PARKING_ZONA");
            Id(x => x.Id).Column("ID").GeneratedBy.Sequence("S19702.HIBERNATE_SEQUENCE");
            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.GeografskoPodrucje).Column("GEOGRAFSKO_PODRUCJE");
            Map(x => x.TipZone).Column("TIP_ZONE");
            Map(x => x.OsnovnaTarifa).Column("OSNOVNA_TARIFA");
            Map(x => x.MaxVremeZadrzavanja).Column("MAX_VREME_ZADRZAVANJA");
            Map(x => x.PravilaNaplate).Column("PRAVILA_NAPLATE");

            HasMany(x => x.FiksneTarife).KeyColumn("ZONA_ID").Cascade.All().Inverse();
            HasMany(x => x.DinamickeeTarife).KeyColumn("ZONA_ID").Cascade.All().Inverse();
            HasMany(x => x.ParkingMesta).KeyColumn("ZONA_ID").Cascade.All().Inverse();


        }
    }
}
