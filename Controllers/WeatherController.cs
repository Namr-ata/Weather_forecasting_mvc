using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Weather_Forecast_MVC.Models;

namespace Weather_Forecast_MVC.Controllers
{
    public class WeatherController : Controller

    {
       
         private readonly IHttpClientFactory _httpClientFactory;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = "8c0e509ed95eb8d3ff265c0abfb6fbc2";
            string city = "kathmandu"; // Example city
           

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            var client = _httpClientFactory.CreateClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(responseBody);

                return View(weatherData);
            }
            catch (HttpRequestException)
            {
                // Handle error
                return View("Error");
            }
        }
    }
}
