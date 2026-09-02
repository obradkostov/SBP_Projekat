namespace PametniParkingLibrary.Entiteti;

internal class Parkiranje
{
    internal protected virtual int Id { get; set; }
    internal protected virtual DateTime DatumVremePocetka { get; set; }
    internal protected virtual decimal ObracunatiIznos { get; set; }

    internal protected virtual Vozilo? Vozilo { get; set; } // ref
    internal protected virtual ParkingMesto? ParkingMesto { get; set; } // ref
    internal protected virtual ParkingZona? Zona { get; set; } // ref
    internal protected virtual PretplatnaKarta? Karta { get; set; } // ref (nullable)
}
