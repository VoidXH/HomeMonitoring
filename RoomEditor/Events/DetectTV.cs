using System;

namespace HomeEditor.Events {
    public static class DetectTV {
        const string tvStatusText = "Watching TV";

        /// <summary>
        /// Minimum light noise required to trigger the alert.
        /// </summary>
        public static float noiseThresh = 1;

        /// <summary>
        /// Samples to check.
        /// </summary>
        public static int samples = 10;

        public static void Check() {
            Sensor.ForEachWithHistory((Sensor sensor) => {
                float totalNoise = 0;
                int lastSample = sensor.DataHistory.Count - samples;
                if (lastSample >= 0) {
                    for (int i = sensor.DataHistory.Count - 2; i >= lastSample; --i)
                        totalNoise += Math.Abs(sensor.DataHistory[i].light - sensor.DataHistory[i + 1].light);
                    if (totalNoise > noiseThresh)
                        Event.Activity = tvStatusText;
                    else if (Event.Activity.Equals(tvStatusText))
                        Event.Activity = string.Empty;
                }
            });
        }
    }
}