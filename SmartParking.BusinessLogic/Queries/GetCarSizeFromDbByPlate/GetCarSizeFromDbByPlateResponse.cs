namespace SmartParking.BusinessLogic.Queries.GetCarSizeFromDbByPlate;

public class GetCarSizeFromDbByPlateResponse
{
    public bool FoundInDb { get; set; }
    public string CarSize { get; set; }
    public string ParkingArea { get; set; }
}
