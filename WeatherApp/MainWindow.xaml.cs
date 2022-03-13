using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void OFF_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private string API = "2cd120ea9ce1313d5a698df0a0c34cba";

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            getWeather();
        }

        private void getWeather()
        {
            if (Country.Text.Length > 0)
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={Country.Text}&appid={API}&units=metric");
                    string json = web.DownloadString(url);

                    Data.root info = JsonConvert.DeserializeObject<Data.root>(json);

                    temp.Text = info.main.temp.ToString();
                }
            }
        }
    }
}
