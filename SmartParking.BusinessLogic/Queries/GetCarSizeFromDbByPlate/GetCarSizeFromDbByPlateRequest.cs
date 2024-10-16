using SmartParking.BusinessLogic.CommandExecutor;

namespace SmartParking.BusinessLogic.Queries.GetCarSizeFromDbByPlate;

public class GetCarSizeFromDbByPlateRequest : ICommand<GetCarSizeFromDbByPlateResponse>
{
    public string Plate { get; set; }
}
