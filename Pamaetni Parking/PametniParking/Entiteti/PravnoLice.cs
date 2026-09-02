namespace PametniParkingLibrary.Entiteti;

internal class PravnoLice : Korisnik
{
    internal protected virtual string? Naziv { get; set; }
    internal protected virtual string? Pib { get; set; }
    internal protected virtual string? MaticniBroj { get; set; }
    internal protected virtual string? KontaktOsoba { get; set; }
    internal protected virtual string? Sediste { get; set; }
}