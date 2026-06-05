using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Dogadjaj
    {
        public virtual int Id { get; set; }
        public virtual int RedniBroj { get; set; }
        public virtual Senzor Senzor { get; set; }
        public virtual string TipDogadjaja { get; set; }
        public virtual DateTime VremeNastanka { get; set; }
        public virtual string OcitanaVrednost { get; set; }
        public virtual decimal NivoPouzdanosti { get; set; }
        public virtual string Potvrda { get; set; }
    }
}
