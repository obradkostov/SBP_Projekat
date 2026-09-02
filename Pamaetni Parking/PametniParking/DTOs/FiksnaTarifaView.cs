namespace PametniParkingLibrary.DTOs;

public class FiksnaTarifaView
{
    public int Id { get; set; }
    public string? TipDana { get; set; }
    public string? NazivIntervala { get; set; }
    public string? VremeOd { get; set; }
    public string? VremeDo { get; set; }
    public decimal IznosTarife { get; set; }
    public int ZonaId { get; set; }

    public FiksnaTarifaView() { }

    internal FiksnaTarifaView(FiksnaTarifa? f)
    {
        if (f != null)
        {
            Id = f.Id;
            TipDana = f.TipDana;
            NazivIntervala = f.NazivIntervala;
            VremeOd = f.VremeOd;
            VremeDo = f.VremeDo;
            IznosTarife = f.IznosTarife;
            ZonaId = f.Zona?.Id ?? 0;
        }
    }
}
