namespace PametniParkingLibrary.Entiteti;

internal class Vozilo
{
    internal protected virtual string? RegistarskaOznaka { get; set; } // PK (prirodni kljuc)
    internal protected virtual string? DrzavaRegistracije { get; set; }
    internal protected virtual string? Marka { get; set; }
    internal protected virtual string? Model { get; set; }
    internal protected virtual string? TipVozila { get; set; }
    internal protected virtual string? Dimenzije { get; set; }
    internal protected virtual string? Pogon { get; set; }

    internal protected virtual Korisnik? Korisnik { get; set; } // ref (nullable)
}
