using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Bsp.Binding.Model;

namespace Swd.Bsp.Binding.ViewModel;

public class fForecastViewModel : ObservableObject
{
    // Fields
    private int _minDaysForForeCast = 1;
    private int _maxDaysForForeCast = 10;
    private List<ForeCast> _forecastList;
    private bool _isDegree;
    private List<int> _daysForForecast;
    private int _selectedDays;


    public fForecastViewModel()
    {
        IsDegree = true;
        SelectedDays = 5;
        
        CloseCommand = new RelayCommand(CloseView);
        ShowForecastCommand = new RelayCommand(ShowForecast);
        
        DaysForForecast = BuildDaysForForecastList(_minDaysForForeCast, _maxDaysForForeCast);
    }

    
    //Commands
    public ICommand ShowForecastCommand { get; }
    public ICommand LoadForecastCommand { get; }
    public ICommand CloseCommand { get; }
    

    // Properties
    public bool IsDegree
    {
        get => _isDegree;
        set => SetProperty(ref _isDegree, value);
    }

    public int SelectedDays
    {
        get => _selectedDays;
        set
        {
            SetProperty(ref _selectedDays, value);
            GetForecast();
        }
    }
    
    public List<int> DaysForForecast 
    { 
        get => _daysForForecast; 
        set => SetProperty(ref _daysForForecast, value);
    }

    public List<ForeCast> ForecastList
    {
        get => _forecastList;
        set => SetProperty(ref _forecastList, value);
    }

    
    // Methodes
    private void CloseView()
    {
        MessageBox.Show("Close");
    }

    private void ShowForecast()
    {
        GetForecast();
    }
    
    private List<int> BuildDaysForForecastList(int _minDaysForForeCast, int _maxDaysForForeCast)
    {
        return Enumerable.Range(_minDaysForForeCast, _maxDaysForForeCast).ToList();
    }

    private void GetForecast()
    {
        List<ForeCast> foreCasts = new List<ForeCast>();

        int daysFoForeCast = SelectedDays;
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