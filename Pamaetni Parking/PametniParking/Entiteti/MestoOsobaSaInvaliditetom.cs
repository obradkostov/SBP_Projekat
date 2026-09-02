namespace PametniParkingLibrary.Entiteti;

internal class MestoOsobaSaInvaliditetom
{
    internal protected virtual int Id { get; set; } // isti kao ParkingMesto.Id (deljeni kljuc)
    internal protected virtual string? NivoPristupacnosti { get; set; }
    internal protected virtual ParkingMesto? ParkingMesto { get; set; } // 1:1 ref
}