using System;
using System.Collections.Generic;
using System.Text;

namespace PametniParking.Models
{
    public class VideoSenzor
    {
        public VideoSenzor()
        {
        }
        public virtual int SenzorId { get; set; }
        public virtual Senzor Senzor { get; set; }
        public virtual string Rezolucija { get; set; }
        public virtual decimal UgaoPokrivanja { get; set; }
        public virtual char PrepRegOznaka { get; set; }
    }
}
