using SurvivalBuilder.Clock;
using SurvivalBuilder.Player.Origin;
using SurvivalBuilder.Player.Origin.Locations;
using SurvivalBuilder.Player.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SurvivalBuilder {
    [Serializable]
    public class PlayerInfo {
        public int id { get; set; }
        public string name { get; set; }
        public Origin origin { get; set; }
        public Stats stats { get; set; }
        public Location currentLocation { get; set; }
        public int population { get; set; }
        public string file { get; set; }
        public WorldClock worldClock { get; set; }

        public PlayerInfo(int id, string name, Origin location, string file, WorldClock worldClock) {
            this.id = id;
            this.name = name;
            this.origin = location;
            this.stats = new Stats();
            this.currentLocation = origin.home;
            this.file = file;
            this.worldClock = worldClock;
        }

        public void travel(Location location) {
            currentLocation = location;
        }
    }
}
