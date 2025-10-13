namespace Nextensions.Tests;

public class IntExtensionsTests
{
    [Fact]
    public void ToMinutesAndSeconds_WithExampleFromPRD_ReturnsCorrectValues()
    {
        // Arrange
        int totalSeconds = 1000;

        // Act
        var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();

        // Assert
        Assert.Equal(16, minutes);
        Assert.Equal(40, seconds);
    }

    [Fact]
    public void ToMinutesAndSeconds_WithZeroSeconds_ReturnsZeroForBoth()
    {
        // Arrange
        int totalSeconds = 0;

        // Act
        var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();

        // Assert
        Assert.Equal(0, minutes);
        Assert.Equal(0, seconds);
    }

    [Fact]
    public void ToMinutesAndSeconds_WithExactMinutes_ReturnsNoRemainingSeconds()
    {
        // Arrange
        int totalSeconds = 120; // 2 minutes

        // Act
        var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();

        // Assert
        Assert.Equal(2, minutes);
        Assert.Equal(0, seconds);
    }

    [Fact]
    public void ToMinutesAndSeconds_WithLessThanOneMinute_ReturnsZeroMinutes()
    {
        // Arrange
        int totalSeconds = 45;

        // Act
        var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();

        // Assert
        Assert.Equal(0, minutes);
        Assert.Equal(45, seconds);
    }

    [Fact]
    public void ToMinutesAndSeconds_WithLargeValue_ReturnsCorrectValues()
    {
        // Arrange
        int totalSeconds = 3661; // 61 minutes and 1 second

        // Act
        var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();

        // Assert
        Assert.Equal(61, minutes);
        Assert.Equal(1, seconds);
    }
}
