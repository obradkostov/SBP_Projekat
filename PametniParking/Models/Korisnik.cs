using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class Korisnik
    {
        public Korisnik()
        {
        }
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string StatusNaloga { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual IList<Telefon> Telefoni { get; set; } = new List<Telefon>();
        [Newtonsoft.Json.JsonIgnore]
        public virtual IList<Vozilo> Vozila { get; set; } = new List<Vozilo>();
        [Newtonsoft.Json.JsonIgnore]
        public virtual IList<PretplatnaKarta> PretplatneKarte { get; set; } = new List<PretplatnaKarta>();
    }
}
