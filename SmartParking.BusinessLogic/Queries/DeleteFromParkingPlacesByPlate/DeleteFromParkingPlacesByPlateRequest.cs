using SmartParking.BusinessLogic.CommandExecutor;

namespace SmartParking.BusinessLogic.Queries.DeleteFromParkingPlacesByPlate;

public class DeleteFromParkingPlacesByPlateRequest 
    : ICommand <DeleteFromParkingPlacesByPlateResponse>
{
    public string PlateNumber { get; set; }
}
