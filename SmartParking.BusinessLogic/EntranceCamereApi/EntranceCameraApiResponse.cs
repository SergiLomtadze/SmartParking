using System.Text.Json.Serialization;

namespace SmartParking.BusinessLogic.EntranceCamereApi;

public class EntranceCameraApiResponse
{
    [JsonPropertyName("number")]
    public string Plate { get; set; }
}
