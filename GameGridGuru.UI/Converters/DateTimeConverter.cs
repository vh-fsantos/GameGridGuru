namespace GameGridGuru.UI.Converters;

public class DateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}