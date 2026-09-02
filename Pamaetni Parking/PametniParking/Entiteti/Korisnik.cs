namespace PametniParkingLibrary.Entiteti;

internal class Korisnik
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? Email { get; set; }
    internal protected virtual string? Adresa { get; set; }
    internal protected virtual string? StatusNaloga { get; set; }

    internal protected virtual IList<Telefon>? Telefoni { get; set; } // HasMany
    internal protected virtual IList<Vozilo>? Vozila { get; set; } // HasMany
    internal protected virtual IList<PretplatnaKarta>? PretplatneKarte { get; set; } // HasMany

    internal Korisnik()
    {
        Telefoni = new List<Telefon>();
        Vozila = new List<Vozilo>();
        PretplatneKarte = new List<PretplatnaKarta>();
    }
}
