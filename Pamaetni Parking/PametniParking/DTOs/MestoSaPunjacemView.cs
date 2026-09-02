namespace PametniParkingLibrary.DTOs;

public class MestoSaPunjacemView
{
    public int Id { get; set; }
    public decimal SnagaPunjaca { get; set; }
    public string? TipKonektora { get; set; }
    public int BrojPrikljucaka { get; set; }
    public string? RezimiPunjenja { get; set; }
    public int ParkingMestoId { get; set; }

    public MestoSaPunjacemView() { }

    internal MestoSaPunjacemView(MestoSaPunjacem? m)
    {
        if (m != null)
        {
            Id = m.Id;
            SnagaPunjaca = m.SnagaPunjaca;
            TipKonektora = m.TipKonektora;
            BrojPrikljucaka = m.BrojPrikljucaka;
            RezimiPunjenja = m.RezimiPunjenja;
            ParkingMestoId = m.ParkingMesto?.Id ?? 0;
        }
    }
}
