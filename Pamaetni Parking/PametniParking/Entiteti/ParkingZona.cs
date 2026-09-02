namespace PametniParkingLibrary.Entiteti;

internal class ParkingZona
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? Naziv { get; set; }
    internal protected virtual string? GeografskoPodrucje { get; set; }
    internal protected virtual string? TipZone { get; set; }
    internal protected virtual decimal OsnovnaTarifa { get; set; }
    internal protected virtual int MaxVremeZadrzavanja { get; set; }
    internal protected virtual string? PravilaNaplate { get; set; }

    internal protected virtual IList<FiksnaTarifa>? FiksneTarife { get; set; } // HasMany
    internal protected virtual IList<DinamickaTarifa>? DinamickeTarife { get; set; } // HasMany
    internal protected virtual IList<ParkingMesto>? ParkingMesta { get; set; } // HasMany

    internal ParkingZona()
    {
        FiksneTarife = new List<FiksnaTarifa>();
        DinamickeTarife = new List<DinamickaTarifa>();
        ParkingMesta = new List<ParkingMesto>();
    }
}
