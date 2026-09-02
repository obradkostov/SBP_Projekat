namespace PametniParkingLibrary.DTOs;

public class DogadjajView
{
    public int Id { get; set; }
    public int RedniBroj { get; set; }
    public string? TipDogadjaja { get; set; }
    public DateTime VremeNastanka { get; set; }
    public string? OcitanaVrednost { get; set; }
    public decimal NivoPouzdanosti { get; set; }
    public string? Potvrda { get; set; }
    public int SenzorId { get; set; }
    public string? SenzorSerijskiBroj { get; set; }

    public DogadjajView() { }

    internal DogadjajView(Dogadjaj? d)
    {
        if (d != null)
        {
            Id = d.Id;
            RedniBroj = d.RedniBroj;
            TipDogadjaja = d.TipDogadjaja;
            VremeNastanka = d.VremeNastanka;
            OcitanaVrednost = d.OcitanaVrednost;
            NivoPouzdanosti = d.NivoPouzdanosti;
            Potvrda = d.Potvrda;
            SenzorId = d.Senzor?.Id ?? 0;
            SenzorSerijskiBroj = d.Senzor?.SerijskiBroj;
        }
    }
}