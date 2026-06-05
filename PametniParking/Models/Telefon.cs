using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Telefon
    {
        public virtual int Id { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual string BrojTelefona { get; set; }
    }
}
