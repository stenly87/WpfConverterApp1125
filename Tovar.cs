using System.ComponentModel;

namespace WpfConverterApp
{
    public class Tovar : INotifyPropertyChanged
    {
        private byte discount;

        public string Title { get; set; }
        public decimal Price { get; set; }
        public byte Discount
        {
            get => discount;
            set
            {
                discount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Discount)));
                
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


}
