namespace HomeEditor.Events {
    public static class Leaving {
        /// <summary>
        /// Alert after the entrance is open for longer than this time (in seconds) and the house is empty.
        /// </summary>
        public static int alertTimer = 5 * 60;

        /// <summary>
        /// The time since the leaving was detected.
        /// </summary>
        static int timer = 0;

        /// <summary>
        /// Only alert once per event.
        /// </summary>
        static bool alerted = false;

        /// <summary>
        /// Start counting for the alert again.
        /// </summary>
        static void Reset() {
            alerted = false;
            timer = 0;
        }

        public static void Check() {
            Room lastRoom = Event.GetLastRoom();
            if (lastRoom == null)
                return;
            bool movement = false; // Movement in the last room
            Sensor.ForEachWithHistory(sensor => {
                if (sensor.parent == lastRoom && sensor.DataHistory[sensor.DataHistory.Count - 1].open)
                    movement = true;
            });
            if (movement) {
                Reset();
                return;
            }
            if (++timer <= alertTimer)
                return;
            Sensor.ForEachDoorWithHistory(lastRoom, (door, sensor) => {
                if (door.doorType == Door.Types.Entrance && sensor.DataHistory[sensor.DataHistory.Count - 1].open) {
                    if (!alerted)
                        Event.Alert(sensor, "The house is empty but an entrance (" + sensor.LogName + ") is open.");
                    alerted = true;
                    return;
                }
            });
            Reset();
        }
    }
}