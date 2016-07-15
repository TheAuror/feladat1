using System;
using System.ComponentModel;

namespace Dyntell1Beadando
{
    public enum AmountType { darab, Pár, Csomag, méter};

    public class Product : INotifyPropertyChanged
    {
        private string _productName;
        private string _productNumber;
        private string _barCode;
        private AmountType _amuont;


        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (_productName == value) return;
                _productName = value;
                OnPropertyChanged();
            }
        }
        public string ProductNumber
        {
            get
            {
                return _productNumber;
            }
            set
            {
                if (_productNumber == value) return;
                _productNumber = value;
                OnPropertyChanged();
            }
        }
        public string BarCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                if (_barCode == value) return;
                _barCode = value;
                OnPropertyChanged();
            }
        }
        public AmountType Amount
        {
            get
            {
                return _amuont;
            }
            set
            {
                if (_amuont == value) return;
                _amuont = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
