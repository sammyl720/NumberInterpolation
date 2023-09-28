using System.Numerics;

namespace NumberInterpolation
{

    /// <summary>
    /// Represents a floating point numeric range with minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The numeric type of the range.</typeparam>
    public abstract class NumericRange<T> where T : INumber<T>, IComparable<T>
	{
        /// <summary>
        /// Gets the minimum value of the range.
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// Gets the maximum value of the range.
        /// </summary>
		public readonly T Maximum;

        public NumericRange(T min, T max)
        {
            if (min.CompareTo(max) >= 0)
            {
                throw new ArgumentException($"Minimum value {min} should be less than maximum value {max}.");
            }

            Minimum = min;
            Maximum = max;
        }

        /// <summary>
        /// Gets the value corresponding to a given percentage within the range.
        /// </summary>
        /// <param name="percentage">The percentage to calculate the value for.</param>
        /// <returns>The calculated value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when percentage is not within the range of 0 and 1.</exception>
        public T GetValueByPercentage(T percentage)
		{
			return GetValueByPercentage(Minimum, Maximum, percentage);
		}

        /// <summary>
        /// Gets the percentage corresponding to a given value within the range.
        /// </summary>
        /// <param name="value">The value to calculate the percentage for.</param>
        /// <returns>The calculated percentage.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is not within the range of the minimum and maximum</exception>
        public T GetPercentageByValue(T value)
		{
			return GetPercentageByValue(Minimum, Maximum, value);
		}

        /// <summary>
        /// Clamps a value to be within the range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
		public T Clamp(T value)
		{
			return Clamp(value, Minimum, Maximum);
		}

        /// <summary>
        /// Interpolates a value from this range to another range.
        /// </summary>
        /// <param name="other">The target range for interpolation.</param>
        /// <param name="value">The value to interpolate.</param>
        /// <returns>The interpolated value in the target range.</returns>
		public T Interpolate(NumericRange<T> other, T value)
		{
			var targetPercentage = GetPercentageByValue(Minimum, Maximum, value);
			
            return GetValueByPercentage(
					other.Minimum,
					other.Maximum,
					targetPercentage
				);
		}

        /// <summary>
        /// Gets the value corresponding to a given percentage within a range.
        /// </summary>
        /// <param name="percentage">The percentage to calculate the value for.</param>
        /// <param name="minimum">The minimum value of the range</param>
        /// <param name="maximum">The maximum value of the range</param>
        /// <returns>The calculated value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when percentage is not within the range of 0 and 1.</exception>
        /// <exception cref="ArgumentException">Thrown when minimum is greater than or equal to maximum.</exception>

        public static K GetValueByPercentage<K>(K minimum, K maximum, K percentage) where K : INumber<K>, IComparable<K>
        {
            if (!percentage.IsValidPercentage())
            {
                throw ExceptionHelpers.GetPercentageOutOfRangeException(percentage);
            }
			else if (minimum >= maximum)
            {
                throw ExceptionHelpers.GetMinGreaterThanMaxException(minimum, maximum);
            }

            return minimum * (K.One - percentage) + maximum * percentage;
        }

        /// <summary>
        /// Gets the percentage corresponding to a given value within a range.
        /// </summary>
        /// <param name="minimum">The minimum value of the range</param>
        /// <param name="maximum">The maximum value of the range</param>
        /// <param name="value">The value to calculate the percentage for.</param>
        /// <returns>The calculated percentage.</returns>
        /// <exception cref="ArgumentException">Thrown when minimum is not less than maximum</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is not within the range of the minimum and maximum</exception>
        public static K GetPercentageByValue<K>(K minimum, K maximum, K value) where K : INumber<K>, IComparable<K>
		{
            if (!value.IsWithinRange(minimum, maximum))
            {
                throw ExceptionHelpers.GetValueOutOfRangeException(value, minimum, maximum);
            }
			else if (minimum >= maximum)
            {
                throw ExceptionHelpers.GetMinGreaterThanMaxException(minimum, maximum);
            }

            return (value - minimum) / (maximum - minimum);
        }

        /// <summary>
        /// Clamps a value to be within a range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="minimum">The minimum value of the range</param>
        /// <param name="maximum">The maximum value of the range</param>
        /// <returns>The clamped value.</returns>
        /// <exception cref="ArgumentException">Thrown when minimum is not less than maximum</exception>
        public static K Clamp<K>(K value, K minimum, K maximum) where K : INumber<K>, IComparable<K>
		{
            if (minimum >= maximum)
            {
                throw ExceptionHelpers.GetMinGreaterThanMaxException(minimum, maximum);
            }

            return Min(maximum, Max(minimum, value));
        }

		private static K Min<K>(params K[] numbers) where K : INumber<K>, IComparable<K>
		{
			return numbers.Min()!;
		}

        private static K Max<K>(params K[] numbers) where K : INumber<K>, IComparable<K>
        {
            return numbers.Max()!;
        }
    }

    /// <inheritdoc />
    public class DecimalRange : NumericRange<decimal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalRange"/> class.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <exception cref="ArgumentException">Thrown when min is greater than or equal to max.</exception>
        public DecimalRange(decimal minimum, decimal maximum) : base(minimum, maximum)
        {

        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DoubleRange"/> class.
    /// </summary>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <exception cref="ArgumentException">Thrown when min is greater than or equal to max.</exception>
    public class DoubleRange : NumericRange<double>
    {
        public DoubleRange(double minimum, double maximum) : base(minimum, maximum)
        {
        }
    }

    /// <inheritdoc />
    public class FloatRange : NumericRange<float>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatRange"/> class.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <exception cref="ArgumentException">Thrown when min is greater than or equal to max.</exception>
        public FloatRange(float minimum, float maximum) : base(minimum, maximum)
        {
        }
    }

}
