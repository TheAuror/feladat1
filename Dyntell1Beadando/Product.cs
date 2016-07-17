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
            get
            {
                throw new NotImplementedException();
            }
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
                        break;
                    case nameof(Amount):
                        if (string.IsNullOrEmpty(Amount.ToString()))
                            return "Kérem adja meg a a mennyiségi egységet!";
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
    }
}
