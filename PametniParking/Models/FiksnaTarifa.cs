using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class FiksnaTarifa
    {
        public FiksnaTarifa()
        {
        }
        public virtual int Id { get; set; }
        public virtual ParkingZona Zona { get; set; }
        public virtual string TipDana { get; set; }
        public virtual string NazivIntervala { get; set; }
        public virtual string VremeOd { get; set; }
        public virtual string VremeDo { get; set; }
        public virtual decimal IznosTarife { get; set; }
    }
}
