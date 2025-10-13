namespace Nextensions;

/// <summary>
/// Extension methods for DateTime type.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Computes a human-readable duration between two DateTime instances.
    /// </summary>
    /// <param name="from">The start DateTime.</param>
    /// <param name="to">The end DateTime.</param>
    /// <returns>A human-readable duration string including years, months, days, hours, minutes, and seconds.</returns>
    public static string ToReadableDuration(this DateTime from, DateTime to)
    {
        // Swap if to is before from to ensure positive duration
        if (to < from)
        {
            (from, to) = (to, from);
        }

        var parts = new List<string>();

        // Calculate years
        int years = to.Year - from.Year;
        if (to.Month < from.Month || (to.Month == from.Month && to.Day < from.Day))
        {
            years--;
        }

        // Calculate months
        int months = to.Month - from.Month;
        if (months < 0)
        {
            months += 12;
        }
        if (to.Day < from.Day)
        {
            months--;
            if (months < 0)
            {
                months += 12;
                years--;
            }
        }

        // Create a temporary date to calculate the remaining time
        var tempDate = from.AddYears(years).AddMonths(months);
        
        // Calculate remaining days, hours, minutes, seconds
        var remainingTime = to - tempDate;
        int days = remainingTime.Days;
        int hours = remainingTime.Hours;
        int minutes = remainingTime.Minutes;
        int seconds = remainingTime.Seconds;

        // Build the readable string
        if (years > 0)
            parts.Add($"{years}y");

        if (months > 0)
            parts.Add($"{months}mo");

        if (days > 0)
            parts.Add($"{days}d");

        if (hours > 0)
            parts.Add($"{hours}h");

        if (minutes > 0)
            parts.Add($"{minutes}m");

        if (seconds > 0)
            parts.Add($"{seconds}s");

        return parts.Count > 0 ? string.Join(" ", parts) : "0s";
    }
}
