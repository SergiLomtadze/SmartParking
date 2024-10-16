using SmartParking.BusinessLogic.EntranceCamereApi;
using System.Text.Json;

namespace SmartParking.BusinessLogic.ExitCameraApi;

public class ExitCameraApiClient(HttpClient httpClient)
{
    public async Task<string> GetAnalogValueAsync()
    {
        var url = "http://192.168.0.2/iolink/v1/devices/master1port1/processdata/value?format=iodd";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the response JSON
        var jsonString = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<EntranceCameraApiResponse>(jsonString);

        // Extract and return the Analog_value
        return apiResponse.Plate;

    }
}