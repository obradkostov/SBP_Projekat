namespace PametniParkingLibrary.Entiteti;

internal class Dogadjaj
{
    internal protected virtual int Id { get; set; }
    internal protected virtual int RedniBroj { get; set; }
    internal protected virtual string? TipDogadjaja { get; set; }
    internal protected virtual DateTime VremeNastanka { get; set; }
    internal protected virtual string? OcitanaVrednost { get; set; }
    internal protected virtual decimal NivoPouzdanosti { get; set; }
    internal protected virtual string? Potvrda { get; set; }

    internal protected virtual Senzor? Senzor { get; set; } // ref
}
