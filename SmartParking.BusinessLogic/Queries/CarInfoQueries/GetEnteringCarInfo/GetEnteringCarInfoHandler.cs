using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.BusinessLogic.SensorApi;
using SmartParking.Shared;

namespace SmartParking.BusinessLogic.Queries.CarInfoQueries.GetEnteringCarInfo;

public class GetEnteringCarInfoHandler(IOLinkApiClient ioLinkApiClient)
    : ICommandHandler<GetEnteringCarInfoRequest, GetEnteringCarInfoResponse>
{
    public async Task<GetEnteringCarInfoResponse> Handle(GetEnteringCarInfoRequest command)
    {
        var analogValue = await ioLinkApiClient.GetAnalogValueAsync();

        return new GetEnteringCarInfoResponse
        {
            FirtSensorDistance = analogValue.Sensor1,
            CarSize = ParkingTypeHelper.GetCarSize(analogValue)
        };
    }
}