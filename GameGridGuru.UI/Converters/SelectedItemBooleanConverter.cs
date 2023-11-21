using GameGridGuru.Domain.Models;

namespace GameGridGuru.UI.Converters;

public class SelectedItemBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is Card card)
        {
            if (parameter is string parameterValue && parameterValue.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                return card.Reservation == null && !card.IsClosed;
            }

            return !card.IsClosed;
        }
        
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}