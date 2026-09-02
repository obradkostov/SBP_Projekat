namespace PametniParkingLibrary.DTOs;

public class SenzorView
{
    public int Id { get; set; }
    public string? Proizvodjac { get; set; }
    public string? Model { get; set; }
    public string? SerijskiBroj { get; set; }
    public DateTime DatumInstalacije { get; set; }
    public string? Status { get; set; }
    public string? TipSenzora { get; set; }
    public int ParkingMestoId { get; set; }
    public string? ParkingMestoOznaka { get; set; }

    // Dodatni atributi - popunjava DTOManager ako je video senzor
    public string? Rezolucija { get; set; }
    public decimal? UgaoPokrivanja { get; set; }
    public char? PrepRegOznaka { get; set; }

    public SenzorView() { }

    internal SenzorView(Senzor? s)
    {
        if (s != null)
        {
            Id = s.Id;
            Proizvodjac = s.Proizvodjac;
            Model = s.Model;
            SerijskiBroj = s.SerijskiBroj;
            DatumInstalacije = s.DatumInstalacije;
            Status = s.Status;
            TipSenzora = s.TipSenzora;
            ParkingMestoId = s.ParkingMesto?.Id ?? 0;
            ParkingMestoOznaka = s.ParkingMesto?.OznakaMesta;
        }
    }
}