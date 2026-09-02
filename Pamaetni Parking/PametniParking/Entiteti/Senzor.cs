namespace PametniParkingLibrary.Entiteti;

internal class Senzor
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? Proizvodjac { get; set; }
    internal protected virtual string? Model { get; set; }
    internal protected virtual string? SerijskiBroj { get; set; }
    internal protected virtual DateTime DatumInstalacije { get; set; }
    internal protected virtual string? Status { get; set; }
    internal protected virtual string? TipSenzora { get; set; }

    internal protected virtual ParkingMesto? ParkingMesto { get; set; } // ref
    internal protected virtual IList<Dogadjaj>? Dogadjaji { get; set; } // HasMany

    internal Senzor()
    {
        Dogadjaji = new List<Dogadjaj>();
    }
}
