namespace PametniParkingLibrary.Entiteti;

internal class FiksnaTarifa
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? TipDana { get; set; }
    internal protected virtual string? NazivIntervala { get; set; }
    internal protected virtual string? VremeOd { get; set; }
    internal protected virtual string? VremeDo { get; set; }
    internal protected virtual decimal IznosTarife { get; set; }

    internal protected virtual ParkingZona? Zona { get; set; } // ref
}
