using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalBuilder.Player.Statistics {
    class PlayerHealth : Stats {
        // 1 attack, 2 hunger, 3 temperature
        public void takeDamage(int damageType) {
            if (damageType == 1) {
                // deal damage
            } else if (damageType == 2) {
                // deal hunger damage
            } else if (damageType == 3) {
                // deal temperature damage
            }
        }
    }
}
