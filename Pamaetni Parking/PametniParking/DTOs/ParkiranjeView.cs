namespace PametniParkingLibrary.DTOs;

public class ParkiranjeView
{
    public int Id { get; set; }
    public DateTime DatumVremePocetka { get; set; }
    public decimal ObracunatiIznos { get; set; }
    public string? VoziloOznaka { get; set; }
    public int ParkingMestoId { get; set; }
    public int ZonaId { get; set; }
    public int? KartaId { get; set; }

    public ParkiranjeView() { }

    internal ParkiranjeView(Parkiranje? p)
    {
        if (p != null)
        {
            Id = p.Id;
            DatumVremePocetka = p.DatumVremePocetka;
            ObracunatiIznos = p.ObracunatiIznos;
            VoziloOznaka = p.Vozilo?.RegistarskaOznaka;
            ParkingMestoId = p.ParkingMesto?.Id ?? 0;
            ZonaId = p.Zona?.Id ?? 0;
            KartaId = p.Karta?.Id;
        }
    }
}
