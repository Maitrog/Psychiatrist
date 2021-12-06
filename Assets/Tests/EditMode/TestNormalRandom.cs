using NUnit.Framework;

public class TestNormalRandom
{
    [Test]
    public void WhenNormalRandomReturnIntValue_ThenItLessOrEqualMaxValue()
    {
        NormalRandom nr = new NormalRandom();
        int minValue = -5;
        int maxValue = 33;
        int first = nr.Next(minValue, maxValue);
        Assert.LessOrEqual(first, maxValue);
    }    
    [Test]
    public void WhenNormalRandomReturnIntValue_ThenItGreaterOrEqualMinValue()
    {
        NormalRandom nr = new NormalRandom();
        int minValue = -25;
        int maxValue = 9;
        int first = nr.Next(minValue, maxValue);
        Assert.GreaterOrEqual(first, minValue);
    }    
    [Test]
    public void WhenNormalRandomReturnDoubleValue_ThenItLessOrEqualMaxValue()
    {
        NormalRandom nr = new NormalRandom();
        double minValue = 5.9;
        double maxValue = 68.89;
        double first = nr.NextDouble(minValue, maxValue);
        Assert.LessOrEqual(first, maxValue);
    }    
    [Test]
    public void WhenNormalRandomReturnDoubleValue_ThenItGreaterOrEqualMinValue()
    {
        NormalRandom nr = new NormalRandom();
        double minValue = -9.83;
        double maxValue = 15.945;
        double first = nr.NextDouble(minValue, maxValue);
        Assert.GreaterOrEqual(first, minValue);
    }
}
