using HomeEditor.Elements;
using System.Collections.Generic;

namespace HomeEditor.Rules {
    public class AllLobbies : Room {
        static AllLobbies instance;

        public static AllLobbies Instance => instance ?? (instance = new AllLobbies());

        AllLobbies() : base(null) => SetName("All lobbies");

        public override bool IsLobby => true;

        public override IReadOnlyList<SensorData> DataHistory => base.DataHistory;
    }
}