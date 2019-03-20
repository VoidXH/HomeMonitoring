namespace HomeEditor.Events {
    public static class SleepDisorder {
        /// <summary>
        /// Light value considered darkness.
        /// </summary>
        public static float lightThreshold = .2f;

        public static void Check() {
            Room lastRoom = Event.GetLastRoom();
            if (lastRoom == null)
                return;
            float maxLight = 0;
            Sensor.ForEachWithHistory((sensor) => {
                if (sensor.parent == lastRoom) {
                    float lastLight = sensor.DataHistory[sensor.DataHistory.Count - 1].light;
                    if (maxLight < lastLight)
                        maxLight = lastLight;
                }
            });
            if (maxLight < lightThreshold)
                return;
            Sensor.ForEachDoor(lastRoom, (door, sensor) => {
                int entries = sensor.DataHistory.Count;
                if (entries >= 2 && sensor.DataHistory[entries - 1].open && !sensor.DataHistory[entries - 2].open)
                    Event.Alert(sensor, "Door " + sensor.LogName + " opened in the dark (possible sleep disorder).");
            });
        }
    }
}