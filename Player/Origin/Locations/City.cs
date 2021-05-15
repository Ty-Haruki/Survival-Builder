using SurvivalBuilderApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    [Serializable]
    class City : Location {
        // City biome, provides gold bonus

        public City() : base() {
            this.gatherDesc = "Buy / Sell";
            this.localeId = 3;
            this.localeName = "City";
            this.bonus = new Bonus { bonusType = 3 };
            this.desc = "The city is a trading hub. The player can sell and purchase resources here.";
            this.img = "imgs/city.jpg";
        }

        public void purchase(PlayerInfo player, List<int> resources, int total) {
            player.stats.stone += resources[0];
            player.stats.food += resources[1];
            player.stats.wood += resources[2];
            player.stats.gold -= total;
        }

        public void sell(PlayerInfo player, List<int> resources, int total) {
            player.stats.stone -= resources[0];
            player.stats.food -= resources[1];
            player.stats.wood -= resources[2];
            player.stats.gold += total;
        }
    }
}
