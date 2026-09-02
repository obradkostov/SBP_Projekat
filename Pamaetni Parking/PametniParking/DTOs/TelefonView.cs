namespace PametniParkingLibrary.DTOs;

public class TelefonView
{
    public int Id { get; set; }
    public string? BrojTelefona { get; set; }
    public int KorisnikId { get; set; }

    public TelefonView() { }

    internal TelefonView(Telefon? t)
    {
        if (t != null)
        {
            Id = t.Id;
            BrojTelefona = t.BrojTelefona;
            KorisnikId = t.Korisnik?.Id ?? 0;
        }
    }
}
