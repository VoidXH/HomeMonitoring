using HomeEditor.Rules;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HomeEditor {
    /// <summary>
    /// The menu strip's behaviour on the main window.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Start building a new home.
        /// </summary>
        void NewToolStripMenuItem_Click(object sender, EventArgs e) => HardReset();

        /// <summary>
        /// Load a file from the recents list and put it on top.
        /// </summary>
        /// <param name="recent">File path</param>
        void LoadRecent(string recent) {
            string newRecents = Properties.Settings.Default.Recents;
            if (newRecents.Length == 0)
                Properties.Settings.Default.Recents = recent;
            else {
                int recentPos = newRecents.IndexOf(recent);
                if (recentPos == -1)
                    Properties.Settings.Default.Recents = recent + '\n' + newRecents;
                else
                    Properties.Settings.Default.Recents = recent + '\n' + newRecents.Substring(0, recentPos) +
                        newRecents.Substring(recentPos + recent.Length + 1);
            }
            Properties.Settings.Default.Save();
            LoadRecents();
            try {
                DeserializeHome(recent);
            } catch (Exception exception) {
                MessageBox.Show("Invalid XML file.\nError: " + exception.Message, "Error");
            }
            DeselectEverything();
        }

        /// <summary>
        /// Handle clicking on a recents entry.
        /// </summary>
        void LoadRecent(object sender, EventArgs e) => LoadRecent(((ToolStripMenuItem)sender).Text);

        /// <summary>
        /// Load the list of recently loaded files and create dropdown items for them.
        /// </summary>
        void LoadRecents() {
            loadRecentToolStripMenuItem.DropDownItems.Clear();
            string[] recents = Properties.Settings.Default.Recents.Split('\n');
            for (int i = 0; i < recents.Length - 1; ++i) {
                ToolStripItem recent = new ToolStripMenuItem(recents[i]);
                recent.Click += LoadRecent;
                loadRecentToolStripMenuItem.DropDownItems.Add(recent);
            }
        }

        /// <summary>
        /// Add a new file to the recents list, and make sure the list is not larger than 10 entries.
        /// </summary>
        /// <param name="recent">Target file name</param>
        void AddToRecents(string recent) {
            string newRecents = recent + '\n' + Properties.Settings.Default.Recents;
            while (newRecents.Count(c => c == '\n') > 10)
                newRecents = newRecents.Substring(0, newRecents.LastIndexOf('\n'));
            Properties.Settings.Default.Recents = newRecents;
            Properties.Settings.Default.Save();
            LoadRecents();
        }

        /// <summary>
        /// Load from a selected file.
        /// </summary>
        void LoadToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                LoadRecent(openFileDialog.FileName);
                if (!Properties.Settings.Default.Recents.Contains(openFileDialog.FileName + '\n'))
                    AddToRecents(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Save by overwriting the currently loaded file.
        /// </summary>
        void SaveToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                SerializeHome(_lastFileName);
            } catch (Exception exception) {
                MessageBox.Show("Error saving file: " + exception.Message, "Error");
                return;
            }
        }

        /// <summary>
        /// Save to a selected file.
        /// </summary>
        void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    SerializeHome(saveFileDialog.FileName);
                } catch (Exception exception) {
                    MessageBox.Show("Error saving file: " + exception.Message, "Error");
                    return;
                }
                if (!Properties.Settings.Default.Recents.Contains(saveFileDialog.FileName + '\n'))
                    AddToRecents(saveFileDialog.FileName);
                lastFileName = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Open a <see cref="RuleEditor"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RulesToolStripMenuItem_Click(object sender, EventArgs e) => new RuleEditor().ShowDialog();

        /// <summary>
        /// Open the <see cref="Colors"/> Form.
        /// </summary>
        void ColorsToolStripMenuItem_Click(object sender, EventArgs e) => new Colors().Show();

        /// <summary>
        /// About popup.
        /// </summary>
        void AboutToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("©2019 Sgánetz Bence\nhttp://sbence.tk", "About");
    }
}