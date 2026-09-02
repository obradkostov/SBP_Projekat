namespace PametniParkingLibrary.DTOs;

public class ParkingZonaView
{
    public int Id { get; set; }
    public string? Naziv { get; set; }
    public string? GeografskoPodrucje { get; set; }
    public string? TipZone { get; set; }
    public decimal OsnovnaTarifa { get; set; }
    public int MaxVremeZadrzavanja { get; set; }
    public string? PravilaNaplate { get; set; }

    public ParkingZonaView() { }

    internal ParkingZonaView(ParkingZona? z)
    {
        if (z != null)
        {
            Id = z.Id;
            Naziv = z.Naziv;
            GeografskoPodrucje = z.GeografskoPodrucje;
            TipZone = z.TipZone;
            OsnovnaTarifa = z.OsnovnaTarifa;
            MaxVremeZadrzavanja = z.MaxVremeZadrzavanja;
            PravilaNaplate = z.PravilaNaplate;
        }
    }
}
