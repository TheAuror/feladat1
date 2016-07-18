using System;
using System.ComponentModel;

namespace Dyntell1Beadando
{
    public enum AmountType { darab, Pár, Csomag, méter};

    public class Product : INotifyPropertyChanged, IDataErrorInfo
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

        public string Error
        {
            get { return this[nameof(ProductName)] ?? this[nameof(ProductNumber)] ?? this[nameof(BarCode)] ?? this[nameof(Amount)]; }
        }

        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case nameof(ProductName):
                        if (string.IsNullOrEmpty(ProductName))
                            return "Kérem adja meg a termék nevét!";
                        break;
                    case nameof(ProductNumber):
                        if (string.IsNullOrEmpty(ProductNumber))
                            return "Kérem adja meg a cikkszámot!";
                        break;
                    case nameof(BarCode):
                        if (string.IsNullOrEmpty(BarCode))
                            return "Kérem adja meg a vonalkódot!";
                        if (BarCode.Length != 13)
                            return "A vonalkód 13 számjegyből áll!";
                        break;
                }
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeepCopy(Product Product)
        {
            _productName = Product.ProductName;
            _productNumber = Product.ProductNumber;
            _barCode = Product.BarCode;
            _amuont = Product.Amount;
        }
    }
}
