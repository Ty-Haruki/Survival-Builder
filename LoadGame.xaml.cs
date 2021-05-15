using SurvivalBuilder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Interaction logic for LoadGame.xaml
    /// </summary>
    public partial class LoadGame : Page {
        SavedGames savedFiles = new SavedGames();
        BinaryFormatter binFormat = new BinaryFormatter();
        List<RadioButton> radioButtons = new List<RadioButton>();

        public LoadGame() {
            InitializeComponent();

            // check saved files and add to listview
            foreach (string file in savedFiles.savedFiles) {
                try {
                    try {
                        // Load saved files
                        Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
                        PlayerInfo player = (PlayerInfo)binFormat.Deserialize(stream);
                        stream.Close();

                        // Create radio button for each file
                        RadioButton savedGame = new RadioButton();
                        RegisterName("user" + player.id.ToString(), savedGame);
                        savedGame.Name = "user" + player.id.ToString();
                        savedGame.Content = ($"{player.name} - {player.currentLocation.localeName} - {player.worldClock.clock}");

                        savedGameList.Items.Add(savedGame);
                        radioButtons.Add(savedGame);
                    } catch (SerializationException e) {
                        string messageBoxText = "No saved game available.";
                        string caption = "No Save Found";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText, caption, button, icon);
                    }
                } catch (IOException e) {
                    string messageBoxText = "No saved game available.";
                    string caption = "No Save Found";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
        }

        private void loadGame_Click(object sender, RoutedEventArgs e) {
            foreach (RadioButton radioButton in radioButtons.ToList()) {
                if ((bool)radioButton.IsChecked) {
                    if (File.Exists(radioButton.Name + ".dat")) {
                        string messageBoxText = "Load Save file. Are you sure?";
                        string caption = "Loading save";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

                        if (messageBoxResult == MessageBoxResult.Yes) {
                            Stream stream = new FileStream(radioButton.Name + ".dat", FileMode.Open, FileAccess.Read, FileShare.None);
                            PlayerInfo player = (PlayerInfo)binFormat.Deserialize(stream);
                            stream.Close();

                            Page page = new Adventure(player);
                            this.NavigationService.Navigate(page);
                            break;
                        }
                    }
                }
            }
        }

        private void deleteGame_Click(object sender, RoutedEventArgs e) {
            foreach(RadioButton radioButton in radioButtons.ToList()) {
                if ((bool)radioButton.IsChecked) {
                    if (File.Exists(radioButton.Name + ".dat")) {
                        string messageBoxText = "Delete Save file. Are you sure?";
                        string caption = "Deleting save";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
                        
                        if (messageBoxResult == MessageBoxResult.Yes) {
                            File.Delete(radioButton.Name + ".dat");
                            savedGameList.Items.Remove(FindName(radioButton.Name));
                            radioButtons.Remove(radioButton);
                        }
                    }
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }

    }
}
