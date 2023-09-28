using System;
using System.Numerics;

namespace NumberInterpolation
{
	internal static class NumberExtensions
	{
		public static bool IsValidPercentage<T>(this T percentage) where T : INumber<T>, IComparable<T>
        {
            T zero = T.Zero;
            T one = T.One;

            return percentage.CompareTo(zero) >= 0 && percentage.CompareTo(one) <= 0;
        }

		public static bool IsWithinRange<T>(this T value, T minimum, T maximum) where T : INumber<T>
		{
			return value >= minimum && value <= maximum;
		}

        public static bool IsFloatingPoint<T>(this T number) where T : INumber<T>, IComparable<T>
        {
            return number is float ||
                   number is double ||
                   number is decimal;
        }
    }
}

