﻿using System;
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
            getWeather();
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }

        private void minim_btn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private string API = "2cd120ea9ce1313d5a698df0a0c34cba";

        //private void search_Click(object sender, RoutedEventArgs e)`    !!
        //{
        //    getWeather();
        //}



        private void getWeather()
        {
            if (Country.Text.Length > 0)
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={Country.Text}&appid={API}&units=metric");
                    string json = web.DownloadString(url);

                    Data.root info = JsonConvert.DeserializeObject<Data.root>(json);

                    var image = new Image();
                    var fullFilePath = @"http://openweathermap.org/img/wn/" + info.weather[0].icon + "@2x.png";

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();

                    WeatherImage.Source = bitmap;
                    Temp.Text = info.main.temp.ToString() + "°";
                }
            }
        }
    }
}
