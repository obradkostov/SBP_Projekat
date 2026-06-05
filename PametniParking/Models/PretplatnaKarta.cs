using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class PretplatnaKarta
    {
        public PretplatnaKarta()
        {
        }
        public virtual int Id { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual string TipPretplate { get; set; }
        public virtual DateTime PocetakVazenja { get; set; }
        public virtual DateTime KrajVazenja { get; set; }
        public virtual decimal Cena { get; set; }
        public virtual int MaksBrVozila { get; set; }
        public virtual IList<PretplatnaKartaZona> Zone { get; set; } = new List<PretplatnaKartaZona>();
    }
}
