namespace PametniParkingLibrary.Entiteti;

internal class PretplatnaKartaZona
{
    internal protected virtual int Id { get; set; }
    internal protected virtual PretplatnaKarta? Karta { get; set; } // ref
    internal protected virtual ParkingZona? Zona { get; set; } // ref
}
