using GameGridGuru.Domain.Models;

namespace GameGridGuru.UI.Converters;

public class SelectedItemBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (parameter is string parameterValue && parameterValue.Equals("true", StringComparison.OrdinalIgnoreCase) && value is Card card)
        {
            return card.Reservation == null;
        }
        
        return value is not null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}