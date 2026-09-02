namespace PametniParkingLibrary.DTOs;

public class PretplatnaKartaZonaView
{
    public int Id { get; set; }
    public int KartaId { get; set; }
    public int ZonaId { get; set; }

    public PretplatnaKartaZonaView() { }

    internal PretplatnaKartaZonaView(PretplatnaKartaZona? pz)
    {
        if (pz != null)
        {
            Id = pz.Id;
            KartaId = pz.Karta?.Id ?? 0;
            ZonaId = pz.Zona?.Id ?? 0;
        }
    }
}
