using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAwesomeApp.Data
{
    public class WeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async IAsyncEnumerable<WeatherForecast> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();

            for (int i = 0; i < 5; i++)
            {
                yield return await CreateWeatherForecastAsync(startDate, i, rng);
            }
        }

        private static async Task<WeatherForecast> CreateWeatherForecastAsync(
            DateTime startDate, 
            int index, 
            Random rng)
        {
            await Task.Delay(1000);
            return new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
