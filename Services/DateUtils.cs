namespace MinimalAPiDemo.Services;

public class DateUtils : IDateUtils
{
    public DateOnly GetDateNow()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
}