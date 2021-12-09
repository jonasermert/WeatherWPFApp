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
using Newtonsoft.Json;

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

            WeatherMapResponse result = GetWeatherData("Erfurt");

            string finalImage = "sun.png";
            string currentWeather = result.weather[0].main.ToLower();
            
            if (currentWeather.Contains("cloud"))
            {
                finalImage = "cloud.png";
            } else if (currentWeather.Contains("rain"))
            {
                finalImage = "rain.png";
            } 
            else if (currentWeather.Contains("snow"))
            {
                finalImage = "snow.png";
            }
            
            backgroundImage.ImageSource = new BitmapImage(new Uri("Images/" + finalImage, UriKind.Relative));

            labelTemperature.Content = result.main.temp.ToString("F1") + "°C";

            labelInfo.Content = result.weather[0].main;

        }

        public WeatherMapResponse GetWeatherData(string city)
        {
            HttpClient httpClient = new HttpClient();
            var finalUri = requestURL + "?q=" + city + "&appid" + apiKey + "&units=metric";
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(finalUri).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            // Console.WriteLine(response);

            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);
            // Console.WriteLine(weatherMapResponse);

            return weatherMapResponse;
        }
    }
}