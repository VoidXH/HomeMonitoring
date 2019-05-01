using HomeEditor.Elements;
using System;
using System.Timers;
using System.Windows.Forms;

using Timer = System.Timers.Timer;

namespace HomeEditor {
    /// <summary>
    /// Simulation handling.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Random generator.
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// The last selected simulated sensor.
        /// </summary>
        Sensor lastSimulated;

        /// <summary>
        /// Simulation timer.
        /// </summary>
        Timer simulatorTimer;

        /// <summary>
        /// Simulator callback every second, selects a new sensor to activate and deactivate the current one.
        /// </summary>
        void SimulatorTick(object source, ElapsedEventArgs e) {
            Invoke((MethodInvoker)delegate {
                if (lastSimulated != null)
                    lastSimulated.OnDeactivate();
                lastSimulated = Sensor.Random;
                lastSimulated.OnActivate();
            });
        }

        void EnableSimulator() {
            if (simulatorTimer == null) {
                simulatorTimer = new Timer(1000);
                simulatorTimer.Elapsed += SimulatorTick;
                simulatorTimer.AutoReset = true;
                simulatorTimer.Enabled = true;
                SimulatorTick(null, null);
            }
        }

        void DisableSimulator() {
            if (simulatorTimer != null) {
                simulatorTimer.Stop();
                simulatorTimer.Dispose();
                simulatorTimer = null;
                if (lastSimulated != null)
                    lastSimulated.OnDeactivate();
            }
        }

        /// <summary>
        /// Switch between simulator enabled/disabled.
        /// </summary>
        void ToggleSimulator(object sender, EventArgs e) {
            if (simulatorTimer == null)
                EnableSimulator();
            else
                DisableSimulator();
        }
    }
}