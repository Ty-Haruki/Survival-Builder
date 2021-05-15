using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SurvivalBuilder.Player.Statistics {
    // Class that manages a Player's stats and resources
    [Serializable]
    public class Stats {
        // stats
        public int health { get; set; }
        public int hunger { get; set; }

        // resources
        public int gold { get; set; }
        public int wood { get; set; }
        public int food { get; set; }
        public int stone { get; set; }

        public Stats() {
            // Standard health and Temp
            health = 100;
            hunger = 100;

            gold = 100;
            wood = 10;
            food = 10;
            stone = 10;
        }

        public void manageHunger() {
            // if you have no hunger left
            if (hunger <= 0) {
                // if you have food left
                if (food > 0) {
                    // subtract food and refresh hunger
                    food -= 5;
                    hunger = 100;
                } else {
                    // if you have no food left, subtract health
                    if (health > 0) {
                        health -= 5;
                    }
                }
                //if you have hunger left
            } else {
                hunger -= 10;
                if (health < 100) {
                    health++;
                }
            }

            // if you have no health left
            if (health <= 0) {
                starve();
            }
        }

        public void starve() {
            string messageBoxText = "You starved to death. Game Over.";
            string caption = "You Died";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);
            Application.Current.Shutdown();
        }
    }
}
