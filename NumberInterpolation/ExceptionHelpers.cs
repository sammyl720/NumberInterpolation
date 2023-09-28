using System;
using System.Numerics;

namespace NumberInterpolation
{
	internal static class ExceptionHelpers
	{
		public static ArgumentException GetMinGreaterThanMaxException<T>(T min, T max) where T : INumber<T>
		{
            return new ArgumentException($"{nameof(min)} value should be less than {max} value.");
        }

		public static ArgumentOutOfRangeException GetPercentageOutOfRangeException<T>(T percentage) where T : INumber<T>
		{
			return new ArgumentOutOfRangeException($"{nameof(percentage)} should be between 0 and 1.");
		}

		public static ArgumentOutOfRangeException GetValueOutOfRangeException<T>(T value, T minimum, T maximum) where T : INumber<T>
		{
			return new ArgumentOutOfRangeException($"{nameof(value)} should be be within the range of the ${nameof(minimum)} and ${nameof(maximum)} values.");
		}
    }
}

