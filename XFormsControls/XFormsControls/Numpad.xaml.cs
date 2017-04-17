using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFormsControls {
    public partial class Numpad : ContentView {
        private static double defaultVal = 0;
        public static readonly BindableProperty valueProperty = BindableProperty.Create(
                                                            propertyName: "Value",
                                                            returnType: typeof(double),
                                                            declaringType: typeof(Numpad),
                                                            defaultValue: defaultVal,
                                                            defaultBindingMode: BindingMode.TwoWay);

        public double Value {
            get { return (double)GetValue(valueProperty); }
            set {
                SetValue(valueProperty, value);
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
            var neuerString = (Value.ToString("N" + Dezimalstellen) + button.Text);
            neuerString = MoveDelimitter(neuerString);
            Value = Double.Parse(neuerString);
        }

        private string MoveDelimitter(string neuerString) {
            neuerString = neuerString.Replace(".", "");
            neuerString = neuerString.Insert(neuerString.Length - Dezimalstellen, ".");
            return neuerString;
        }

        public void DelButtonClicked(object sender, EventArgs e) {
            var button = (Button)sender;
            var stringval = Value.ToString("N"+Dezimalstellen);
            if (Value < 0.0) {
                Value = 0.00;
            } else {
                var neuerString = stringval.Substring(0, stringval.Length - 1);
                neuerString = MoveDelimitter(neuerString);
                Value = Double.Parse(neuerString);
            }
        }
        public void OkButtonClicked(object sender, EventArgs e) {
            this.Dezimalstellen = 0;
            Value = Math.Round(Value, Dezimalstellen);
            //lblValue.SetBinding(targetProperty: this.Value,"", stringFormat: "{0:0.00}");
        }
        public int Dezimalstellen = 2;
        private double _value { get; set; }
        //public double Value {
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
                return _value.ToString("N"+Dezimalstellen);
            }
        }
        public Numpad() {

            InitializeComponent();
            //var entry = new Numpad();
            //entry.SetBinding(Numpad.valueProperty, "Value");
            BindingContext = this;
        }
    }
}
