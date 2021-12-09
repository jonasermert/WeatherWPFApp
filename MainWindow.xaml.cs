using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WeatherAPIWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string apiKey = "fc4b31df85c195390df341a0ece04304";

        private string requestURL = "https://api.openweathermap.org/data/2.5/weather";
        
        public MainWindow()
        {
            InitializeComponent();

            HttpClient httpClient = new HttpClient();
            var city = "Erfurt";
            var finalUri = requestURL + "?q=" + city + "&appid" + apiKey + "&units=metric";
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(finalUri).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Console.WriteLine(response);
            






        }
    }
}