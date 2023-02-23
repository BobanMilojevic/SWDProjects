namespace Swd.Bsp.Binding;

public enum GeneralForecast
{
    Sunny,
    Dry,
    Rainy,
    Snowy,
    Cloudy
}

public class ForeCast
{
    public GeneralForecast GeneralForecast { get; set; }
    public double TemperatureHigh { get; set; }
    public double TemperatureLow { get; set; }
}