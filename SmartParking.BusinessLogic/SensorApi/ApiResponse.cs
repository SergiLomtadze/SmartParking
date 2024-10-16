using System.Text.Json.Serialization;

namespace SmartParking.BusinessLogic.SensorApi;


public class ApiResponse
{
    [JsonPropertyName("getData")]
    public GetData GetData { get; set; }
}

public class GetData
{
    [JsonPropertyName("iolink")]
    public IOLink IOLink { get; set; }
}

public class IOLink
{
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    [JsonPropertyName("value")]
    public Value Value { get; set; }
}

public class Value
{
    [JsonPropertyName("Analog_value")]
    public AnalogValue AnalogValue { get; set; } // Adjust the property name for C#
}

public class AnalogValue
{
    [JsonPropertyName("value")]
    public int Value { get; set; }
}