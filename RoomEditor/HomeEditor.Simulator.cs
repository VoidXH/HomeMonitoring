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

        /// <summary>
        /// Handle enabling/disabling the simulator.
        /// </summary>
        void Simulator_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                simulatorTimer = new Timer(1000);
                simulatorTimer.Elapsed += SimulatorTick;
                simulatorTimer.AutoReset = true;
                simulatorTimer.Enabled = true;
            } else {
                simulatorTimer.Stop();
                simulatorTimer.Dispose();
                if (lastSimulated != null)
                    lastSimulated.OnDeactivate();
            }
        }
    }
}
