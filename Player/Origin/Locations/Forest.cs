using SurvivalBuilder.Player.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    [Serializable]
    class Forest : Location {
        // Forest biome, provides wood bonus

        public Forest() : base() {
            this.gatherDesc = "Gather Wood";
            this.localeId = 4;
            this.localeName = "Forest";
            this.bonus = new Bonus { bonusType = 4 };
            this.desc = "The forest is abundant in wood. Gathering here will provide the player with wood used to craft.";
            this.img = "imgs/forest.jpg";
        }

        public override void gather(PlayerInfo player) {
            if (player.origin.woodBonus > 0) {
                player.stats.wood = (int)(player.stats.wood + (5 * player.origin.woodBonus));
            } else {
                player.stats.wood += 5;
            }
        }
    }
}
