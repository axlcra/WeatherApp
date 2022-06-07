using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy CityList.xaml
    /// </summary>
    public partial class CityList : Page
    {

        public CityList()
        {
            InitializeComponent();
            List<string> citis = new List<string>()
            {
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań",
                "Kraków",
                "Warszawa",
                "Poznań"
            };
            cityList.ItemsSource = citis;
        }
    }
}
