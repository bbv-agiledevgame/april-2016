namespace Winkeladvokat.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using Winkeladvokat.Models;

    public class PlayerColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var colorKey = (PlayerColor)value;
                switch (colorKey)
                {
                    case PlayerColor.Player1:
                        return Application.Current.Resources["Player1"];
                    case PlayerColor.Player2:
                        return Application.Current.Resources["Player2"];
                    case PlayerColor.Player3:
                        return Application.Current.Resources["Player3"];
                    case PlayerColor.Player4:
                        return Application.Current.Resources["Player4"];
                }
            }
            throw new InvalidColorException();
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
