using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFormsControls {
    public partial class Numpad : ContentView {
        private static double defaultVal = 6;
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create("EventName", typeof(double), typeof(Numpad), defaultVal,BindingMode.TwoWay);

        public double EventName {
            get {
                var x = GetValue(EventNameProperty);
                return (double)x;
            }
            set {
                
                SetValue(EventNameProperty, value);
                OnPropertyChanged("ViewValue");
                
            }
        }
        //private static void HandleButtonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var button = (ExtendedButton)bindable;
        //    button.UpdateButtonState();
        //}
        //public string Value { get; set; }
        public void NumButtonClicked(object sender, EventArgs e) {
            var button = (Button)sender;
            var neuerString = (EventName.ToString("N" + Dezimalstellen) + button.Text);
            neuerString = MoveDelimitter(neuerString);
            EventName = Double.Parse(neuerString);
        }
        private string MoveDelimitter(string neuerString) {
            neuerString = neuerString.Replace(".", "");
            neuerString = neuerString.Insert(neuerString.Length - Dezimalstellen, ".");
            return neuerString;
        }
        public void DelButtonClicked(object sender, EventArgs e) {
            var button = (Button)sender;
            var stringval = EventName.ToString("N"+Dezimalstellen);
            if (EventName < 0.0) {
                EventName = 0.00;
            } else {
                var neuerString = stringval.Substring(0, stringval.Length - 1);
                neuerString = MoveDelimitter(neuerString);
                EventName = Double.Parse(neuerString);
            }
        }
        public void OkButtonClicked(object sender, EventArgs e) {
            //this.Dezimalstellen = 0;
            //Value = Math.Round(Value, Dezimalstellen);

            OnOkayClicked(this,e);

            //lblValue.SetBinding(targetProperty: this.Value,"", stringFormat: "{0:0.00}");
        }
        private int _dezimalstellen = 2;
        public int Dezimalstellen {
            get {
                return _dezimalstellen;
            }
            set {
                _dezimalstellen = value;
                OnPropertyChanged();
            }
        }
        private double _value { get; set; }
        //public double MyValue {
        //    get {
        //        return _value;
        //    }
        //    set {
        //        if (_value != value) {
        //            _value = value;
        //            OnPropertyChanged();
        //            OnPropertyChanged("ViewValue");
        //        }
        //    }
        //}
        public string ViewValue { get {
                return EventName.ToString("N"+Dezimalstellen);
            }
        }
        public event System.EventHandler OnOkayClicked;
        public Numpad() {

            InitializeComponent();
            //var entry = new Numpad();
            //entry.SetBinding(Numpad.valueProperty, "Value");
            BindingContext = this;
            OnPropertyChanged("ViewValue");
        }

        private void AddOneButtonClicked(object sender, EventArgs e) {
            this.EventName++;
        }
        private void SubtractOneButtonClicked(object sender, EventArgs e) {
            this.EventName--;
        }
    }
}
