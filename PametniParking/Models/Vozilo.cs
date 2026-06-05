using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Vozilo
    {
        public virtual string RegistarskaOznaka { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual string DrzavaRegistracije { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Model { get; set; }
        public virtual string TipVozila { get; set; }
        public virtual string Dimenzije { get; set; }
        public virtual string Pogon { get; set; }
    }
}
