using System.Globalization;
using System.Linq.Expressions;
using System.Windows;
using FluentAssertions;
using Xunit;

namespace Winkeladvokat.Converter
{
    public class FieldValueToVisibilityConverterTest
    {
        [Theory]
        [InlineData(0, Visibility.Hidden)]
        [InlineData(1, Visibility.Visible)]
        [InlineData(-1, Visibility.Visible)]
        public void Convert_WhenValue_ThenSetVisibilityAccoridingToValue(int value, Visibility expectedResult)
        {
            FieldValueToVisibilityConverter testee = new FieldValueToVisibilityConverter();

            var result = testee.Convert(value, typeof(Visibility), null, CultureInfo.CurrentCulture);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(Visibility.Hidden)]
        [InlineData(Visibility.Visible)]
        [InlineData(Visibility.Collapsed)]
        public void ConvertBack_WhenValue_ThenAlwaysReturnZero(Visibility visibility)
        {
            const int expectedValue = 0;
            FieldValueToVisibilityConverter testee = new FieldValueToVisibilityConverter();

            var result = testee.ConvertBack(visibility, typeof(int), null, CultureInfo.CurrentCulture);

            result.Should().Be(expectedValue);
        }
    }
}