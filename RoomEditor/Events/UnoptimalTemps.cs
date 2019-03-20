namespace HomeEditor.Events {
    public static class UnoptimalTemps {
        public static int minTemp = 16;
        public static int maxTemp = 32;

        static int cooldown = 0;

        public static void Check() {
            --cooldown;
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                if (last.temperature != -1 && ((last.temperature <= minTemp && last.temperature > IncorrectTemps.minTemp) ||
                    (last.temperature >= maxTemp && last.temperature < IncorrectTemps.maxTemp))) {
                    if (cooldown <= 0)
                        Event.Alert(sensor, "Temperature is " + last.temperature + " at " + sensor.parent.Name + " (room of " + sensor.LogName + ").");
                    cooldown = 60;
                }
            });
        }
    }
}