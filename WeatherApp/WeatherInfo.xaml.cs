using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WeatherApp;

/// <summary>
/// Logika interakcji dla klasy WeatherInfo.xaml
/// </summary>

public partial class WeatherInfo : Page
{
    List<string> cityList = new List<string>();

    public WeatherInfo()
    {
        InitializeComponent();
        getWeather();
    }

    private void refresh_btn_Click(object sender, RoutedEventArgs e)
    {
        getWeather();
    }

    private void search_btn_Click(object sender, RoutedEventArgs e)
    {
        SearchWindow search = new SearchWindow();
        search.Show();
    }

    private string API = "2cd120ea9ce1313d5a698df0a0c34cba";

    public void getWeather()
    {
        string city = Properties.Settings.Default.CityNameX.ToString();
        if (city.Length > 0)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric");
                string json = "null";

                try
                {
                    json = web.DownloadString(url);
                }
                catch
                {
                    url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={"Kraków"}&appid={API}&units=metric");
                    json = web.DownloadString(url);
                };

                Data.root info = JsonConvert.DeserializeObject<Data.root>(json);

                var image = new Image();
                var fullFilePath = @"http://openweathermap.org/img/wn/" + info.weather[0].icon + "@2x.png";

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();

                WeatherCity.Text = city;
                WeatherImage.Source = bitmap;
                Temp.Text = info.main.temp.ToString() + "°";
                WeatherDisc.Text = info.weather[0].description;
                WeatherMin.Text = "Min Temp : " + info.main.temp_min.ToString() + "°";
                WeatherMax.Text = "Max Temp : " + info.main.temp_max.ToString() + "°";
                WeatherWind.Text = "Wind : " + info.wind.speed.ToString() + " km/h";
                WeatherPre.Text = "Pressure : " + info.main.pressure.ToString() + " hPa";
            }
        }
    }

    private void add_btn_Click(object sender, RoutedEventArgs e)
    {
        cityList.Add(WeatherCity.Text);
        var json = JsonConvert.SerializeObject(cityList);

        string _path = "./Data/cityList.json";

        using (var writer = new StreamWriter(_path)){
            writer.Write(json);
        }
    }
}

