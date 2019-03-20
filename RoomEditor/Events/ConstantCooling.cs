using System;

namespace HomeEditor.Events {
    public static class ConstantCooling {
        /// <summary>
        /// Don't trigger alarms above this temperature.
        /// </summary>
        public static int maximumTemp = 22;
        /// <summary>
        /// Degrees to cool in the given interval.
        /// </summary>
        public static int errorCooling = 10;
        /// <summary>
        /// Time span checked in seconds.
        /// </summary>
        public static int errorInterval = 600;

        public static void Check() {
            Sensor.ForEachWithHistory((Sensor sensor) => {
                SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                float lowestTemp = last.temperature;
                DateTime lastTime = last.Timestamp.Subtract(TimeSpan.FromSeconds(errorInterval));
                for (int i = sensor.DataHistory.Count - 2; i >= 0 && sensor.DataHistory[i].Timestamp >= lastTime; --i)
                    if (lowestTemp > sensor.DataHistory[i].temperature)
                        lowestTemp = sensor.DataHistory[i].temperature;
                if (last.temperature - lowestTemp >= errorCooling && lowestTemp < maximumTemp)
                    Event.Alert(sensor, sensor.parent.Name + " (room of " + sensor.LogName + ") has cooled too much.");
            });
        }
    }
}