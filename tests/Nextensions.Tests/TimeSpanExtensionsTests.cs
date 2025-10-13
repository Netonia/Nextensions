namespace Nextensions.Tests;

public class TimeSpanExtensionsTests
{
    [Fact]
    public void ToReadableDuration_WithExampleFromPRD_ReturnsCorrectFormat()
    {
        // Arrange
        TimeSpan ts = TimeSpan.FromSeconds(1000);

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("16m 40s", result);
    }

    [Fact]
    public void ToReadableDuration_WithZeroDuration_ReturnsZeroSeconds()
    {
        // Arrange
        TimeSpan ts = TimeSpan.Zero;

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("0s", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlySeconds_ReturnsOnlySeconds()
    {
        // Arrange
        TimeSpan ts = TimeSpan.FromSeconds(45);

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("45s", result);
    }

    [Fact]
    public void ToReadableDuration_WithDaysHoursMinutesSeconds_ReturnsAllComponents()
    {
        // Arrange
        TimeSpan ts = new TimeSpan(2, 3, 15, 30); // 2 days, 3 hours, 15 minutes, 30 seconds

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("2d 3h 15m 30s", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlyDays_ReturnsOnlyDays()
    {
        // Arrange
        TimeSpan ts = TimeSpan.FromDays(5);

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("5d", result);
    }

    [Fact]
    public void ToReadableDuration_OmitsZeroUnits()
    {
        // Arrange
        TimeSpan ts = new TimeSpan(0, 2, 0, 30); // 2 hours and 30 seconds (no days, no minutes)

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("2h 30s", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlyMinutes_ReturnsOnlyMinutes()
    {
        // Arrange
        TimeSpan ts = TimeSpan.FromMinutes(10);

        // Act
        string result = ts.ToReadableDuration();

        // Assert
        Assert.Equal("10m", result);
    }
}
