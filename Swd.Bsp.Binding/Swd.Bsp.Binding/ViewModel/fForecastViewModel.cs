using System;
using System.Collections.Generic;
using System.Linq;
using Swd.Bsp.Binding.Model;

namespace Swd.Bsp.Binding.ViewModel;

public class fForecastViewModel
{
    // Fields
    private int _minDaysForForeCast = 1;
    private int _maxDaysForForeCast = 10;

    public fForecastViewModel()
    {
        this.IsDegree = true;
        DaysForForecast = BuildDaysForForecastList(_minDaysForForeCast, _maxDaysForForeCast);
    }
    
    // Properties
    public bool IsDegree { get; set; }
    public List<int> DaysForForecast { get; set; }
    public List<ForeCast> ForecastList { get; set; }

    
    private List<int> BuildDaysForForecastList(int _minDaysForForeCast, int _maxDaysForForeCast)
    {
        return Enumerable.Range(_minDaysForForeCast, _maxDaysForForeCast).ToList();
    }

    private void GetForcast()
    {
        List<ForeCast> foreCasts = new List<ForeCast>();

        //int daysFoForeCast = (int)this.cbxDays.SelectedItem;
        int daysFoForeCast = 5;
        Random random = new Random();
        
        for (int i = 0; i < daysFoForeCast; i++)
        {
            ForeCast foreCast = new ForeCast
            {
                GeneralForecast = (GeneralForecast)random.Next(Enum.GetValues(typeof(GeneralForecast)).Length),
                TemperatureLow = 0,
                TemperatureHigh = 20
            };
            foreCasts.Add(foreCast);
        }

        ForecastList = foreCasts;
    }
}