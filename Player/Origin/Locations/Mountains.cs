using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    [Serializable]
    class Mountains : Location {
        // Moutain biome, provides temp bonus

        public Mountains() : base() {
            this.gatherDesc = "Gather Stone";
            this.localeId = 1;
            this.localeName = "Mountains";
            this.bonus = new Bonus { bonusType = 1 };
            this.desc = "The mountains are a cold biome. Gathering here will provide the player with stone.";
            this.img = "imgs/mountains.jpg";
        }

        public override void gather(PlayerInfo player) {
            if (player.origin.stoneBonus > 0) {
                player.stats.stone = (int)(player.stats.stone + (5 * player.origin.stoneBonus));
            } else {
                player.stats.stone += 5;
            }
        }
    }
}
