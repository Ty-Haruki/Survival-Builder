using SurvivalBuilder.Player.Origin.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalBuilder.Player.Origin {
    // Origin of Player (provides bonuses and sets home point)
    [Serializable]
    public class Origin {
        // Location that player decides -- affects bonuses below
        public Location home { get; private set; }
        // Mountains
        public double stoneBonus { get; private set; }
        // City
        public double goldBonusBuy { get; private set; }
        public double goldBonusSell { get; private set; }
        // Forest
        public double woodBonus { get; private set; }
        // Plains
        public double foodBonus { get; private set; }
        // Bonus
        public string bonus { get; set; }

        public Origin(Location home) {

            // Desert = 0, Mountains = 1, Plains = 2, City = 3, Forest = 4
            this.home = home;

            if (home.bonus.bonusType == 0) {
                // Temperature rises .25x as much
                goldBonusBuy = goldBonusSell = woodBonus = stoneBonus = foodBonus = 0;
                bonus = "None.";
            } else if (home.bonus.bonusType == 1) {
                // Temperature lowers .25x as much
                stoneBonus = 1.25;
                goldBonusBuy = goldBonusSell = woodBonus = foodBonus = 0;
                bonus = "Gain 25% more stone from mining.";
            } else if (home.bonus.bonusType == 2) {
                // Gain 1.25x as much food from hunting
                foodBonus = 1.25;
                goldBonusBuy = goldBonusSell = woodBonus = stoneBonus = 0;
                bonus = "Gain 25% more food from hunting.";
            } else if (home.bonus.bonusType == 3) {
                // Purchase items for 25% less
                goldBonusBuy = .75;
                woodBonus = stoneBonus = foodBonus = 0;
                bonus = "Purchase resources for 25% less.";
            } else if (home.bonus.bonusType == 4) {
                // Gain 1.25x as much wood
                woodBonus = 1.25;
                goldBonusBuy = goldBonusSell = stoneBonus = foodBonus = 0;
                bonus = "Gain 25% more wood from gathering.";
            }
        }

    }
}
