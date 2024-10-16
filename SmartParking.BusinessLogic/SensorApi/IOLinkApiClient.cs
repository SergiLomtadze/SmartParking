using SmartParking.Shared;
using System.Text.Json;

namespace SmartParking.BusinessLogic.SensorApi;

public class IOLinkApiClient(HttpClient httpClient)
{
    public async Task<SensorsData> GetAnalogValueAsync()
    {
        var sensonData = new SensorsData();

        var url1 = "http://192.168.0.2/iolink/v1/devices/master1port1/processdata/value?format=iodd";
        var url2 = "http://192.168.0.2/iolink/v1/devices/master1port2/processdata/value?format=iodd";
        var url3 = "http://192.168.0.2/iolink/v1/devices/master1port3/processdata/value?format=iodd";
        var url4 = "http://192.168.0.2/iolink/v1/devices/master1port4/processdata/value?format=iodd";

        sensonData.Sensor1 = await GetAnalogValueAsyncFromSensor(url1);
        sensonData.Sensor2 = await GetAnalogValueAsyncFromSensor(url2);
        sensonData.Sensor3 = await GetAnalogValueAsyncFromSensor3(url3);
        sensonData.Sensor4 = await GetAnalogValueAsyncFromSensor(url4);

        return sensonData;
    }

    private async Task<int?> GetAnalogValueAsyncFromSensor(string url)
    {
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the response JSON
        var jsonString = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

        // Extract and return the Analog_value
        return apiResponse?.GetData?.IOLink?.Value?.AnalogValue?.Value;
    }

    private async Task<int?> GetAnalogValueAsyncFromSensor3(string url)
    {
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize using ApiResponseForSensor3 class
        var jsonString = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponseForSensor3>(jsonString);

        // Extract and return the Distance_to_Object_in__mm_ value
        return apiResponse?.GetData?.IOLink?.Value?.DistanceToObjectInMm?.Value;
    }
}
