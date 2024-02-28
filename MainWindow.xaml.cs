using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Tovar Tovar { get; set; } = new Tovar
        {
            Title = "Опоздание Глафиры",
            Price = 1000,
            Discount = 74
        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            // Конвертеры в WPF
            // существует интерфейс IValueConverter
            // в нем 2 метода для конвертации данных в интерфейс и обратно
            // порядок работы:
            // 1. Пишем класс конвертера
            // 2. Компилим приложение (чтобы получить в сборке скомпилированный класс конвертера)
            // 3. Прописываем конвертер в ресурсах (окна, app, или определенного контрола)
            // 3.1 Если конвертер находится в отдельном пространстве имен, добавляем ссылку на нужный namespace в теге window (page)
            // 3.2 Конвертеру в ресурсах нужно задать Key
            // 4. Указываем конвертер в привязке через свойство Converter={StaticResource=key}
        }
        Random rnd = new Random();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tovar.Discount = (byte)rnd.Next(0, 100);
            Tovar = new Tovar {
             Discount = Tovar.Discount,
              Price = Tovar.Price,
               Title = Tovar.Title, 
            };
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tovar"));
        }
    }
}
