using System;

namespace HomeEditor.Events {
    public static class OscillationError {
        /// <summary>
        /// Amount of open/close events in the checking interval to trigger the alert.
        /// </summary>
        public static int errorRate = 10;
        /// <summary>
        /// Time span checked in seconds.
        /// </summary>
        public static int errorInterval = 60;

        public static void Check() {
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                bool lastState = last.open;
                int stateChanges = 0;
                DateTime lastTime = last.timestamp.Subtract(TimeSpan.FromSeconds(errorInterval));
                for (int i = sensor.DataHistory.Count - 2; i >= 0 && sensor.DataHistory[i].timestamp >= lastTime; --i) {
                    if (sensor.DataHistory[i].open != lastState) {
                        ++stateChanges;
                        lastState = !lastState;
                    }
                }
                if (stateChanges >= errorRate)
                    Event.Alert(sensor, "Too many open/close of " + sensor.LogName + " (possible sensor failure)");
            });
        }
    }
}