using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class ParkingZona
    {
        public virtual int Id{ get; set; }
        public virtual string Naziv{ get; set; }
        public virtual string GeografskoPodrucje{ get; set; }
        public virtual string TipZone{ get; set; }
        public virtual decimal OsnovnaTarifa{ get; set; }
        public virtual int MaxVremeZadrzavanja{ get; set; }
        public virtual string PravilaNaplate{ get; set; }
        public virtual IList<FiksnaTarifa>FiksneTarife{ get; set; }=new List<FiksnaTarifa>();
        public virtual IList<DinamickaTarifa> DinamickeeTarife { get; set; } = new List<DinamickaTarifa>();
        public virtual IList<ParkingMesto> ParkingMesta{ get; set; } = new List<ParkingMesto>();

    }
}
