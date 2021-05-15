using SurvivalBuilder;
using SurvivalBuilder.Player.Origin.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalBuilderApp {
    class SavedGames {
        public List<string> savedFiles { get; set; }
        public BinaryFormatter binFormat = new BinaryFormatter();

        public SavedGames() {
            savedFiles = new List<string>();

            // List all saved files available
            try {
                foreach (string f in Directory.GetFiles(Directory.GetCurrentDirectory())) {
                    if (f.Contains("user")) {
                        savedFiles.Add(f);
                    }
                }
            } catch (UnauthorizedAccessException) {
                Console.WriteLine($"We do not have access to {Directory.GetCurrentDirectory()}");
            }
        }

        public PlayerInfo getPlayer(string file) {
            foreach (string f in savedFiles) {
                if (f.Contains(file)) {
                    Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
                    PlayerInfo player = (PlayerInfo)binFormat.Deserialize(stream);
                    stream.Close();
                    return player;
                }
            }
            return null;
        }

        public void saveGame(PlayerInfo player) {
            Stream stream = new FileStream(player.file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            binFormat.Serialize(stream, player);
            stream.Close();
        }
    }
}
