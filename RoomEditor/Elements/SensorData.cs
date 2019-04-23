using System;
using System.Text;

namespace HomeEditor.Elements {
    public class SensorData {
        /// <summary>
        /// Value of an unmeasured float field.
        /// </summary>
        public const float Unmeasured = -1;
        /// <summary>
        /// Ratio of light noise to retain between sensor updates.
        /// </summary>
        public const float LightNoiseFactor = .8f;

        public DateTime Timestamp { get; private set; }

        bool? _movement;
        public bool Movement {
            get => _movement ?? false;
            set => _movement = value;
        }

        public bool Open { get; set; }
        public bool LED { get; set; }
        public bool Buzzer { get; set; }
        public float Light { get; set; } = Unmeasured;
        public float Temperature { get; set; } = Unmeasured;
        public float Humidity { get; set; } = Unmeasured;
        public float Pressure { get; set; } = Unmeasured;
        public float Battery { get; set; } = Unmeasured;
        public float LightNoise { get; set; } = Unmeasured;

        public SensorData() => Timestamp = DateTime.Now;

        public SensorData(DateTime timestamp) => Timestamp = timestamp;

        public SensorData(bool movement, bool open) {
            _movement = movement;
            Open = open;
            Timestamp = DateTime.Now;
        }

        public SensorData(float temperature, float humidity, float pressure) {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            Timestamp = DateTime.Now;
        }

        public SensorData(float temperature, float light, float battery, bool led, bool buzzer) {
            Temperature = temperature;
            Light = light;
            Battery = battery;
            LED = led;
            Buzzer = buzzer;
            Timestamp = DateTime.Now;
        }

        public void FillFrom(SensorData other) {
            if (!_movement.HasValue) _movement = other._movement;
            if (Light <= 0)
                Light = other.Light;
            float lightNoiseIncrease = Math.Abs(Light - other.Light);
            if (Temperature <= 0) Temperature = other.Temperature;
            if (Humidity <= 0) Humidity = other.Humidity;
            if (Pressure <= 0) Pressure = other.Pressure;
            if (Battery <= 0) Battery = other.Battery;
            if (lightNoiseIncrease >= 0)
                LightNoise = (other.LightNoise >= 0 ? other.LightNoise : 0) * LightNoiseFactor + lightNoiseIncrease * (1 - LightNoiseFactor);
        }

        public override string ToString() {
            if (Temperature > 0) {
                StringBuilder sb = new StringBuilder();
                sb.Append(Movement ? "M" : "No m").Append("ovement detected\n");
                if (LED) sb.Append("LED on\n");
                if (Buzzer) sb.Append("Buzzer on\n");
                if (Light > 0) sb.Append("Light: ").Append(Light).Append('\n');
                if (Temperature > 0) sb.Append("Temperature: ").Append(Temperature).Append('\n');
                if (Humidity > 0) sb.Append("Humidity: ").Append(Humidity).Append('\n');
                if (Pressure > 0) sb.Append("Pressure: ").Append(Pressure).Append('\n');
                if (Battery > 0) sb.Append("Battery: ").Append(Battery);
                return sb.ToString();
            } else
                return Open ? "Open" : "Closed";
        }
    }
}