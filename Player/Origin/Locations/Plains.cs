using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    [Serializable]
    class Plains : Location {
        // Plains biome, provides food bonus

        public Plains() : base() {
            this.gatherDesc = "Go Hunting";
            this.localeId = 2;
            this.localeName = "Plains";
            this.bonus = new Bonus { bonusType = 2 };
            this.desc = "The plains are a comfortable, bountiful biome. Food can be gathered here. It is also a suitable place for building.";
            this.img = "imgs/plains.jpg";
        }

        public override void gather(PlayerInfo player) {
            if (player.origin.foodBonus > 0) {
                player.stats.food = (int)(player.stats.food + (5 * player.origin.foodBonus));
            } else {
                player.stats.food += 5;
            }
        }
    }
}
