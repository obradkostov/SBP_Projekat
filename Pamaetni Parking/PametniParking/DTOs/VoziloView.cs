namespace PametniParkingLibrary.DTOs;

public class VoziloView
{
    public string? RegistarskaOznaka { get; set; }
    public string? DrzavaRegistracije { get; set; }
    public string? Marka { get; set; }
    public string? Model { get; set; }
    public string? TipVozila { get; set; }
    public string? Dimenzije { get; set; }
    public string? Pogon { get; set; }
    public int? KorisnikId { get; set; }
    public string? KorisnikEmail { get; set; }

    public VoziloView() { }

    internal VoziloView(Vozilo? v)
    {
        if (v != null)
        {
            RegistarskaOznaka = v.RegistarskaOznaka;
            DrzavaRegistracije = v.DrzavaRegistracije;
            Marka = v.Marka;
            Model = v.Model;
            TipVozila = v.TipVozila;
            Dimenzije = v.Dimenzije;
            Pogon = v.Pogon;
            KorisnikId = v.Korisnik?.Id;
            KorisnikEmail = v.Korisnik?.Email;
        }
    }
}
