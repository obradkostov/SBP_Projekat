using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Parkiranje
    {
        public Parkiranje()
        {
        }
        public virtual int Id { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual ParkingMesto ParkingMesto { get; set; }
        public virtual ParkingZona Zona { get; set; }
        public virtual DateTime DatumVremePocetka { get; set; }
        public virtual decimal ObracunatiIznos { get; set; }
        public virtual PretplatnaKarta Karta { get; set; }
    }
}
