using HomeEditor.Elements;
using System;

namespace HomeEditor {
    public static class Tester {
        public static void EmptyHouseForADay() {
            Sensor target = Sensor.Random;
            for (int minutesBack = 30 * 60; minutesBack >= 0; --minutesBack) { // Send no movement info for 30 hours
                DateTime targetTime = DateTime.Now - TimeSpan.FromMinutes(minutesBack);
                target.DataReceived(new SensorData(targetTime));
            }
        }

        public static void DoorSensorFailure() {
            Sensor target = Sensor.Random;
            for (int secondsBack = 50; secondsBack >= 0; --secondsBack) { // Oscillate contact info for 50 seconds
                DateTime targetTime = DateTime.Now - TimeSpan.FromSeconds(secondsBack);
                target.DataReceived(new SensorData(targetTime) { Open = secondsBack % 2 == 0 });
            }
        }
    }
}