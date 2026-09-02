namespace PametniParkingLibrary.DTOs;

public class DinamickaTarifaView
{
    public int Id { get; set; }
    public DateTime PocetakVazenja { get; set; }
    public DateTime KrajVazenja { get; set; }
    public string? RazlogPromene { get; set; }
    public string? InicijatorPromene { get; set; }
    public decimal PopunjenostZone { get; set; }
    public int TrajanjeParkiranja { get; set; }
    public decimal IznosTarife { get; set; }
    public int ZonaId { get; set; }

    public DinamickaTarifaView() { }

    internal DinamickaTarifaView(DinamickaTarifa? d)
    {
        if (d != null)
        {
            Id = d.Id;
            PocetakVazenja = d.PocetakVazenja;
            KrajVazenja = d.KrajVazenja;
            RazlogPromene = d.RazlogPromene;
            InicijatorPromene = d.InicijatorPromene;
            PopunjenostZone = d.PopunjenostZone;
            TrajanjeParkiranja = d.TrajanjeParkiranja;
            IznosTarife = d.IznosTarife;
            ZonaId = d.Zona?.Id ?? 0;
        }
    }
}
