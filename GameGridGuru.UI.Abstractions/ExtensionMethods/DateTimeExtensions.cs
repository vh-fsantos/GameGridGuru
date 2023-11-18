namespace GameGridGuru.UI.Abstractions.ExtensionMethods;

public static class DateTimeExtensions
{
    public static DateTime IncrementWithTime(this DateTime date, TimeSpan time)
        => new DateTime(date.Year, date.Month, date.Day).Add(time);
}