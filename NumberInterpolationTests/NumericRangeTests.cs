using NumberInterpolation;

namespace NumberInterpolationTests;

[TestFixture]
public class NumericRangeTests
{
    [TestCase(5,4)]
    [TestCase(5,5)]
    public void Constructor_ThrowsException_IfMinIsGreaterOrEqualToMax(double min, double max)
    {
        Assert.Throws<ArgumentException>(() => new DoubleRange(min, max));
    }

    [TestCase(3.3)]
    [TestCase(-0.1)]
    public void GetPercentageValuge_ThrowsException_IfPercentageOutOfRange(decimal percentage)
    {
        var range = new DecimalRange(1, 100);
        Assert.Throws<ArgumentOutOfRangeException>(() => range.GetValueByPercentage(percentage));
    }

    [TestCase(0,100, 0.5, 50)]
    [TestCase(0, 100, 0, 0)]
    [TestCase(0, 100, 1, 100)]
    [TestCase(425, 935, 0.38, 618.8)]
    public void GetPercentageValue_ShouldReturnCorrectValue(decimal min, decimal max, decimal percentage, decimal expected)
    {
        var range = new DecimalRange(min, max);
        var result = range.GetValueByPercentage(percentage);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 200, 50, 0.25)]
    [TestCase(150, 250, 225, 0.75)]
    public void GetValuePercentage_ReturnsCorrectPercentage(decimal min, decimal max, decimal value, decimal expected)
    {
        var range = new DecimalRange(min, max);
        var result = range.GetPercentageByValue(value);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 200, 250)]
    [TestCase(150, 250, 100)]
    public void GetValuePercentage_ThrowsExceptionIfValueIsOutOfRange(decimal min, decimal max, decimal value)
    {
        var range = new DecimalRange(min, max);
        Assert.Throws<ArgumentOutOfRangeException>(() => range.GetPercentageByValue(value));
    }

    [TestCase(10, 45, 50, 45)]
    [TestCase(10, 45, 30, 30)]
    [TestCase(10, 45, 5, 10)]
    public void Clamp_ShouldReturnCorrectValue(decimal min, decimal max, decimal value, decimal expected)
    {
        var range = new DecimalRange(min, max);
        var result = range.Clamp(value);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0,800,0,500,40,25)]
    public void Interpolate_ShouldReturnCorrectValue(decimal minA, decimal maxA, decimal minB, decimal maxB, decimal value, decimal expected)
    {
        var firstRange = new DecimalRange(minA, maxA);
        var secondRange = new DecimalRange(minB, maxB);

        var result = firstRange.Interpolate(secondRange, value);
        Assert.That(result, Is.EqualTo(expected));
    }
}
