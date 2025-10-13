namespace Nextensions;

/// <summary>
/// Extension methods for TimeSpan type.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Formats a TimeSpan into a human-readable string including days, hours, minutes, and seconds.
    /// </summary>
    /// <param name="ts">The TimeSpan to format.</param>
    /// <returns>A human-readable duration string.</returns>
    public static string ToReadableDuration(this TimeSpan ts)
    {
        var parts = new List<string>();

        if (ts.Days > 0)
            parts.Add($"{ts.Days}d");

        if (ts.Hours > 0)
            parts.Add($"{ts.Hours}h");

        if (ts.Minutes > 0)
            parts.Add($"{ts.Minutes}m");

        if (ts.Seconds > 0)
            parts.Add($"{ts.Seconds}s");

        return parts.Count > 0 ? string.Join(" ", parts) : "0s";
    }
}
