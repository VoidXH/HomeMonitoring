using System;

namespace HomeEditor.Events {
    public static class NoMovement {
        public const string sleepingStatusText = "Sleeping";

        /// <summary>
        /// Time after no movement is interpreted as sleep.
        /// </summary>
        public static int sleepTimer = 2 * 60 * 60;

        public static void Check() {
            Room lastRoom = Event.GetLastRoom();
            if (lastRoom != null && !lastRoom.IsLobby) {
                bool movement = false;
                Sensor.ForEachWithHistory((Sensor sensor) => {
                    if (sensor.parent == lastRoom) {
                        SensorData last = sensor.DataHistory[sensor.DataHistory.Count - 1];
                        DateTime sleepTime = last.timestamp.Subtract(TimeSpan.FromSeconds(sleepTimer));
                        movement |= last.Movement;
                        int i = sensor.DataHistory.Count - 2;
                        for (; i >= 0 && !movement && sensor.DataHistory[i].timestamp >= sleepTime; --i)
                            movement |= (sensor.DataHistory[i].Movement);
                        if (i != 0)
                            return;
                    }
                });
                if (!movement)
                    Event.Activity = sleepingStatusText;
                else if (Event.Activity.Equals(sleepingStatusText))
                    Event.Activity = string.Empty;
            }
        }
    }
}