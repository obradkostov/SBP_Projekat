namespace PametniParkingLibrary.Entiteti;

internal class DinamickaTarifa
{
    internal protected virtual int Id { get; set; }
    internal protected virtual DateTime PocetakVazenja { get; set; }
    internal protected virtual DateTime KrajVazenja { get; set; }
    internal protected virtual string? RazlogPromene { get; set; }
    internal protected virtual string? InicijatorPromene { get; set; }
    internal protected virtual decimal PopunjenostZone { get; set; }
    internal protected virtual int TrajanjeParkiranja { get; set; }
    internal protected virtual decimal IznosTarife { get; set; }

    internal protected virtual ParkingZona? Zona { get; set; } // ref
}
