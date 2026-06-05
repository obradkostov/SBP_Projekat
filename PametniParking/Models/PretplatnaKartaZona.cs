using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class PretplatnaKartaZona
    {
        public virtual int Id { get; set; }
        public virtual PretplatnaKarta Karta { get; set; }
        public virtual ParkingZona Zona { get; set; }
    }
}
