using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class MestoOsobaSaInvaliditetom
    {
        public virtual int ParkingMestoId { get; set; }
        public virtual ParkingMesto ParkingMesto { get; set; }
        public virtual string NivoPristupacnosti { get; set; }
    }
}
