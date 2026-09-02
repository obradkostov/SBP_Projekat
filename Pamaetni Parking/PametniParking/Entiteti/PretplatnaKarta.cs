namespace PametniParkingLibrary.Entiteti;

internal class PretplatnaKarta
{
    internal protected virtual int Id { get; set; }
    internal protected virtual string? TipPretplate { get; set; }
    internal protected virtual DateTime PocetakVazenja { get; set; }
    internal protected virtual DateTime KrajVazenja { get; set; }
    internal protected virtual decimal Cena { get; set; }
    internal protected virtual int MaksBrVozila { get; set; }

    internal protected virtual Korisnik? Korisnik { get; set; } // ref
    internal protected virtual IList<PretplatnaKartaZona>? Zone { get; set; } // HasMany (veza ka zonama)

    internal PretplatnaKarta()
    {
        Zone = new List<PretplatnaKartaZona>();
    }
}
