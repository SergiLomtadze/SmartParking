using Microsoft.EntityFrameworkCore;
using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.DataAccess.Enums;

namespace SmartParking.BusinessLogic.Queries.DeleteFromParkingPlacesByPlate;


public class DeleteFromParkingPlacesByPlateHandler(IApplicationDbContext context)
    : ICommandHandler<DeleteFromParkingPlacesByPlateRequest, DeleteFromParkingPlacesByPlateResponse>
{
    public async Task<DeleteFromParkingPlacesByPlateResponse> Handle(DeleteFromParkingPlacesByPlateRequest command)
    {
        var carSizeInDb = await context.CarSizes
            .Where(x => string.Equals(x.PlateNumber, command.PlateNumber))
            .Select(x => x.Size)
            .FirstOrDefaultAsync();

        var parkingPlace = string.Empty;

        if (string.Equals(carSizeInDb, CarSize.Small.ToString()))
        {
            parkingPlace = "AreaA";
        }
        if (string.Equals(carSizeInDb, CarSize.Medium.ToString()))
        {
            parkingPlace = "AreaB";
        }
        if (string.Equals(carSizeInDb, CarSize.Large.ToString()))
        {
            parkingPlace = "AreaC";
        }

        var parking = context.ParkingPlaces.SingleOrDefault(x => string.Equals( x.PlaceName, parkingPlace));
        if (parking != null)
        {
            parking.Count -= 1;
            context.SaveChanges();
        }


        return new DeleteFromParkingPlacesByPlateResponse
        {
        };
    }
}
