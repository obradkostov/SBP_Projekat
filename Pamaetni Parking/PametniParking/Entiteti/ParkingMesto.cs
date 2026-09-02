namespace PametniParkingLibrary.Entiteti;

internal class ParkingMesto
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? OznakaMesta { get; set; }
    internal protected virtual string? GeografskaLokacija { get; set; }
    internal protected virtual string? Status { get; set; }
    internal protected virtual string? TipMesta { get; set; }
    internal protected virtual decimal DozDuzina { get; set; }
    internal protected virtual char Natkrivenost { get; set; }
    internal protected virtual string? KameraSenzor { get; set; }

    internal protected virtual ParkingZona? Zona { get; set; } // ref
    internal protected virtual IList<Senzor>? Senzori { get; set; } // HasMany

    internal ParkingMesto()
    {
        Senzori = new List<Senzor>();
    }
}
