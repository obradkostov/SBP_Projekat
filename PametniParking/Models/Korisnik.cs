using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Korisnik
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string StatusNaloga { get; set; }
        public virtual IList<Telefon> Telefoni { get; set; } = new List<Telefon>();
        public virtual IList<Vozilo> Vozila { get; set; } = new List<Vozilo>();
        public virtual IList<PretplatnaKarta> PretplatneKarte { get; set; } = new List<PretplatnaKarta>();
    }
}
