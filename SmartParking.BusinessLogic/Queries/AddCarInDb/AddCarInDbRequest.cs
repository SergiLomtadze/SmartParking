using SmartParking.BusinessLogic.CommandExecutor;

namespace SmartParking.BusinessLogic.Queries.AddCarInDb;

public class AddCarInDbRequest : ICommand<AddCarInDbResponse>
{
    public string PlateNumber { get; set; }
    public string CarSize { get; set; }
}
