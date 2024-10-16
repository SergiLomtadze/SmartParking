using Microsoft.Extensions.DependencyInjection;
using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.BusinessLogic.EntranceCamereApi;
using SmartParking.BusinessLogic.ExitCameraApi;
using SmartParking.BusinessLogic.Queries.AddCarInDb;
using SmartParking.BusinessLogic.Queries.CarInfoQueries.GetEnteringCarInfo;
using SmartParking.BusinessLogic.Queries.DeleteFromParkingPlacesByPlate;
using SmartParking.BusinessLogic.Queries.GetCarSizeFromDbByPlate;
using SmartParking.BusinessLogic.Queries.GetPlate;
using SmartParking.BusinessLogic.SensorApi;

namespace SmartParking.BusinessLogic;

public static class BusinessLogicServicesExtentions
{
    public static void AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<CommandInvoker>();
        services.AddHttpClient<IOLinkApiClient>();
        services.AddHttpClient<EntranceCamereApiClient>();
        services.AddHttpClient<ExitCameraApiClient>();
        services.AddScoped<ICommandHandler<GetEnteringCarInfoRequest, GetEnteringCarInfoResponse>, GetEnteringCarInfoHandler>();
        services.AddScoped<ICommandHandler<GetPlateRequest, GetPlateResponse>, GetPlateHandler>();
        services.AddScoped<ICommandHandler<GetCarSizeFromDbByPlateRequest, GetCarSizeFromDbByPlateResponse>, GetCarSizeFromDbByPlateHandler>();
        services.AddScoped<ICommandHandler<AddCarInDbRequest, AddCarInDbResponse>, AddCarInDbHandler>();
        services.AddScoped<ICommandHandler<DeleteFromParkingPlacesByPlateRequest, DeleteFromParkingPlacesByPlateResponse>, DeleteFromParkingPlacesByPlateHandler>();
    }
}