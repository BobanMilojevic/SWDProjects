using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Swd.Bsp.Binding.Model;

public class TemperatureConverter : IMultiValueConverter
{
    public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isDegree = System.Convert.ToBoolean(value[1]);
        double temperature = System.Convert.ToDouble(value[0]);

        if (!isDegree)
        {
            return temperature * (9.0D / 5.0D) + 32;
        }
        else
        {
            return temperature;
        }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}