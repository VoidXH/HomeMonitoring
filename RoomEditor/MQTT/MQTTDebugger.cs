using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HomeEditor.MQTT {
    public partial class MQTTDebugger : Form {
        DateTime lastUpdate;
        MQTTHandler handler;
        Timer updater;

        public MQTTDebugger(MQTTHandler handler) {
            InitializeComponent();
            this.handler = handler;
            updater = new Timer {
                Enabled = true,
                Interval = 1000
            };
            updater.Tick += UpdateTick;
            UpdateTick(null, null);
        }

        private void UpdateTick(object sender, EventArgs e) {
            if (lastUpdate != handler.LastMessage) {
                lastUpdate = handler.LastMessage;
                table.Rows.Clear();
                IEnumerator enumer = handler.LastMessages.GetEnumerator();
                try {
                    while (enumer.MoveNext()) {
                        KeyValuePair<string, string> pair = (KeyValuePair<string, string>)enumer.Current;
                        table.Rows.Add(pair.Key, pair.Value);
                    }
                } catch { }
            }
        }

        private void MQTTDebugger_FormClosed(object sender, FormClosedEventArgs e) {
            updater.Stop();
            updater.Dispose();
        }
    }
}
