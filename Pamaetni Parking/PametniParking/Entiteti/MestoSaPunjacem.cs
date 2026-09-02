namespace PametniParkingLibrary.Entiteti;

internal class MestoSaPunjacem
{
    internal protected virtual int Id { get; set; } // isti kao ParkingMesto.Id (deljeni kljuc)
    internal protected virtual decimal SnagaPunjaca { get; set; }
    internal protected virtual string? TipKonektora { get; set; }
    internal protected virtual int BrojPrikljucaka { get; set; }
    internal protected virtual string? RezimiPunjenja { get; set; }
    internal protected virtual ParkingMesto? ParkingMesto { get; set; } // 1:1 ref
}
