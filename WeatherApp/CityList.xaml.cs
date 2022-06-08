using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<string> city = new List<string>();
        private string _path = "./Data/cityList.json";

        public CityList()
        {
            InitializeComponent();
            ReadFile();
        }

        public void ReadFile()
        {
            if (File.Exists(_path))
            {
                string file = File.ReadAllText(_path);
                city = JsonConvert.DeserializeObject<List<string>>(file);
                cityList.ItemsSource = city;
            }
            else
            {
                city.Clear();
                cityList.ItemsSource = city;
            }
        }

        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
        }
    }
}
