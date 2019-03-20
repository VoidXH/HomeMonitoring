namespace HomeEditor.Events {
    public static class IncorrectTemps {
        public static int warmupTarget = 3600;
        public static int minTemp = 10;
        public static int maxTemp = 50;

        static int cooldown = 0, warmup = 0;

        public static void Check() {
            --cooldown;
            bool error = false;
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                if (last.Temperature != -1 && (last.Temperature <= minTemp || last.Temperature >= maxTemp)) {
                    if (warmup > warmupTarget) {
                        if (cooldown <= 0) {
                            Event.Alert(sensor, "Temperature is constantly " + last.Temperature + " at " + sensor.LogName + " (possible sensor failure)");
                            cooldown = 60;
                        }
                    }
                    error = true;
                }
            });
            warmup = error ? warmup + 1 : 0;
        }
    }
}