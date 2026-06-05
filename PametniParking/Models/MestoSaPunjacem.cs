using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class MestoSaPunjacem
    {
        public virtual int ParkingMestoId { get; set; }
        public virtual ParkingMesto ParkingMesto { get; set; }
        public virtual decimal SnagaPunjaca { get; set; }
        public virtual string TipKonektora { get; set; }
        public virtual int BrojPrikljucaka { get; set; }
        public virtual string RezimiPunjenja { get; set; }
    }
}
