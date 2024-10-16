using System.Text.Json;

namespace SmartParking.BusinessLogic.EntranceCamereApi;

public class EntranceCamereApiClient(HttpClient httpClient)
{
    public async Task<string> GetPlateAsync()
    {
        var url = "http://172.16.1.119:5000/";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Deserialize the response JSON
        var jsonString = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<EntranceCameraApiResponse>(jsonString);

        // Extract and return the Analog_value
        return apiResponse.Plate;

    }
}
