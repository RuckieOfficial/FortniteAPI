using Fortnite.AllitemsFolder;
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
using Tulpep.NotificationWindow;

namespace Fortnite {
    public partial class MainWindow : Window {
        private JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, NullValueHandling = NullValueHandling.Ignore };
        Shop items = new Shop();
        List<Allitems> allitems = new List<Allitems>();
        public MainWindow() {
            InitializeComponent();
            loadall();
            doPopup();
        }

        void doPopup() {
            var popupNotifier = new PopupNotifier();
            popupNotifier.TitleText = "FortniteAPI";
            popupNotifier.ContentText = "Your skin is in the shop!";
            popupNotifier.IsRightToLeft = false;
            popupNotifier.Popup();
        }

        async void loadall() {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/store/get");
            string jsonContent = await response.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<Shop>(jsonContent, settings);

            HttpClient httpClientAll = new HttpClient();
            var responseAll = await httpClientAll.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/items/list");
            string jsonContentAll = await responseAll.Content.ReadAsStringAsync();
            allitems = JsonConvert.DeserializeObject<List<Allitems>>(jsonContentAll, settings);

            addtocombo();
            addall();
            //MessageBox.Show(items.vbucks.ToString());
        }

        void addtocombo() {
            foreach (Allitems item in allitems) {
                AllItemsBox.Items.Add(item.name);
            }
        }

        void addall() {
            Label shopdate = new Label();
            shopdate.Content = items.date;
            shopdate.Foreground = Brushes.White;
            HeaderContent.Children.Add(shopdate);

            foreach(Item item in items.items) {
                BitmapImage bmpitemimage = new BitmapImage();
                bmpitemimage.BeginInit();
                bmpitemimage.UriSource = new Uri(item.item.image);
                bmpitemimage.EndInit();

                Image itemimage = new Image();
                itemimage.Source = bmpitemimage;
                itemimage.Width = 160;
                itemimage.Height = 160;

                Label itemname = new Label();
                itemname.Content = item.item.name;
                itemname.Foreground = Brushes.White;
                itemname.FontSize = 15;

                Border itemframe = new Border();
                itemframe.BorderThickness = new Thickness(5, 5, 5, 5);
                var converter = new System.Windows.Media.BrushConverter();
                if (item.item.rarity == "common") {
                    itemframe.BorderBrush = (Brush)converter.ConvertFromString("#bebebe");
                } else if (item.item.rarity == "uncommon") {
                itemframe.BorderBrush = (Brush)converter.ConvertFromString("#8fee3b");
                } else if (item.item.rarity == "epic") {
                    itemframe.BorderBrush = (Brush)converter.ConvertFromString("#b04eec");
                } else if (item.item.rarity == "rare") {
                    itemframe.BorderBrush = (Brush)converter.ConvertFromString("#3ad6ff");
                } else if (item.item.rarity == "legendary") {
                itemframe.BorderBrush = (Brush)converter.ConvertFromString("#e38748");
            }
            itemframe.Margin = new Thickness(5, 5, 0, 0);

                RadialGradientBrush itemtransition = new RadialGradientBrush();
                if (item.item.rarity == "common") {
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#bebebe"), 0));
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#848282"), 1));
                } else if (item.item.rarity == "uncommon") {
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#69bb1e"), 0));
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#227622"), 1));
                } else if (item.item.rarity == "epic") {
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#c359ff"), 0));
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#701fe5"), 1));
                } else if (item.item.rarity == "rare") {
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#2cc1ff"), 0));
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#215dc2"), 1));
                } else if (item.item.rarity == "legendary") {
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#ea8d23"), 0));
                    itemtransition.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#c04d1f"), 1));
                }
                itemtransition.Freeze();

                StackPanel itemgroup = new StackPanel();
                itemgroup.Orientation = Orientation.Vertical;
                itemgroup.Width = 160;
                itemgroup.Height = 160;
                itemgroup.Background = itemtransition;
                itemgroup.Children.Add(itemname);
                itemgroup.Children.Add(itemimage);

                itemframe.Child = itemgroup;

                ShopContent.Children.Add(itemframe);
            }
            //MessageBox.Show(items.vbucks.ToString());
            //MessageBox.Show(items.items[0].item.image.ToString());
        }
    }
}
