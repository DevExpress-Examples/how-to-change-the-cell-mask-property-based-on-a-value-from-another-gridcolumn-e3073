using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using DevExpress.Xpf.Grid;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace _2583___CellMaskBinding {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
    }

    public class MasksConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null)
                return null;
            return (Masks)value == Masks.Currency ? "c" : "d";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public enum Masks { Numeric, Currency };

    public class TestDataContainer {
        ObservableCollection<TestData> records;

        public TestDataContainer() {
            records = new ObservableCollection<TestData>(){
                    new TestData(Masks.Currency, 10123),
                    new TestData(Masks.Numeric, 10123),
                    new TestData(Masks.Numeric, 91234)
                };
        }

        public ObservableCollection<TestData> Records {
            get {
                return records;
            }
            set {
                records = value;
            }
        }

        public List<Masks> MaskTypes {
            get {
                return new List<Masks>(){Masks.Numeric, Masks.Currency};
            }
        }
    }

    public class TestData:INotifyPropertyChanged {
        Masks mask;
        public TestData() {
            mask = Masks.Numeric;
            Salary = 0;
        }

        public TestData( Masks mask, double salary ){
            MaskType = mask;
            Salary = salary;
        }
        public Masks MaskType{
            get {
                return mask;
            }
            set {
                mask = value;
                RaisePropertyChanged("MaskType");
            }
        }
        public double Salary {get; set;}

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
