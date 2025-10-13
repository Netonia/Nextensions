# Nextensions PRD

## Overview
`Nextensions` is a .NET utility library providing extension methods for common types to simplify development. This PRD covers extensions for `int`, `TimeSpan`, and `DateTime` for handling durations and human-readable formatting.

---

## 1. `int.ToMinutesAndSeconds()`

**Type:** `int` (seconds)  
**Purpose:** Converts a total number of seconds into minutes and remaining seconds.  

**Signature:**
```csharp
public static (int Minutes, int Seconds) ToMinutesAndSeconds(this int totalSeconds)
```

**Example:**
```csharp
int totalSeconds = 1000;
var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();
// minutes = 16, seconds = 40
```

**Notes:**
- Returns a tuple `(Minutes, Seconds)`.
- Handles any non-negative integer value.

---

## 2. `TimeSpan.ToReadableDuration()`

**Type:** `TimeSpan`  
**Purpose:** Formats a `TimeSpan` into a human-readable string including days, hours, minutes, and seconds.  

**Signature:**
```csharp
public static string ToReadableDuration(this TimeSpan ts)
```

**Example:**
```csharp
TimeSpan ts = TimeSpan.FromSeconds(1000);
string readable = ts.ToReadableDuration();
// "16m 40s"
```

**Notes:**
- Omits zero-value units for brevity.
- Formats as `[Xd ] [Xh ] [Xm ] [Xs]`.

---

## 3. `DateTime.ToReadableDuration(DateTime reference)`

**Type:** `DateTime`  
**Purpose:** Computes a human-readable duration between the current instance and a reference date including years, months, days, hours, minutes, and seconds.  

**Signature:**
```csharp
public static string ToReadableDuration(this DateTime from, DateTime to)
```

**Example:**
```csharp
DateTime from = new DateTime(2023,1,1);
DateTime to = DateTime.Now;
string result = from.ToReadableDuration(to);
// e.g. "2y 9mo 12d 3h 15m 40s"
```

**Notes:**
- Automatically calculates years and months based on calendar differences.
- Dynamically includes only relevant units (non-zero).
- Swaps `from` and `to` if `to < from` to ensure positive duration.

---

## Usage Summary

| Extension | Input | Output | Notes |
|-----------|-------|--------|-------|
| `ToMinutesAndSeconds` | int seconds | (int Minutes, int Seconds) | Simple conversion |
| `TimeSpan.ToReadableDuration` | TimeSpan | string | Reads days, hours, minutes, seconds |
| `DateTime.ToReadableDuration` | DateTime | string | Reads years, months, days, hours, minutes, seconds |

---

## Goals
- Simplify duration formatting and calculations.
- Provide intuitive, human-readable outputs.
- Integrate seamlessly as extensions in the `Nextensions` library.

---

## Future Enhancements
- Support parsing human-readable duration strings (e.g., `"2y3d5h"`).  
- Localized formatting for different cultures.  
- Configurable unit display (e.g., always show minutes/seconds even if zero).

