using SurvivalBuilderApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace SurvivalBuilder.Clock {
    // Clock - 1 day per 2 seconds
    [Serializable]
    public class WorldClock {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string clock { get; set; }

        public WorldClock(/*speed setting?*/) {
            // Start Player on 01/01/01
            this.day = 1;
            this.month = 1;
            this.year = 1;
            clock = "\rClock: " + day + "/" + month + "/" + year;
        }

        public WorldClock(WorldClock worldClock) {
            this.day = worldClock.day;
            this.month = worldClock.month;
            this.year = worldClock.year;
            clock = worldClock.clock;
        }

        public void updateClock(PlayerInfo player) {
            // Update day, month, year, every two seconds
            if (day % 30 == 0) {
                day = 1;
                if (month % 12 == 0) {
                    month = 1;
                    year++;
                } else {
                    month++;
                }
            } else {
                day++;
            }
            clock = "\rClock: " + day + "/" + month + "/" + year;
        }
    }
}
