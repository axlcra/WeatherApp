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

namespace WeatherApp;

/// <summary>
/// Logika interakcji dla klasy MainWindow.xaml
/// </summary>

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Main.Content = WeatherInfo;
    }

    private Page _settings = new Settings();
    private Page Settings { get { return _settings; } }

    private Page _weatherInfo = new WeatherInfo();
    private Page WeatherInfo { get { return _weatherInfo; } }

    private Page _cityList = new CityList();
    private Page CityList { get { return _cityList; } }

    private void close_btn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void minim_btn_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void max_btn_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void mainPage_btn_Click(object sender, RoutedEventArgs e)
    {
        Main.Content = WeatherInfo;
    }

    private void cityList_btn_Click(object sender, RoutedEventArgs e)
    {
        Main.Content = CityList;
    }

    private void settingsPage_btn_Click(object sender, RoutedEventArgs e)
    {
        Main.Content = Settings;
    }
}

