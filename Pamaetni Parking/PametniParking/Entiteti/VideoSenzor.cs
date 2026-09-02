namespace PametniParkingLibrary.Entiteti;

internal class VideoSenzor
{
    internal protected virtual int Id { get; set; } // isti kao Senzor.Id (deljeni kljuc)
    internal protected virtual string? Rezolucija { get; set; }
    internal protected virtual decimal UgaoPokrivanja { get; set; }
    internal protected virtual char PrepRegOznaka { get; set; }
    internal protected virtual Senzor? Senzor { get; set; } // 1:1 ref
}
