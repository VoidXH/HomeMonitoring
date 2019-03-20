using System;
using System.Text;

namespace HomeEditor {
    public class SensorData {
        public DateTime timestamp { get; private set; }

        bool? _movement;
        public bool Movement {
            get => _movement ?? false;
            set => _movement = value;
        }

        public bool open;
        public bool led;
        public bool buzzer;
        public float light = -1;
        public float temperature = -1;
        public float humidity = -1;
        public float pressure = -1;
        public float battery = -1;

        public SensorData() => timestamp = DateTime.Now;

        public SensorData(DateTime timestamp) => this.timestamp = timestamp;

        public SensorData(bool movement, bool open) {
            _movement = movement;
            this.open = open;
            timestamp = DateTime.Now;
        }

        public SensorData(float temperature, float humidity, float pressure) {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            timestamp = DateTime.Now;
        }

        public SensorData(float temperature, float light, float battery, bool led, bool buzzer) {
            this.temperature = temperature;
            this.light = light;
            this.battery = battery;
            this.led = led;
            this.buzzer = buzzer;
            timestamp = DateTime.Now;
        }

        public void FillFrom(SensorData other) {
            if (!_movement.HasValue) _movement = other._movement;
            if (light <= 0) light = other.light;
            if (temperature <= 0) temperature = other.temperature;
            if (humidity <= 0) humidity = other.humidity;
            if (pressure <= 0) pressure = other.pressure;
            if (battery <= 0) battery = other.battery;
        }

        public override string ToString() {
            if (temperature > 0) {
                StringBuilder sb = new StringBuilder();
                sb.Append(Movement ? "M" : "No m").Append("ovement detected\n");
                if (led) sb.Append("LED on\n");
                if (buzzer) sb.Append("Buzzer on\n");
                if (light > 0) sb.Append("Light: ").Append(light).Append('\n');
                if (temperature > 0) sb.Append("Temperature: ").Append(temperature).Append('\n');
                if (humidity > 0) sb.Append("Humidity: ").Append(humidity).Append('\n');
                if (pressure > 0) sb.Append("Pressure: ").Append(pressure).Append('\n');
                if (battery > 0) sb.Append("Battery: ").Append(battery);
                return sb.ToString();
            } else
                return open ? "Open" : "Closed";
        }
    }
}