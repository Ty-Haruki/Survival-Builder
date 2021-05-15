using SurvivalBuilder;
using SurvivalBuilder.Player.Origin.Locations;
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
using System.Windows.Shapes;

namespace SurvivalBuilderApp {
    /// <summary>
    /// Interaction logic for StoreForm.xaml
    /// </summary>
    public partial class StoreForm : Window {
        public PlayerInfo player;
        public List<int> resources;
        public int total;
        public int prevAmount;

        public StoreForm() {
            InitializeComponent();
            resources = new List<int>();
        }

        public StoreForm(PlayerInfo player) : this() {
            this.player = player;
            playerGold.Content = player.stats.gold;
        }

        private void buy_click(object sender, RoutedEventArgs e) {
            checkResources();
            if (purchaseFood.Text.Equals("") && purchaseStone.Text.Equals("") && purchaseWood.Text.Equals("")) {
                string messageBoxText = "Please enter an amount to purchase.";
                string caption = "Purchase";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);
            } else {

                string messageBoxText = "Are you sure you want to purchase:\n";
                messageBoxText += $"{purchaseFood.Text} food, {purchaseStone.Text} stone, and {purchaseWood.Text} wood.";
                string caption = "Confirm Purchase";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
                if (messageBoxResult.Equals(MessageBoxResult.Yes)) {
                    resources.Add(Convert.ToInt32(purchaseStone.Text));
                    resources.Add(Convert.ToInt32(purchaseFood.Text));
                    resources.Add(Convert.ToInt32(purchaseWood.Text));

                    int total = 0;
                    foreach (int i in resources) {
                        total += i;
                    }

                    if (player.origin.goldBonusBuy != 0) {
                        total = (int)(total * player.origin.goldBonusBuy);
                    }

                    if (total <= player.stats.gold) {
                        City city = new City();
                        city.purchase(player, resources, total);
                        this.Close();
                    } else {
                        string messageBoxText1 = "You do not have the gold necessary to make the purchase.\n";
                        messageBoxText1 += $"{player.stats.gold} / {total}.";
                        string caption1 = "Not Enough Gold";
                        MessageBoxButton button1 = MessageBoxButton.OK;
                        MessageBoxImage icon1 = MessageBoxImage.Error;
                        MessageBoxResult messageBoxResult1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                        this.Close();
                    }
                }
            }
        }

        public void checkResources() {
            if (purchaseFood.Text.Equals("")) {
                purchaseFood.Text = "0";
            }
            if (purchaseStone.Text.Equals("")) {
                purchaseStone.Text = "0";
            }
            if (purchaseWood.Text.Equals("")) {
                purchaseWood.Text = "0";
            }
        }

        private void sell_click(object sender, RoutedEventArgs e) {
            checkResources();
             {
                string messageBoxText = "Are you sure you want to sell:\n";
                messageBoxText += $"{purchaseFood.Text} food, {purchaseStone.Text} stone, and {purchaseWood.Text} wood.";
                string caption = "Confirm Sale";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
                if (messageBoxResult.Equals(MessageBoxResult.Yes)) {
                    resources.Add(Convert.ToInt32(purchaseStone.Text));
                    resources.Add(Convert.ToInt32(purchaseFood.Text));
                    resources.Add(Convert.ToInt32(purchaseWood.Text));

                    int total = 0;
                    foreach (int i in resources) {
                        total += i;
                    }

                    if ((Convert.ToInt32(purchaseFood.Text) > player.stats.food) || (Convert.ToInt32(purchaseStone.Text) > player.stats.stone) || (Convert.ToInt32(purchaseWood.Text) > player.stats.wood)) {
                        string messageBoxText1 = "You do not have the amount of resources you want to sell.";
                        string caption1 = "Sell";
                        MessageBoxButton button1 = MessageBoxButton.OK;
                        MessageBoxImage icon1 = MessageBoxImage.Error;
                        MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                    } else {
                        City city = new City();
                        city.sell(player, resources, total);
                        this.Close();
                    }
                }
            }
        }

        private void cancel_click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
