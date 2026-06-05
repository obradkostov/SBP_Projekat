using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class DinamickaTarifa
    {
        public DinamickaTarifa()
        {
        }
        public virtual int Id { get; set; }
        public virtual ParkingZona Zona { get; set; }
        public virtual DateTime PocetakVazenja { get; set; }
        public virtual DateTime KrajVazenja { get; set; }
        public virtual string RazlogPromene { get; set; }
        public virtual string InicijatorPromene { get; set; }
        public virtual decimal PopunjenostZone { get; set; }
        public virtual int TrajanjeParkirana { get; set; }
        public virtual decimal IznosTarife { get; set; }
    }
}
