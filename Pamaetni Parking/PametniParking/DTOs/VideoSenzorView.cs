namespace PametniParkingLibrary.DTOs;

public class VideoSenzorView
{
    public int Id { get; set; }
    public string? Rezolucija { get; set; }
    public decimal UgaoPokrivanja { get; set; }
    public char PrepRegOznaka { get; set; }
    public int SenzorId { get; set; }

    public VideoSenzorView() { }

    internal VideoSenzorView(VideoSenzor? v)
    {
        if (v != null)
        {
            Id = v.Id;
            Rezolucija = v.Rezolucija;
            UgaoPokrivanja = v.UgaoPokrivanja;
            PrepRegOznaka = v.PrepRegOznaka;
            SenzorId = v.Senzor?.Id ?? 0;
        }
    }
}