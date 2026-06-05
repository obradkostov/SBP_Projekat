using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class ParkingMesto
    {
        public ParkingMesto() { }
        public virtual int Id { get; set; }
        public virtual ParkingZona Zona { get; set; }
        public virtual string OznakaMesta { get; set; }
        public virtual string GeografakaLokacija { get; set; }
        public virtual string Status { get; set; }
        public virtual string TipMesta { get; set; }
        public virtual decimal DozDuzina { get; set; }
        public virtual char Natkrivenost { get; set; }
        public virtual string KameraSenzor { get; set; }
        public virtual IList<Senzor> Senzori { get; set; } = new List<Senzor>();
    }
}
