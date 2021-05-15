using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalBuilder {
    // Defines the bonus gained from locale
    [Serializable]
    public class Bonus {
        public double modifier { get; private set; }
        public int bonusType { get; set; }
    }
}
