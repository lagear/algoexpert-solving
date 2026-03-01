using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[McpServerToolType]
public class WeatherTools(IHttpClientFactory httpClientFactory)
{
    [McpServerTool, Description("Gets the weather for a given city and date.")]
    public async Task<string> GetWeather(
        [Description("The name of the city")] string city,
        [Description("Date in yyyy-MM-dd format. Defaults to today.")] string? date = null)
    {
        double? lat = null, lon = null;
        string? weatherUrl = null;

        try
        {
            var targetDate = date is null ? DateOnly.FromDateTime(DateTime.Today) : DateOnly.Parse(date);
            var dateStr = targetDate.ToString("yyyy-MM-dd");

            var http = httpClientFactory.CreateClient("weather");

            // 1. Geocoding — resolve city to lat/lon
            var geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(city)}&count=1";
            var geoResponse = await http.GetStringAsync(geoUrl);
            var geoDoc = JsonDocument.Parse(geoResponse);

            if (!geoDoc.RootElement.TryGetProperty("results", out var results) || results.GetArrayLength() == 0)
                return JsonSerializer.Serialize(new { error = $"City '{city}' not found." });

            var location = results[0];
            lat = location.GetProperty("latitude").GetDouble();
            lon = location.GetProperty("longitude").GetDouble();
            var name = location.GetProperty("name").GetString();
            var country = location.GetProperty("country").GetString();

            if (lat < -90 || lat > 90 || lon < -180 || lon > 180)
                return JsonSerializer.Serialize(new { error = $"Invalid coordinates returned for '{city}': lat={lat}, lon={lon}." });

            // 2. Weather — use archive for past dates, forecast for today/future
            var isPast = targetDate < DateOnly.FromDateTime(DateTime.Today);
            var baseUrl = isPast
                ? "https://archive-api.open-meteo.com/v1/archive"
                : "https://api.open-meteo.com/v1/forecast";

            weatherUrl = FormattableString.Invariant($"{baseUrl}?latitude={lat}&longitude={lon}") +
                             $"&daily=temperature_2m_max,temperature_2m_min,weather_code,wind_speed_10m_max" +
                             $"&temperature_unit=fahrenheit&start_date={dateStr}&end_date={dateStr}";

            var weatherResponse = await http.GetStringAsync(weatherUrl);
            var weatherDoc = JsonDocument.Parse(weatherResponse);
            var daily = weatherDoc.RootElement.GetProperty("daily");

            var result = new
            {
                city = name,
                country,
                date = dateStr,
                latitude = lat,
                longitude = lon,
                temperature_max_f = daily.GetProperty("temperature_2m_max")[0].GetDouble(),
                temperature_min_f = daily.GetProperty("temperature_2m_min")[0].GetDouble(),
                windspeed_max_mph = daily.GetProperty("wind_speed_10m_max")[0].GetDouble(),
                weathercode = daily.GetProperty("weather_code")[0].GetInt32()
            };

            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new
            {
                error = true,
                message = ex.Message,
                parameters = new { city, date },
                resolvedCoordinates = new { latitude = lat, longitude = lon },
                weatherUrl,
                stackTrace = ex.StackTrace
            }, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
