using Newtonsoft.Json;
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

namespace Fortnite {
    public partial class MainWindow : Window {
        private JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        List<Shop> items = new List<Shop>();
        public MainWindow() {
            InitializeComponent();
            loadall();
        }

        async void loadall() {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/store/get");
            string jsonContent = await response.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<List<Shop>>(jsonContent, settings);
            MessageBox.Show(items.ToString());
        }
    }
}
