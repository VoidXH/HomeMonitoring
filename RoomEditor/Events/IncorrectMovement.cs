using System;

namespace HomeEditor.Events {
    public static class IncorrectMovement {
        /// <summary>
        /// Interval to check for movement.
        /// </summary>
        public static int interval = 24 * 60 * 60;

        /// <summary>
        /// Maximum time for anything not to happen to disarm the alert.
        /// </summary>
        public static int maxSilence = 30 * 60;

        public static void Check() {
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                DateTime timeToExist = last.Timestamp.Subtract(TimeSpan.FromSeconds(interval));
                DateTime lastMovement = last.Timestamp;
                bool error = true;
                int i, start = sensor.DataHistory.Count - 2;
                for (i = start; i >= 0 && sensor.DataHistory[i].Timestamp >= timeToExist; --i) {
                    SensorData frame = sensor.DataHistory[i];
                    if (frame.Movement) {
                        if (lastMovement - frame.Timestamp > TimeSpan.FromSeconds(maxSilence)) {
                            error = false;
                            continue;
                        }
                        lastMovement = frame.Timestamp;
                    }
                }
                if (error && i > 0 && sensor.DataHistory[i].Timestamp <= timeToExist) // Protection against judging from not enough data
                    Event.Alert(sensor, "Too much movement at " + sensor.LogName + " (possible sensor failure)");
            });
        }
    }
}