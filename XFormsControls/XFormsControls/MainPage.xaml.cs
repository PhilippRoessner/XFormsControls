using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsControls
{
    public partial class MainPage : ContentPage
    {
        private MyGloriousItem _selectedListItem;
        public MyGloriousItem selectedListItem {
            get
            {
                return _selectedListItem;
            }
            set
            {
                _selectedListItem = value;
                OnPropertyChanged();
            }
        }
        private List<MyGloriousItem> _liste;
        public List<MyGloriousItem> liste { get
            {
                return _liste ?? (_liste = neueListeBauen());
            }
        }
    private double _selectedValue = 25;
    public double selectedValue
    {
        get
        {
            return _selectedValue;
        }
        set
        {
            _selectedValue = value;
            OnPropertyChanged();
        }
    }
        private List<MyGloriousItem> neueListeBauen()
        {
            var neueliste = new List<MyGloriousItem>();
            neueliste.Add(new MyGloriousItem() { id = "Erster", val = 2.01 });
            neueliste.Add(new MyGloriousItem() { id = "Zweiter", val = 7.21 });
            neueliste.Add(new MyGloriousItem() { id = "Dritter",val = 1.00});
            return neueliste;
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
    public class MyGloriousItem
    {
        public string id { get; set; }
        public double val { get; set; }
    }
}
