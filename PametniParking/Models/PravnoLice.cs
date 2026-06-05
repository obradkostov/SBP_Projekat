using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class PravnoLice:Korisnik
    {
        public PravnoLice() { }
        public virtual string Naziv { get; set; }
        public virtual string Pib { get; set; }
        public virtual string MaticniBroj { get; set; }
        public virtual string KontaktOsoba { get; set; }
        public virtual string Sediste { get; set; }
    }
}
