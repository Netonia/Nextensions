# Nextensions

A .NET utility library providing extension methods for common types to simplify development.

## Features

Nextensions provides intuitive extension methods for working with time-related operations:

- **int.ToMinutesAndSeconds()** - Convert seconds to minutes and seconds
- **TimeSpan.ToReadableDuration()** - Format TimeSpan as human-readable text
- **DateTime.ToReadableDuration()** - Calculate duration between two dates

## Quick Start

```csharp
using Nextensions;

// Convert seconds to minutes and seconds
int totalSeconds = 1000;
var (minutes, seconds) = totalSeconds.ToMinutesAndSeconds();
// Result: minutes = 16, seconds = 40

// Format TimeSpan as readable text
TimeSpan ts = TimeSpan.FromSeconds(1000);
string readable = ts.ToReadableDuration();
// Result: "16m 40s"

// Calculate duration between dates
DateTime from = new DateTime(2023, 1, 1);
DateTime to = DateTime.Now;
string result = from.ToReadableDuration(to);
// Result: e.g. "2y 9mo 12d 3h 15m 40s"
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
