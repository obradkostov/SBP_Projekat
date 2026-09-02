namespace PametniParkingLibrary.DTOs;

public class PretplatnaKartaView
{
    public int Id { get; set; }
    public string? TipPretplate { get; set; }
    public DateTime PocetakVazenja { get; set; }
    public DateTime KrajVazenja { get; set; }
    public decimal Cena { get; set; }
    public int MaksBrVozila { get; set; }
    public int KorisnikId { get; set; }
    public string? KorisnikEmail { get; set; }
    public List<int> ZoneId { get; set; } = new();

    public PretplatnaKartaView() { }

    internal PretplatnaKartaView(PretplatnaKarta? p)
    {
        if (p != null)
        {
            Id = p.Id;
            TipPretplate = p.TipPretplate;
            PocetakVazenja = p.PocetakVazenja;
            KrajVazenja = p.KrajVazenja;
            Cena = p.Cena;
            MaksBrVozila = p.MaksBrVozila;
            KorisnikId = p.Korisnik?.Id ?? 0;
            KorisnikEmail = p.Korisnik?.Email;

            if (p.Zone != null)
            {
                foreach (var pz in p.Zone)
                {
                    if (pz.Zona != null)
                        ZoneId.Add(pz.Zona.Id);
                }
            }
        }
    }
}
