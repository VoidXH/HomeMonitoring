namespace HomeEditor.Events {
    public static class UnoptimalTemps {
        public static int minTemp = 16;
        public static int maxTemp = 32;

        static int cooldown = 0;

        public static void Check() {
            --cooldown;
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                if (last.Temperature != -1 && ((last.Temperature <= minTemp && last.Temperature > IncorrectTemps.minTemp) ||
                    (last.Temperature >= maxTemp && last.Temperature < IncorrectTemps.maxTemp))) {
                    if (cooldown <= 0)
                        Event.Alert(sensor, "Temperature is " + last.Temperature + " at " + sensor.parent.Name + " (room of " + sensor.LogName + ").");
                    cooldown = 60;
                }
            });
        }
    }
}