using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Senzor
    {
        public Senzor()
        {
        }
        public virtual int Id { get; set; }
        public virtual ParkingMesto ParkingMesto { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual string Model { get; set; }
        public virtual string SerijskiBroj { get; set; }
        public virtual DateTime DatumInstalacije { get; set; }
        public virtual string Status { get; set; }
        public virtual string TipSenzora { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual IList<Dogadjaj> Dogadjaji { get; set; } = new List<Dogadjaj>();
    }
}
