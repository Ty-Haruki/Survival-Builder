using SurvivalBuilder;
using SurvivalBuilder.Clock;
using SurvivalBuilder.Player.Origin.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for Adventure.xaml
    /// </summary>
    public partial class Adventure : Page {
        public static PlayerInfo player;
        public WorldClock worldClock;
        public Timer aTimer;

        SavedGames savedGames = new SavedGames();
        public Adventure() {
            InitializeComponent();
        }


        public Adventure(PlayerInfo player1) : this() {
            player = player1;
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            worldClock = new WorldClock(player.worldClock);
            worldClockLabel.Content = worldClock.clock;
            playerName.Content = player.name;
            playerHealth.Content = player.stats.health;
            playerHunger.Content = player.stats.hunger;

            goldCount.Content = player.stats.gold;
            foodCount.Content = player.stats.food;
            woodCount.Content = player.stats.wood;
            stoneCount.Content = player.stats.stone;

            currentLocationText.Content = player.currentLocation.localeName;
            gatherButton.Content = player.currentLocation.gatherDesc;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(player.currentLocation.img, UriKind.Relative);
            bi3.EndInit();
            currentLocation.Stretch = Stretch.Fill;
            currentLocation.Source = bi3;

            currentLocationDesc.Text = player.currentLocation.desc;
            SetTimer();
        }

        public void Refresh() {
            gatherButton.Content = player.currentLocation.gatherDesc;
            currentLocationText.Content = player.currentLocation.localeName;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(player.currentLocation.img, UriKind.Relative);
            bi3.EndInit();
            currentLocation.Stretch = Stretch.Fill;
            currentLocation.Source = bi3;

            currentLocationDesc.Text = player.currentLocation.desc;

            goldCount.Content = player.stats.gold;
            foodCount.Content = player.stats.food;
            stoneCount.Content = player.stats.stone;
            woodCount.Content = player.stats.wood;
        }

        private void SetTimer(/*speed setting?*/) {
            // Create a timer with a two second interval.
            // /*speed setting?*/
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e) {
            App.Current.Dispatcher.Invoke((Action)delegate {
                // Update Timed Events
                if (player.stats.health > 0) {
                    worldClock.updateClock(player);
                    player.stats.manageHunger();

                    // Update labels
                    worldClockLabel.Content = worldClock.clock;
                    playerHealth.Content = player.stats.health;
                    playerHunger.Content = player.stats.hunger;
                    foodCount.Content = player.stats.food;
                } else {
                    aTimer.Stop();
                }
            });
        }

        private void save_click(object sender, RoutedEventArgs e) {
            aTimer.Stop();
            string messageBoxText = "Saving will overwrite existing file. Are you sure?";
            string caption = "Saving Game";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
            if (messageBoxResult == MessageBoxResult.Yes) {
                // Serialize Object
                player.worldClock = worldClock;
                savedGames.saveGame(player);
            }

            aTimer.Start();
        }

        private void quit_click(object sender, RoutedEventArgs e) {
            aTimer.Stop();
            string messageBoxText = "All unsaved progress will be lost. Are you sure you want to quit?";
            string caption = "Quit Game";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

            if (messageBoxResult == MessageBoxResult.Yes) {
                Application.Current.Shutdown();
            } else {
                aTimer.Start();
            }
        }

        private void menu_click(object sender, RoutedEventArgs e) {
            aTimer.Stop();
            string messageBoxText = "All unsaved progress will be lost. Are you sure you want to return to Main Menu?";
            string caption = "Quit Game";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

            if (messageBoxResult == MessageBoxResult.Yes) {
                NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.RelativeOrAbsolute));
            } else {
                aTimer.Start();
            }
        }

        private void travel_click(object sender, RoutedEventArgs e) {
            var newForm = new locationForm(player);
            newForm.Width = 320;
            newForm.Height = 400;
            newForm.ShowDialog();
            if (newForm.IsLoaded) {
                Refresh();
            }
        }

        private void gather_click(object sender, RoutedEventArgs e) {
            if (player.currentLocation.localeId != 3) {
                player.currentLocation.gather(player);
                stoneCount.Content = player.stats.stone.ToString();
                goldCount.Content = player.stats.gold.ToString();
                woodCount.Content = player.stats.wood.ToString();
            } else {
                var newForm = new StoreForm(player);
                newForm.Width = 320;
                newForm.Height = 400;
                newForm.ShowDialog();

                if (newForm.IsLoaded) {
                    Refresh();
                }
            }
        }

        private void about_click(object sender, RoutedEventArgs e) {
            string messageBoxText = $"Name: {player.name}\n";
            messageBoxText += $"Origin: {player.origin.home.localeName}\n";
            messageBoxText += $"Origin Bonus: {player.origin.bonus}\n";
            messageBoxText += $"Current Location: {player.currentLocation.localeName}\n";

            string caption = "Player Info";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
