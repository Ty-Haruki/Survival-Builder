using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page {
        public MainMenu() {
            InitializeComponent();
        }

        private void startGame_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new Uri("CharacterCreation.xaml", UriKind.Relative));
        }

        private void loadGame_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new Uri("LoadGame.xaml", UriKind.Relative));
        }

        private void credits_Click(object sender, RoutedEventArgs e) {
            string messageBoxText = "Programmed and Developed by Ethan McCrary";
            string caption = "Credits";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
