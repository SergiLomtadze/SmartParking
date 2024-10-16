using SmartParking.BusinessLogic.CommandExecutor;
using SmartParking.BusinessLogic.EntranceCamereApi;

namespace SmartParking.BusinessLogic.Queries.GetPlate;

public class GetPlateHandler(EntranceCamereApiClient entranceCamereApiClient)
    : ICommandHandler<GetPlateRequest, GetPlateResponse>
{
    public async Task<GetPlateResponse> Handle(GetPlateRequest command)
    {
        var plate = await entranceCamereApiClient.GetPlateAsync();

        return new GetPlateResponse
        {
            PlateNumber = plate
        };
    }
}