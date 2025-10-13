namespace Nextensions.Tests;

public class DateTimeExtensionsTests
{
    [Fact]
    public void ToReadableDuration_WithSimpleTimeSpan_ReturnsCorrectFormat()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 1, 0, 0, 0);
        DateTime to = new DateTime(2023, 1, 1, 3, 15, 40);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("3h 15m 40s", result);
    }

    [Fact]
    public void ToReadableDuration_WithYearsMonthsDays_ReturnsCorrectFormat()
    {
        // Arrange
        DateTime from = new DateTime(2021, 3, 15, 10, 0, 0);
        DateTime to = new DateTime(2023, 12, 27, 13, 15, 40);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Contains("2y", result);
        Assert.Contains("9mo", result);
    }

    [Fact]
    public void ToReadableDuration_WithSwappedDates_SwapsAndReturnsPositiveDuration()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 1, 3, 15, 40);
        DateTime to = new DateTime(2023, 1, 1, 0, 0, 0);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("3h 15m 40s", result);
    }

    [Fact]
    public void ToReadableDuration_WithSameDates_ReturnsZeroSeconds()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 1, 12, 0, 0);
        DateTime to = new DateTime(2023, 1, 1, 12, 0, 0);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("0s", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlyDays_ReturnsOnlyDays()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 1);
        DateTime to = new DateTime(2023, 1, 6);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("5d", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlyMonths_ReturnsOnlyMonths()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 15);
        DateTime to = new DateTime(2023, 4, 15);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("3mo", result);
    }

    [Fact]
    public void ToReadableDuration_WithOnlyYears_ReturnsOnlyYears()
    {
        // Arrange
        DateTime from = new DateTime(2020, 6, 1);
        DateTime to = new DateTime(2023, 6, 1);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("3y", result);
    }

    [Fact]
    public void ToReadableDuration_OmitsZeroUnits()
    {
        // Arrange
        DateTime from = new DateTime(2023, 1, 1, 10, 0, 0);
        DateTime to = new DateTime(2023, 1, 1, 12, 0, 30);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Equal("2h 30s", result);
        Assert.DoesNotContain("m", result.Replace("mo", ""));
    }

    [Fact]
    public void ToReadableDuration_WithComplexDuration_IncludesAllNonZeroUnits()
    {
        // Arrange
        DateTime from = new DateTime(2020, 3, 10, 5, 20, 10);
        DateTime to = new DateTime(2023, 7, 15, 8, 35, 25);

        // Act
        string result = from.ToReadableDuration(to);

        // Assert
        Assert.Contains("y", result);
        Assert.Contains("mo", result);
        Assert.Contains("d", result);
        Assert.Contains("h", result);
        Assert.Contains("m", result);
        Assert.Contains("s", result);
    }
}
