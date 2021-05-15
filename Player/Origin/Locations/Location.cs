using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SurvivalBuilder.Player.Origin.Locations {
    // Locations for Origins and Travel
    [Serializable]
    public class Location {
        // Desert, Mountains, Plains, City, Forest
        public int localeId { get; set; }
        public string localeName { get; set; }
        public Bonus bonus { get; set; }
        public string desc { get; set; }
        public string img { get; set; }
        public string gatherDesc { get; set; }

        public virtual void gather(PlayerInfo player) {
        }
    }
}
