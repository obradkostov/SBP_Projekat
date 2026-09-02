namespace PametniParkingLibrary.DTOs;

public class MestoOsobaSaInvaliditetomView
{
    public int Id { get; set; }
    public string? NivoPristupacnosti { get; set; }
    public int ParkingMestoId { get; set; }

    public MestoOsobaSaInvaliditetomView() { }

    internal MestoOsobaSaInvaliditetomView(MestoOsobaSaInvaliditetom? m)
    {
        if (m != null)
        {
            Id = m.Id;
            NivoPristupacnosti = m.NivoPristupacnosti;
            ParkingMestoId = m.ParkingMesto?.Id ?? 0;
        }
    }
}
