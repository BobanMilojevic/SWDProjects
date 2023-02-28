using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Bsp.Binding.Model;

namespace Swd.Bsp.Binding.ViewModel;

public class fForecastViewModel : ObservableObject
{
    // Fields
    private int _minDaysForForeCast = 1;
    private int _maxDaysForForeCast = 10;

    public fForecastViewModel()
    {
        this.IsDegree = true;

        CloseCommand = new RelayCommand(CloseView);
        
        DaysForForecast = BuildDaysForForecastList(_minDaysForForeCast, _maxDaysForForeCast);
    }

    private void CloseView()
    {
        MessageBox.Show("Close");
    }

    // Properties
    public bool IsDegree { get; set; }
    public List<int> DaysForForecast { get; set; }
    public List<ForeCast> ForecastList { get; set; }

    
    //Commands
    public ICommand ShowForecastCommand { get; }
    public ICommand LoadForecastCommand { get; }
    public ICommand CloseCommand { get; }
    
    
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