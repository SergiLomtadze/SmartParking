using System.ComponentModel.DataAnnotations;

namespace SmartParking.DataAccess.Entities;

public class CarSize
{
    [Key]
    public int Id { get; set; }
    public string PlateNumber { get; set; }
    public string Size { get; set; }
}
