using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfConverterApp.Converter
{
    [ValueConversion(typeof(byte), typeof(Brush))]
    public class ConverterByteToBrush : IValueConverter
    {
        // конвертация данных из объекта привязки в интерфейс
        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            byte val = byte.Parse(value.ToString());
            if (val < 5)
                return Brushes.White;
            else if (val < 50)
                return Brushes.LightGreen;
            else if (val < 75)
                return Brushes.Orange;
            else
                return Brushes.Red;
        }
        // обратное направление (из интерфейса в свойство)
        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConverterTovarToActualPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;
            Tovar tovar = value as Tovar;
            var price = tovar.Price - (tovar.Price / 100 * tovar.Discount);
            return price;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
