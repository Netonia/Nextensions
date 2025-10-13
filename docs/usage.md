# Usage Guide

This guide provides detailed examples and common use cases for Nextensions.

## Working with Seconds

The `ToMinutesAndSeconds()` extension makes it easy to convert a total number of seconds into a more readable format.

### Basic Usage

```csharp
using Nextensions;

// Convert seconds to minutes and seconds
int totalSeconds = 125;
var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();
// minutes = 2, seconds = 5
```

### Use Cases

**1. Display time in user interfaces:**
```csharp
int gameTime = 3661; // seconds
var (mins, secs) = gameTime.ToMinutesAndSeconds();
Console.WriteLine($"Time played: {mins}:{secs:D2}");
// Output: "Time played: 61:01"
```

**2. Process time calculations:**
```csharp
int processingTime = 1000;
var (m, s) = processingTime.ToMinutesAndSeconds();
Console.WriteLine($"Processing took {m} minutes and {s} seconds");
// Output: "Processing took 16 minutes and 40 seconds"
```

---

## Working with TimeSpan

The `ToReadableDuration()` extension for `TimeSpan` provides human-friendly output.

### Basic Usage

```csharp
using Nextensions;

TimeSpan duration = TimeSpan.FromSeconds(1000);
string readable = duration.ToReadableDuration();
Console.WriteLine(readable);
// Output: "16m 40s"
```

### Advanced Examples

**1. Displaying elapsed time:**
```csharp
DateTime startTime = DateTime.Now;
// ... some operation ...
DateTime endTime = DateTime.Now;
TimeSpan elapsed = endTime - startTime;
Console.WriteLine($"Operation completed in {elapsed.ToReadableDuration()}");
```

**2. Formatting various durations:**
```csharp
// Short duration
TimeSpan shortTime = TimeSpan.FromSeconds(45);
Console.WriteLine(shortTime.ToReadableDuration());
// Output: "45s"

// Medium duration
TimeSpan mediumTime = TimeSpan.FromMinutes(90);
Console.WriteLine(mediumTime.ToReadableDuration());
// Output: "1h 30m"

// Long duration
TimeSpan longTime = new TimeSpan(5, 12, 30, 45);
Console.WriteLine(longTime.ToReadableDuration());
// Output: "5d 12h 30m 45s"
```

**3. Zero duration:**
```csharp
TimeSpan zero = TimeSpan.Zero;
Console.WriteLine(zero.ToReadableDuration());
// Output: "0s"
```

---

## Working with DateTime

The `ToReadableDuration()` extension for `DateTime` calculates the duration between two dates, including years and months.

### Basic Usage

```csharp
using Nextensions;

DateTime birthDate = new DateTime(2000, 1, 1);
DateTime today = DateTime.Now;
string age = birthDate.ToReadableDuration(today);
Console.WriteLine($"Age: {age}");
// Output: e.g., "Age: 25y 9mo 12d"
```

### Advanced Examples

**1. Project timelines:**
```csharp
DateTime projectStart = new DateTime(2023, 1, 15);
DateTime projectEnd = new DateTime(2023, 6, 30);
string duration = projectStart.ToReadableDuration(projectEnd);
Console.WriteLine($"Project duration: {duration}");
// Output: "Project duration: 5mo 15d"
```

**2. Account age:**
```csharp
DateTime accountCreated = new DateTime(2020, 3, 10, 14, 30, 0);
DateTime now = DateTime.Now;
string accountAge = accountCreated.ToReadableDuration(now);
Console.WriteLine($"Account age: {accountAge}");
// Output: e.g., "Account age: 5y 7mo 3d 5h 15m 30s"
```

**3. Same-day durations:**
```csharp
DateTime morning = new DateTime(2023, 10, 13, 9, 0, 0);
DateTime afternoon = new DateTime(2023, 10, 13, 14, 30, 0);
string workTime = morning.ToReadableDuration(afternoon);
Console.WriteLine($"Work time: {workTime}");
// Output: "Work time: 5h 30m"
```

**4. Precise short durations:**
```csharp
DateTime start = new DateTime(2023, 1, 1, 10, 0, 0);
DateTime end = new DateTime(2023, 1, 1, 10, 0, 15);
string precise = start.ToReadableDuration(end);
Console.WriteLine(precise);
// Output: "15s"
```

---

## Summary Table

| Extension | Input | Output | Best For |
|-----------|-------|--------|----------|
| `ToMinutesAndSeconds` | int (seconds) | (int Minutes, int Seconds) | Simple second-to-minute conversions |
| `TimeSpan.ToReadableDuration` | TimeSpan | string | Formatting durations from .NET operations |
| `DateTime.ToReadableDuration` | DateTime, DateTime | string | Calculating age, project timelines, or date differences with calendar units |

---

## Tips

1. **Zero values are omitted**: All methods skip zero-value units for cleaner output
2. **Always positive**: The DateTime extension handles date order automatically
3. **Calendar-aware**: The DateTime extension correctly handles month and year boundaries
4. **Consistent format**: All methods use the same unit abbreviations (y, mo, d, h, m, s)
