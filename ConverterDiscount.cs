using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfConverterApp.Converter
{
    public class ConverterDiscount : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte val = byte.Parse(value.ToString());
            if (val < 5)
                return "Копейки";
            else if (val < 50)
                return "В принципе интересное предложение";
            else if (val < 75)
                return "Надо брать";
            else
                return "Слюшай, бесплатно отдаю, ага?";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;
            string str = value.ToString();
            if (string.IsNullOrEmpty(str))
                return 0;
            if (byte.TryParse(str, out byte val))
                return val;
            if (str == "Бесплатно")
                return 100;
            return 0;
        }
    }
}
