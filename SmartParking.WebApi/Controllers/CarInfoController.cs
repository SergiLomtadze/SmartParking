using Microsoft.AspNetCore.Mvc;
using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.BusinessLogic.Queries.AddCarInDb;
using SmartParking.BusinessLogic.Queries.CarInfoQueries.GetEnteringCarInfo;
using SmartParking.BusinessLogic.Queries.DeleteFromParkingPlacesByPlate;
using SmartParking.BusinessLogic.Queries.GetCarSizeFromDbByPlate;
using SmartParking.BusinessLogic.Queries.GetPlate;

namespace SmartParking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarInfoController(CommandInvoker commandInvoker) : ControllerBase
{
    [HttpGet("get-entering-car")]
    public async Task<IActionResult> GetEnteringCar()
    {
        var result = await commandInvoker.Invoke(
            new GetEnteringCarInfoRequest { });

        if ((result.FirtSensorDistance ?? 0) >= 51) 
        {
            return BadRequest(new
            {
                Error = "Too far from entrance"
            });
        }

        var plateNumber = await commandInvoker.Invoke(
            new GetPlateRequest { });

        var carInDb = await commandInvoker.Invoke(
            new GetCarSizeFromDbByPlateRequest { Plate = plateNumber.PlateNumber});

        if (carInDb.FoundInDb)
        {
            return Ok(new
            {
                carInDb.ParkingArea,
                carInDb.CarSize,
                plateNumber.PlateNumber,
                error = (string)null
            });
        }

        var addCarInDb = await commandInvoker.Invoke(
            new AddCarInDbRequest 
            { 
                CarSize = result.CarSize,
                PlateNumber = plateNumber.PlateNumber,
            });

        return Ok(new
        {
            addCarInDb.ParkingArea,
            addCarInDb.CarSize,
            plateNumber.PlateNumber,
            error = (string)null
        });
    }

    [HttpGet("get-existing-car")]
    public async Task<IActionResult> GetExistingCar()
    {

        var plateNumber = await commandInvoker.Invoke(
            new GetPlateRequest { });

        var removeCarParkingPlacesInDb = await commandInvoker.Invoke(
            new DeleteFromParkingPlacesByPlateRequest 
            { 
                PlateNumber = plateNumber.PlateNumber 
            });

        return Ok();
    }
}
