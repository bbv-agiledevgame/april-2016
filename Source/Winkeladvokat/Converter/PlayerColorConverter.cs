namespace Winkeladvokat.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using Models;

    public class PlayerColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var playerColors = new Dictionary<PlayerColor, Color>
            {
                { PlayerColor.Player1, (Color)Application.Current.Resources["Player1"] },
                { PlayerColor.Player2, (Color)Application.Current.Resources["Player2"] },
                { PlayerColor.Player3, (Color)Application.Current.Resources["Player3"] },
                { PlayerColor.Player4, (Color)Application.Current.Resources["Player4"] }
            };

            Color? color = value != null && playerColors.ContainsKey((PlayerColor)value)
                ? playerColors[(PlayerColor)value]
                : (Color?)null;

            if (color == null)
            {
                throw new InvalidColorException();
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public class InvalidColorException : Exception
        {
        }
    }
}
