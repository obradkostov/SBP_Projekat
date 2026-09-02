namespace PametniParkingLibrary.Entiteti;

internal class Telefon
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? BrojTelefona { get; set; }
    internal protected virtual Korisnik? Korisnik { get; set; } // ref
}