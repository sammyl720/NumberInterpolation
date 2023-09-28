# NumberInterpolation Library - README

## Introduction

Imagine you're a chef, and you have a recipe that serves 4 people, but you need to scale it up to serve 10. How do you figure out the new quantities for each ingredient? This is a classic example of interpolation, and the `NumberInterpolation` library is your kitchen assistant for such tasks, but in the realm of software.

The `NumberInterpolation` library provides a simple and efficient way to work with numeric ranges. It allows you to perform various operations like getting a value by percentage, clamping a value within a range, and even interpolating between two different ranges.

## Features

- **Generic Numeric Ranges**: Supports various numeric types like `float`, `double`, and `decimal`.
- **Value by Percentage**: Calculate a value based on a given percentage within a range.
- **Percentage by Value**: Find the percentage a value represents within a range.
- **Clamping**: Restrict a value to be within a given range.
- **Interpolation**: Interpolate a value from one range to another.

## Installation

Include the `NumberInterpolation` library in your project. If it's a NuGet package, you can install it using:

```bash
dotnet add package NumberInterpolation
```

## Quick Start

### Import the Namespace

```csharp
using NumberInterpolation;
```

### Create a Numeric Range

```csharp
var myRange = new FloatRange(0, 100);
```

### Get Value by Percentage

```csharp
float value = myRange.GetValueByPercentage(0.5f);  // Returns 50
```

### Get Percentage by Value

```csharp
float percentage = myRange.GetPercentageByValue(50);  // Returns 0.5
```

### Clamping a Value

```csharp
float clampedValue = myRange.Clamp(110);  // Returns 100
```

### Interpolating Between Ranges

```csharp
var anotherRange = new FloatRange(200, 300);
float interpolatedValue = myRange.Interpolate(anotherRange, 50);  // Returns 250
```

## API Documentation

### NumericRange<T>

This is the core class that represents a numeric range.

#### Properties

- `Minimum`: The minimum value of the range.
- `Maximum`: The maximum value of the range.

#### Methods

- `GetValueByPercentage(T percentage)`: Gets the value corresponding to a given percentage within the range.
- `GetPercentageByValue(T value)`: Gets the percentage corresponding to a given value within the range.
- `Clamp(T value)`: Clamps a value to be within the range.
- `Interpolate(NumericRange<T> other, T value)`: Interpolates a value from this range to another range.

### DecimalRange, DoubleRange, FloatRange

These are specialized classes that extend `NumericRange<T>` for `decimal`, `double`, and `float` types respectively.

## Exceptions

- `ArgumentException`: Thrown when the minimum value is greater than or equal to the maximum value.
- `ArgumentOutOfRangeException`: Thrown when the value or percentage is not within the valid range.

## Conclusion

Think of `NumberInterpolation` as your Swiss Army knife for dealing with numeric ranges. Whether you're scaling up a recipe, resizing images, or normalizing data, this library has got you covered.

Happy Coding! 🚀