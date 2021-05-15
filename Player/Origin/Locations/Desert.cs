using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    // Desert biome, provides no bonus
    [Serializable]
    class Desert : Location {

        public Desert() : base() {
            this.gatherDesc = "";
            this.localeId = 0;
            this.localeName = "Desert";
            this.bonus = new Bonus { bonusType = 0 };
            this.desc = "The desert is a hot, dry place. It is a suitable place to build.";
            this.img = "imgs/desert.jpg";
        }
    }
}
