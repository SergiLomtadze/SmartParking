using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.DataAccess.Enums;

namespace SmartParking.BusinessLogic.Queries.AddCarInDb;

public class AddCarInDbHandler(IApplicationDbContext context)
    : ICommandHandler<AddCarInDbRequest, AddCarInDbResponse>
{
    public async Task<AddCarInDbResponse> Handle(AddCarInDbRequest command)
    {
        var result = context.CarSizes.Add(new DataAccess.Entities.CarSize
        {
            PlateNumber = command.PlateNumber,
            Size = command.CarSize,
        });

        await context.SaveChangesAsync();

        var parkingPlaces = context.ParkingPlaces.AsEnumerable();

        var parkingPlacesAPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaA")).FirstOrDefault();
        var parkingPlacesAFreePlacese = parkingPlacesAPlacese.TotalAmount - parkingPlacesAPlacese.Count;

        var parkingPlacesBPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaB")).FirstOrDefault();
        var parkingPlacesBFreePlacese = parkingPlacesBPlacese.TotalAmount - parkingPlacesBPlacese.Count;

        var parkingPlacesCPlacese = parkingPlaces.Where(x => x.PlaceName.Equals("AreaC")).FirstOrDefault();
        var parkingPlacesCFreePlacese = parkingPlacesCPlacese.TotalAmount - parkingPlacesCPlacese.Count;


        if (string.Equals(command.CarSize, CarSize.Small.ToString()))
        {
            if (parkingPlacesAFreePlacese > 0)
            {
                var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaA");
                if (parking != null)
                {
                    parking.Count += 1;
                    context.SaveChanges();
                }

                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
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
                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
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

                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
                    ParkingArea = "Parking Area C"
                };
            }

            return new AddCarInDbResponse
            {
                CarSize = command.CarSize,
                ParkingArea = "No Free Parking Places"
            };
        }

        if (string.Equals(command.CarSize, CarSize.Medium.ToString()))
        {

            if (parkingPlacesBFreePlacese > 0)
            {
                var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaB");
                if (parking != null)
                {
                    parking.Count += 1;
                    context.SaveChanges();
                }

                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
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

                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
                    ParkingArea = "Parking Area C"
                };
            }

            return new AddCarInDbResponse
            {
                CarSize = command.CarSize,
                ParkingArea = "No Free Parking Places"
            };
        }

        if (string.Equals(command.CarSize, CarSize.Large.ToString()))
        {

            if (parkingPlacesCFreePlacese > 0)
            {
                var parking = context.ParkingPlaces.SingleOrDefault(x => x.PlaceName == "AreaC");
                if (parking != null)
                {
                    parking.Count += 1;
                    context.SaveChanges();
                }

                return new AddCarInDbResponse
                {
                    CarSize = command.CarSize,
                    ParkingArea = "Parking Area C"
                };
            }

            return new AddCarInDbResponse
            {
                CarSize = command.CarSize,
                ParkingArea = "No Free Parking Places"
            };
        }

        return new AddCarInDbResponse
        {
            CarSize = command.CarSize,
            ParkingArea = "No Free Parking Places"
        };
    }
}
