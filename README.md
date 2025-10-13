# Nextensions

A .NET utility library providing extension methods for common types to simplify development.

## Features

### 1. `int.ToMinutesAndSeconds()`

Converts a total number of seconds into minutes and remaining seconds.

```csharp
using Nextensions;

int totalSeconds = 1000;
var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();
// minutes = 16, seconds = 40
```

### 2. `TimeSpan.ToReadableDuration()`

Formats a `TimeSpan` into a human-readable string including days, hours, minutes, and seconds.

```csharp
using Nextensions;

TimeSpan ts = TimeSpan.FromSeconds(1000);
string readable = ts.ToReadableDuration();
// "16m 40s"
```

### 3. `DateTime.ToReadableDuration(DateTime reference)`

Computes a human-readable duration between two `DateTime` instances including years, months, days, hours, minutes, and seconds.

```csharp
using Nextensions;

DateTime from = new DateTime(2023, 1, 1);
DateTime to = DateTime.Now;
string result = from.ToReadableDuration(to);
// e.g. "2y 9mo 12d 3h 15m 40s"
```

## Installation

Add the library to your project:

```bash
dotnet add reference path/to/Nextensions.csproj
```

Or include it as a NuGet package once published.

## Goals

- Simplify duration formatting and calculations
- Provide intuitive, human-readable outputs
- Integrate seamlessly as extensions in .NET projects

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## License

This project is open source.