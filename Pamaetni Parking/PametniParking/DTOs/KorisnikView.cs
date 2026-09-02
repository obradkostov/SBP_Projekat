namespace PametniParkingLibrary.DTOs;

public class KorisnikView
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Adresa { get; set; }
    public string? StatusNaloga { get; set; }
    public string? Tip { get; set; } // "FizickoLice" ili "PravnoLice"

    // Fizicko lice
    public string? Ime { get; set; }
    public string? Prezime { get; set; }
    public string? Jmbg { get; set; }

    // Pravno lice
    public string? Naziv { get; set; }
    public string? Pib { get; set; }
    public string? MaticniBroj { get; set; }
    public string? KontaktOsoba { get; set; }
    public string? Sediste { get; set; }

    public KorisnikView() { }

    internal KorisnikView(Korisnik? k)
    {
        if (k == null) return;

        Id = k.Id;
        Email = k.Email;
        Adresa = k.Adresa;
        StatusNaloga = k.StatusNaloga;

        if (k is FizickoLice fl)
        {
            Tip = "FizickoLice";
            Ime = fl.Ime;
            Prezime = fl.Prezime;
            Jmbg = fl.Jmbg;
        }
        else if (k is PravnoLice pl)
        {
            Tip = "PravnoLice";
            Naziv = pl.Naziv;
            Pib = pl.Pib;
            MaticniBroj = pl.MaticniBroj;
            KontaktOsoba = pl.KontaktOsoba;
            Sediste = pl.Sediste;
        }
    }
}
