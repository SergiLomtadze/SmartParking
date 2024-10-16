using SmartParking.DataAccess.Enums;

namespace SmartParking.Shared;

public static class ParkingTypeHelper
{
    public static string GetCarSize(SensorsData sensonrsData)
    {
        if (sensonrsData.Sensor1.HasValue && sensonrsData.Sensor1.Value <= 51)
        {
            if (sensonrsData.Sensor4.HasValue && sensonrsData.Sensor4.Value < 370)
                return CarSize.ExtraLarge.ToString();

            if (sensonrsData.Sensor3.HasValue && sensonrsData.Sensor3.Value < 370)
                return CarSize.Large.ToString();

            if (sensonrsData.Sensor2.HasValue && sensonrsData.Sensor2.Value < 370)
                return CarSize.Medium.ToString();

            return CarSize.Small.ToString();
        }

        return null;
    }
}