using SurvivalBuilder;
using SurvivalBuilder.Clock;
using SurvivalBuilder.Player.Origin;
using SurvivalBuilder.Player.Origin.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page {
        Origin origin;
        static List<RadioButton> radioButtons;

        public CharacterCreation() {
            InitializeComponent();
            radioButtons = new List<RadioButton>() {
                desertRb,
                mountainsRb,
                plainsRb,
                cityRb,
                forestRb
            };
        }

        // Handle Changing Username
        private void playerNameTextbox_TextChanged(object sender, TextChangedEventArgs e) {
            playerName.Content = playerNameTextbox.Text;
        }

        // Handle Changing Origin Location
        private void desertRb_Checked(object sender, RoutedEventArgs e) {
            if ((bool)desertRb.IsChecked) {
                origin = new Origin(new Desert());
                originLocaleName.Content = origin.home.localeName;
                bonusDesc.Content = origin.bonus;
                statsDesc.Content = determineStats(false);

                // image
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("imgs/desert.jpg", UriKind.Relative);
                bi3.EndInit();
                originLandscape.Stretch = Stretch.Fill;
                originLandscape.Source = bi3;
            }
        }

        private void mountainsRb_Checked(object sender, RoutedEventArgs e) {
            if ((bool)mountainsRb.IsChecked) {
                origin = new Origin(new Mountains());
                originLocaleName.Content = origin.home.localeName;
                bonusDesc.Content = origin.bonus;
                statsDesc.Content = determineStats(false);

                // image
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("imgs/mountains.jpg", UriKind.Relative);
                bi3.EndInit();
                originLandscape.Stretch = Stretch.Fill;
                originLandscape.Source = bi3;
            }
        }

        private void plainsRb_Checked(object sender, RoutedEventArgs e) {
            if ((bool)plainsRb.IsChecked) {
                origin = new Origin(new Plains());
                originLocaleName.Content = origin.home.localeName;
                bonusDesc.Content = origin.bonus;
                statsDesc.Content = determineStats(false);

                // image
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("imgs/plains.jpg", UriKind.Relative);
                bi3.EndInit();
                originLandscape.Stretch = Stretch.Fill;
                originLandscape.Source = bi3;
            }
        }

        private void cityRb_Checked(object sender, RoutedEventArgs e) {
            if ((bool)cityRb.IsChecked) {
                origin = new Origin(new City());
                originLocaleName.Content = origin.home.localeName;
                bonusDesc.Content = origin.bonus;
                statsDesc.Content = determineStats(true);

                // image
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("imgs/city.jpg", UriKind.Relative);
                bi3.EndInit();
                originLandscape.Stretch = Stretch.Fill;
                originLandscape.Source = bi3;
            }
        }

        private void forestRb_Checked(object sender, RoutedEventArgs e) {
            if ((bool)forestRb.IsChecked) {
                origin = new Origin(new Forest());
                originLocaleName.Content = origin.home.localeName;
                bonusDesc.Content = origin.bonus;
                statsDesc.Content = determineStats(false);

                // image
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("imgs/forest.jpg", UriKind.Relative);
                bi3.EndInit();
                originLandscape.Stretch = Stretch.Fill;
                originLandscape.Source = bi3;
            }
        }

        public string determineStats(bool hasGoldBonus) {
            StringBuilder stats = new StringBuilder();
            stats.Append("Health: 100\n");
            stats.Append("Temperature: 98.5F\n");
            stats.Append("Wood: 10\n");
            stats.Append("Food: 10\n");
            if (hasGoldBonus) {
                stats.Append("Gold: 200\n");
            } else {
                stats.Append("Gold: 100\n");
            }

            return stats.ToString();
        }

        // Handle Create Character Clicking
        private void createCharacter_Click(object sender, RoutedEventArgs e) {
            if (!playerNameTextbox.Text.Equals("")) {
                bool chkd = false;
                foreach (RadioButton btn in radioButtons) {
                    if ((bool)btn.IsChecked) {
                        // Setup character
                        SavedGames savedGames = new SavedGames();
                        int id = savedGames.savedFiles.Count + 1;
                        PlayerInfo player = new PlayerInfo(id, playerNameTextbox.Text, origin, $"user{id}.dat", new WorldClock());

                        // Serialize Object
                        BinaryFormatter binFormat = new BinaryFormatter();
                        SavedGames savedFiles = new SavedGames();
                        string file = $"user{(savedFiles.savedFiles.Count + 1)}.dat";

                        // Increment saved files based on total amount of saved files
                        // Will overrite latest if earlier files are deleted.
                        // Should check if file exists before saving.
                        Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
                        binFormat.Serialize(stream, player);
                        stream.Close();
                        chkd = true;
                        Page page = new Adventure(player);
                        this.NavigationService.Navigate(page);            
                        break;
                    }
                }
                if (!chkd) {
                    string messageBoxText = "Please select an origin.";
                    string caption = "Origin Missing";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            } else {
                string messageBoxText = "Please enter your character's name.";
                string caption = "Name Missing";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }
    }
}
