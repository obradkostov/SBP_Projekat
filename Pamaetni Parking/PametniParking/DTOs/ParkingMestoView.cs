namespace PametniParkingLibrary.DTOs;

public class ParkingMestoView
{
    public int Id { get; set; }
    public string? OznakaMesta { get; set; }
    public string? GeografskaLokacija { get; set; }
    public string? Status { get; set; }
    public string? TipMesta { get; set; }
    public decimal DozDuzina { get; set; }
    public char Natkrivenost { get; set; }
    public string? KameraSenzor { get; set; }
    public int ZonaId { get; set; }
    public string? ZonaNaziv { get; set; }

    // Dodatni atributi - popunjava DTOManager ako mesto ima prosirenje
    public string? NivoPristupacnosti { get; set; }
    public decimal? SnagaPunjaca { get; set; }
    public string? TipKonektora { get; set; }
    public int? BrojPrikljucaka { get; set; }
    public string? RezimiPunjenja { get; set; }

    public ParkingMestoView() { }

    internal ParkingMestoView(ParkingMesto? m)
    {
        if (m != null)
        {
            Id = m.Id;
            OznakaMesta = m.OznakaMesta;
            GeografskaLokacija = m.GeografskaLokacija;
            Status = m.Status;
            TipMesta = m.TipMesta;
            DozDuzina = m.DozDuzina;
            Natkrivenost = m.Natkrivenost;
            KameraSenzor = m.KameraSenzor;
            ZonaId = m.Zona?.Id ?? 0;
            ZonaNaziv = m.Zona?.Naziv;
        }
    }
}
