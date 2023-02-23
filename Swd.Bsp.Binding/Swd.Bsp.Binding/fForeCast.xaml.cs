using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Swd.Bsp.Binding;

public partial class fForeCast : Window
{
    private Window _callerWindow;
    private int _minDaysForForeCast = 1;
    private int _maxDaysForForeCast = 10;
    
    public List<int> DaysForForecast { get; set; }
    public bool IsDegree { get; set; }
    
    public Window CallerWindow 
    {
        get
        {
            return _callerWindow;
        }
        set
        {
            _callerWindow = value;
        } 
    }
    
    public fForeCast()
    {
        InitializeComponent();

        this.IsDegree = true;
        
        DaysForForecast = new List<int>();
        for (int i = _minDaysForForeCast; i <= _maxDaysForForeCast; i++)
        {
            DaysForForecast.Add(i);
        }
        
        this.DataContext = this;
    }

    public fForeCast(Window callerWindows) : this()
    {
        _callerWindow = callerWindows;
    }

    private void BtnShowForecast_OnClick(object sender, RoutedEventArgs e)
    {
        List<ForeCast> foreCasts = new List<ForeCast>();

        int daysFoForeCast = (int)this.cbxDays.SelectedItem;
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

        this.lstForeCasts.DataContext = foreCasts;
    }

    //public int[] ComboBoxData { get; set; }
    
    private void FForeCast_OnLoaded(object sender, RoutedEventArgs e)
    {
        // Variante 1: Comboxitems zur Liste hinzufügen
        // for (int i = _minDaysForForeCast; i <= _maxDaysForForeCast; i++)
        // {
        //     ComboBoxItem item = new ComboBoxItem();
        //     item.Content = i;
        //     this.cbxDays.Items.Add(item);
        // }

        // Variante 2: Mit Itemsource
        // List<int> daysForForecast = new List<int>();
        // for (int i = _minDaysForForeCast; i <= _maxDaysForForeCast; i++)
        // {
        //     daysForForecast.Add(i);
        // }
        // this.cbxDays.ItemsSource = daysForForecast;
    }
}