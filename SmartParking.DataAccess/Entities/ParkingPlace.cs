using System.ComponentModel.DataAnnotations;

namespace SmartParking.DataAccess.Entities;

public class ParkingPlace
{
    [Key]
    public int Id { get; set; }
    public string PlaceName { get; set; }
    public int Count { get; set; }
    public int TotalAmount { get; set; }
}
