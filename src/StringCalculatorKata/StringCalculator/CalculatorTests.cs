

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("4", 4)]
    [InlineData("443", 443)]
    [InlineData("-43", -43)]
    [InlineData("0", 0)]
    public void SingleDigit(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,-2", -1)]
    [InlineData("1,200", 201)]
    [InlineData("-1,-2", -3)]
    [InlineData("1000,2", 1002)]
    public void TwoDigitsComma(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,2", 5)]
    [InlineData("1,-2,2", 1)]
    [InlineData("1,200,5", 206)]
    [InlineData("-1,-2,10", 7)]
    [InlineData("1000,2,1,1,1,1,1,1,1,2", 1011)]
    public void NDigitsComma(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2\n2", 5)]
    [InlineData("1,-2,2", 1)]
    [InlineData("1\n200,5", 206)]
    [InlineData("-1,-2\n10", 7)]
    [InlineData("1000,2\n1\n1,1,1,1\n1,1\n2", 1011)]
    public void NDigitsMixed(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    [InlineData("1\n@200,$5", 206)]
    [InlineData("-1,%$@-2\n@#10", 7)]
    [InlineData("1000,2\n1$#@#$\n1,1,1,1\n@#$#@1,1\n2", 1011)]
    public void NDigitsCustom(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }
}
