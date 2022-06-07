using Newtonsoft.Json;
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

namespace WeatherApp;

/// <summary>
/// Logika interakcji dla klasy Settings.xaml
/// </summary>

public partial class Settings : Page
{
    public Settings()
    {
        InitializeComponent();
    }

    private void colorMode_btn_Click(object sender, RoutedEventArgs e)
    {
        Properties.Settings.Default.ColorMode = Properties.Settings.Default.ColorMode == "Dark" ? "Light" : "Dark";
        Properties.Settings.Default.Save();
    }
}

