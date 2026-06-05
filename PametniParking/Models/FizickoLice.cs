using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class FizickoLice:Korisnik
    {
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Jmbg { get; set; }
    }
}
