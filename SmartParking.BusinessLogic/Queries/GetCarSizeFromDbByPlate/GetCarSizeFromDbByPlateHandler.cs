using Microsoft.EntityFrameworkCore;
using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.DataAccess.Enums;

namespace SmartParking.BusinessLogic.Queries.GetCarSizeFromDbByPlate;

public class GetCarSizeFromDbByPlateHandler(IApplicationDbContext context)
    : ICommandHandler<GetCarSizeFromDbByPlateRequest, GetCarSizeFromDbByPlateResponse>
{
    public async Task<GetCarSizeFromDbByPlateResponse> Handle(GetCarSizeFromDbByPlateRequest command)
    {
        var carSizeInDb = await context.CarSizes
            .Where(x => string.Equals(x.PlateNumber, command.Plate))
            .Select(x => x.Size)
            .FirstOrDefaultAsync();

        var parkingPlaces = context.ParkingPlaces.ToList();
        
        var parkingPlacesAPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaA")).FirstOrDefault();
        var parkingPlacesAFreePlacese = parkingPlacesAPlacese.TotalAmount - parkingPlacesAPlacese.Count;

        var parkingPlacesBPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaB")).FirstOrDefault();
        var parkingPlacesBFreePlacese = parkingPlacesBPlacese.TotalAmount - parkingPlacesBPlacese.Count;

        var parkingPlacesCPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaC")).FirstOrDefault();
        var parkingPlacesCFreePlacese = parkingPlacesCPlacese.TotalAmount - parkingPlacesCPlacese.Count;

        if (carSizeInDb is not null)
        {
            if (string.Equals(carSizeInDb, CarSize.Small.ToString()))
            {
                if (parkingPlacesAFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaA");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area A"
                    };
                }

                if (parkingPlacesBFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaB");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area B"
                    };
                }

                if (parkingPlacesCFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaC");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area C"
                    };
                }
                return new GetCarSizeFromDbByPlateResponse
                {
                    FoundInDb = true,
                    CarSize = carSizeInDb,
                    ParkingArea = "No Free Parking Places"
                };
            }

            if (string.Equals(carSizeInDb, CarSize.Medium.ToString()))
            {

                if (parkingPlacesBFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaB");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area B"
                    };
                }

                if (parkingPlacesCFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaC");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area C"
                    };
                }

                return new GetCarSizeFromDbByPlateResponse
                {
                    FoundInDb = true,
                    CarSize = carSizeInDb,
                    ParkingArea = "No Free Parking Places"
                };
            }

            if (string.Equals(carSizeInDb, CarSize.Large.ToString()))
            {

                if (parkingPlacesCFreePlacese > 0)
                {
                    var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaC");
                    if (parking != null)
                    {
                        parking.Count += 1;
                        context.SaveChanges();
                    }
                    return new GetCarSizeFromDbByPlateResponse
                    {
                        FoundInDb = true,
                        CarSize = carSizeInDb,
                        ParkingArea = "Parking Area C"
                    };
                }
                return new GetCarSizeFromDbByPlateResponse
                {
                    FoundInDb = true,
                    CarSize = carSizeInDb,
                    ParkingArea = "No Free Parking Places"
                };
            }
        }

        return new GetCarSizeFromDbByPlateResponse
        {
            FoundInDb = false,
        };
    }
}
