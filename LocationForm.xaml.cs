using SurvivalBuilder;
using SurvivalBuilder.Player.Origin.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SurvivalBuilderApp {
    /// <summary>
    /// Interaction logic for locationForm.xaml
    /// </summary>
    public partial class locationForm : Window {
        PlayerInfo player { get; set; }
        List<Location> locations;

        public locationForm() {
            InitializeComponent();
            locations = new List<Location> { new Desert(), new Mountains(), new Plains(), new City(), new Forest() };
        }

        public void setupRadioButtons(Location location) {
            foreach(Location locale in locations.ToList()) {
                if (locale.localeId == location.localeId) {
                    locations.Remove(locale);
                }
            }

            foreach(Location locale in locations) {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = locale.localeName;
                radioButton.Name = "locale" + locale.localeId;
                radioButtonListView.Items.Add(radioButton);
            }
        }

        public locationForm(PlayerInfo player) : this() {
            this.player = player;
            setupRadioButtons(player.currentLocation);
        }

        private void cancel_click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void travel_click(object sender, RoutedEventArgs e) {

            foreach (RadioButton radioButton in radioButtonListView.Items) {
                if ((bool)radioButton.IsChecked) {
                    foreach (Location location in locations) {
                        if (radioButton.Name.Contains(location.localeId.ToString())) {
                            player.travel(location);
                            //this.NavigationService.Navigate(new Uri("Adventure.xaml", UriKind.RelativeOrAbsolute));
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
