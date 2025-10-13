# API Reference

## IntExtensions

### `ToMinutesAndSeconds()`

Converts a total number of seconds into minutes and remaining seconds.

**Signature:**
```csharp
public static (int Minutes, int Seconds) ToMinutesAndSeconds(this int totalSeconds)
```

**Parameters:**
- `totalSeconds` (int): The total number of seconds to convert

**Returns:**
- A tuple containing:
  - `Minutes` (int): The number of complete minutes
  - `Seconds` (int): The remaining seconds after extracting minutes

**Example:**
```csharp
using Nextensions;

int totalSeconds = 1000;
var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();
// minutes = 16, seconds = 40
```

**Notes:**
- Returns a tuple `(Minutes, Seconds)`
- Handles any non-negative integer value
- For values less than 60 seconds, `Minutes` will be 0

---

## TimeSpanExtensions

### `ToReadableDuration()`

Formats a `TimeSpan` into a human-readable string including days, hours, minutes, and seconds.

**Signature:**
```csharp
public static string ToReadableDuration(this TimeSpan ts)
```

**Parameters:**
- `ts` (TimeSpan): The TimeSpan to format

**Returns:**
- A human-readable duration string

**Example:**
```csharp
using Nextensions;

TimeSpan ts = TimeSpan.FromSeconds(1000);
string readable = ts.ToReadableDuration();
// "16m 40s"

TimeSpan longDuration = new TimeSpan(2, 3, 15, 30);
string longReadable = longDuration.ToReadableDuration();
// "2d 3h 15m 30s"
```

**Notes:**
- Omits zero-value units for brevity
- Formats as `[Xd] [Xh] [Xm] [Xs]` where X is the numeric value
- Returns `"0s"` for zero duration
- Only includes non-zero components

---

## DateTimeExtensions

### `ToReadableDuration(DateTime to)`

Computes a human-readable duration between two `DateTime` instances including years, months, days, hours, minutes, and seconds.

**Signature:**
```csharp
public static string ToReadableDuration(this DateTime from, DateTime to)
```

**Parameters:**
- `from` (DateTime): The start DateTime
- `to` (DateTime): The end DateTime

**Returns:**
- A human-readable duration string

**Example:**
```csharp
using Nextensions;

DateTime from = new DateTime(2023, 1, 1);
DateTime to = new DateTime(2025, 10, 13);
string result = from.ToReadableDuration(to);
// e.g. "2y 9mo 12d"

DateTime start = new DateTime(2023, 1, 1, 10, 0, 0);
DateTime end = new DateTime(2023, 1, 1, 12, 0, 30);
string shortResult = start.ToReadableDuration(end);
// "2h 30s"
```

**Notes:**
- Automatically calculates years and months based on calendar differences
- Dynamically includes only relevant units (non-zero values)
- Formats as `[Xy] [Xmo] [Xd] [Xh] [Xm] [Xs]`
- Returns `"0s"` if both dates are identical
- Only includes non-zero components
