using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Calc.Pages
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
    public class WeatherForecastBase : ComponentBase
    {
        protected WeatherForecast[] forecasts;
    }
}
