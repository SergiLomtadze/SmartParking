using System.Text.Json.Serialization;

namespace SmartParking.BusinessLogic.SensorApi
{
    public class ApiResponseForSensor3
    {
        [JsonPropertyName("getData")]
        public GetDataForSensor3 GetData { get; set; }
    }

    public class GetDataForSensor3
    {
        [JsonPropertyName("iolink")]
        public IOLinkForSensor3 IOLink { get; set; }

        [JsonPropertyName("iqValue")]
        public bool IqValue { get; set; }
    }

    public class IOLinkForSensor3
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }

        [JsonPropertyName("value")]
        public ValueForSensor3 Value { get; set; }
    }

    public class ValueForSensor3
    {
        [JsonPropertyName("Distance_to_Object_in__mm_")]
        public Distance DistanceToObjectInMm { get; set; }
    }

    public class Distance
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

}
