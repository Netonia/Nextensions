namespace Nextensions;

/// <summary>
/// Extension methods for int type.
/// </summary>
public static class IntExtensions
{
    /// <summary>
    /// Converts a total number of seconds into minutes and remaining seconds.
    /// </summary>
    /// <param name="totalSeconds">The total number of seconds.</param>
    /// <returns>A tuple containing minutes and remaining seconds.</returns>
    public static (int Minutes, int Seconds) ToMinutesAndSeconds(this int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return (minutes, seconds);
    }
}
