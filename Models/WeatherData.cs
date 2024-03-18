namespace Weather_Forecast_MVC.Models
{
    public class WeatherData
    {
        public string? name { get; set; }
        public MainData? main { get; set; }
        public WeatherInfo[]? weather { get; set; }
    }
    public class MainData
    {
        public float? temp { get; set; }
    }

    public class WeatherInfo
    {
        public string? description { get; set; }
    }
}
